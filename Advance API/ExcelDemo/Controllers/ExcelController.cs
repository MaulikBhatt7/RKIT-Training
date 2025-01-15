using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using OfficeOpenXml;

namespace ExcelDemo.Controllers
{
    public class ExcelController : ApiController
    {
        /// <summary>
        /// API to download an Excel file with sample data.
        /// </summary>
        /// <returns>HttpResponseMessage with the Excel file.</returns>
        [HttpGet]
        [Route("api/excel/download")]
        public HttpResponseMessage DownloadExcel()
        {
            try
            {
                // Create a new Excel package
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    // Add a worksheet to the Excel package
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SampleSheet");

                    // Add headers to the worksheet
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Name";
                    worksheet.Cells[1, 3].Value = "Age";

                    // Add sample data to the worksheet
                    worksheet.Cells[2, 1].Value = 1;
                    worksheet.Cells[2, 2].Value = "MB";
                    worksheet.Cells[2, 3].Value = 20;

                    worksheet.Cells[3, 1].Value = 2;
                    worksheet.Cells[3, 2].Value = "YK";
                    worksheet.Cells[3, 3].Value = 20;

                    // Auto-fit columns for better appearance
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Save the Excel package to a memory stream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        excelPackage.SaveAs(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        // Create an HTTP response with the Excel file
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new ByteArrayContent(memoryStream.ToArray())
                        };

                        // Set the content headers for file download
                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "SampleData.xlsx"
                        };
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors and return an appropriate response
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// API to upload an Excel file and read its content.
        /// </summary>
        /// <returns>HttpResponseMessage with the parsed content of the uploaded file.</returns>
        [HttpPost]
        [Route("api/excel/upload")]
        public HttpResponseMessage UploadExcel()
        {
            try
            {
                // Validate if the request contains multipart content
                if (!Request.Content.IsMimeMultipartContent())
                {
                    return Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, "Invalid content type. Please upload a valid Excel file.");
                }

                // Read multipart content with enhanced error handling
                var provider = Request.Content.ReadAsMultipartAsync(new MultipartMemoryStreamProvider()).Result;

                foreach (HttpContent content in provider.Contents)
                {
                    // Extract file name
                    string fileName = content.Headers.ContentDisposition.FileName?.Trim('"');
                    if (string.IsNullOrEmpty(fileName))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No file uploaded or file name is missing.");
                    }

                    // Ensure the uploaded file has the correct extension
                    if (!fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid file type. Please upload an Excel file (.xlsx).");
                    }

                    // Read the uploaded file into a memory stream
                    using (Stream fileStream = content.ReadAsStreamAsync().Result)
                    {
                        if (fileStream.Length == 0)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The uploaded file is empty.");
                        }

                        using (ExcelPackage excelPackage = new ExcelPackage(fileStream))
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
                            if (worksheet == null || worksheet.Dimension == null)
                            {
                                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The worksheet is empty or invalid.");
                            }

                            // Parse data from the worksheet into a list of dictionaries
                            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
                            int rowCount = worksheet.Dimension.Rows;
                            int columnCount = worksheet.Dimension.Columns;

                            // Assuming the first row contains column headers
                            for (int row = 2; row <= rowCount; row++)
                            {
                                Dictionary<string, object> rowData = new Dictionary<string, object>();
                                for (int col = 1; col <= columnCount; col++)
                                {
                                    string columnName = worksheet.Cells[1, col].Text;
                                    object cellValue = worksheet.Cells[row, col].Value;
                                    rowData.Add(columnName, cellValue);
                                }
                                data.Add(rowData);
                            }

                            // Return the parsed data as a JSON response
                            return Request.CreateResponse(HttpStatusCode.OK, data);
                        }
                    }
                }

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No valid file found in the request.");
            }
            catch (IOException ioEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "File upload was interrupted or incomplete. Please try again.");
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No inner exception";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"An error occurred: {ex.Message}. Inner Exception: {innerExceptionMessage}");
            }
        }


    }
}

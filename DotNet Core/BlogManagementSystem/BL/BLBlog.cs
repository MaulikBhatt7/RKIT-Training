using BlogManagementSystem.Extension;
using BlogManagementSystem.Models;
using BlogManagementSystem.Models.DTO;
using BlogManagementSystem.Models.Enum;
using BlogManagementSystem.Models.POCO;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;

namespace BlogManagementSystem.BL
{
    /// <summary>
    /// Business Logic class for managing Blog operations.
    /// </summary>
    public class BLBlog
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private Response _objResponse;
        private BLConverter _objBLConverter;
        private BLG01 _objBLG01;
        private int _id;
        public EnmType Type;

        /// <summary>
        /// Constructor to initialize the BLBlog with necessary dependencies.
        /// </summary>
        /// <param name="dbConnectionFactory">Database connection factory.</param>
        /// <param name="objResponse">Response object.</param>
        /// <param name="objBLConverter">Converter object for data transformations.</param>
        public BLBlog(IDbConnectionFactory dbConnectionFactory, Response objResponse, BLConverter objBLConverter)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _objResponse = objResponse;
            _objBLConverter = objBLConverter;
            _objBLG01 = new BLG01();
        }

        /// <summary>
        /// Retrieves all blog records.
        /// </summary>
        /// <returns>Response object containing blog data or error message.</returns>
        public Response GetAllBlogs()
        {
            List<BLG01> lstBlogs = new List<BLG01>();
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                lstBlogs = db.Select<BLG01>();
            }
            if (lstBlogs.Count > 0)
            {
                _objResponse.Data = _objBLConverter.ToDataTable(lstBlogs);
                _objResponse.Message = "Get Data Successfully.";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }

            return _objResponse;
        }

        /// <summary>
        /// Retrieves a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object containing blog data or error message.</returns>
        public Response GetBlogByID(int id)
        {
            BLG01 objBLG01 = new BLG01();
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                objBLG01 = db.SingleById<BLG01>(id);
            }

            if (objBLG01 != null)
            {
                _objResponse.Data = _objBLConverter.ObjectToDataTable(objBLG01);
                _objResponse.Message = "Get Data Successfully.";
            }
            else
            {
                _objResponse.IsError = true;
                _objResponse.Message = "No Data Found";
            }

            return _objResponse;
        }

        /// <summary>
        /// Prepares the blog entity for saving (add/edit).
        /// </summary>
        /// <param name="objDTOBLG01">DTO object for blog.</param>
        public void PreSave(DTOBLG01 objDTOBLG01)
        {
            _objBLG01 = objDTOBLG01.Convert<BLG01>(); // Convert DTO to entity.
            if (Type == EnmType.A)
            {
                _objBLG01.G01F04 = DateTime.Now; // Set creation date.
            }
            else if (Type == EnmType.E && objDTOBLG01.G01F01 > 0)
            {
                _objBLG01.G01F05 = DateTime.Now; // Set modification date.
                _id = objDTOBLG01.G01F01; // Set ID for editing.
            }
        }

        /// <summary>
        /// Checks if a blog record exists by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>True if exists, otherwise false.</returns>
        private bool IsBLG01Exist(int id)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Exists<BLG01>(id); // Check for existence.
            }
        }

        /// <summary>
        /// Validates the save operation for add/edit.
        /// </summary>
        /// <returns>Response object indicating validation result.</returns>
        public Response ValidationSave()
        {
            if (Type == EnmType.E) // If editing.
            {
                if (!(_id > 0))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Enter Correct Id"; // Invalid ID.
                }
                else if (!IsBLG01Exist(_id))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Blog Not Found"; // ID not found.
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Saves the blog record (add/edit).
        /// </summary>
        /// <returns>Response object indicating save result.</returns>
        public Response Save()
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                if (Type == EnmType.A) // Add operation.
                {
                    db.Insert(_objBLG01); // Insert Blog record.
                    _objResponse.Message = "Data Added";
                }
                if (Type == EnmType.E) // Edit operation.
                {
                    db.Update(_objBLG01); // Update Blog record.
                    _objResponse.Message = "Data Updated";
                }
            }
            return _objResponse;
        }

        /// <summary>
        /// Prepares the blog entity for deletion by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object containing blog data or null.</returns>
        private Response PreDelete(int id)
        {
            if (IsBLG01Exist(id))
            {
                return GetBlogByID(id); // Retrieve blog for deletion if exists.
            }
            return null;
        }

        /// <summary>
        /// Validates the deletion operation.
        /// </summary>
        /// <param name="objDataTable">Data table containing blog data.</param>
        /// <returns>Response object indicating validation result.</returns>
        private Response ValidateOnDelete(DataTable objDataTable)
        {
            if (objDataTable == null)
                return new Response { IsError = true, Message = "Blog not found." };

            return new Response { IsError = false }; // Valid for deletion.
        }

        /// <summary>
        /// Deletes a blog record by its ID.
        /// </summary>
        /// <param name="id">Blog ID.</param>
        /// <returns>Response object indicating deletion result.</returns>
        public Response Delete(int id)
        {
            Response objResponse = PreDelete(id); // Pre-deletion checks.
            var validationResponse = ValidateOnDelete(objResponse.Data);
            if (validationResponse.IsError)
                return validationResponse; // Abort if validation fails.

            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                db.DeleteById<BLG01>(id); // Delete Blog record by ID.
            }
            _objResponse.Message = "Data Deleted"; // Success message.
            return _objResponse;
        }
    }
}
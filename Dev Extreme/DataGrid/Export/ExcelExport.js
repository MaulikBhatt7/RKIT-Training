$(() => {

    // Initialize the main DataGrid (Master Grid)
    $("#dataGrid").dxDataGrid({
        // Set the data source to the master sales data
        dataSource: tmkocSales,
        
        // Specify the unique key field
        keyExpr: "OrderID",

        // Define the columns to be displayed in the master grid
        columns: [
            { dataField: "OrderID", caption: "Order ID", dataType: "number" },
            { dataField: "Customer", caption: "Customer Name", dataType: "string" },
            { dataField: "OrderDate", caption: "Order Date", dataType: "date" }
        ],

        // Enable grid appearance settings
        showBorders: true,
        showColumnLines: true,
        showRowLines: true,
        rowAlternationEnabled: true,

        // Allow reordering and resizing of columns
        allowColumnReordering: true,
        allowColumnResizing: true,

        // Enable automatic column width adjustment
        columnAutoWidth: true,

        // Export Configuration
        export: {
            enabled: true,
            allowExportSelectedData: true,
        },

        // onExporting(e) {
        //     const workbook = new ExcelJS.Workbook();
        //     const worksheet = workbook.addWorksheet('Orders');
      
        //     DevExpress.excelExporter.exportDataGrid({
        //       component: e.component,
        //       worksheet,
        //       autoFilterEnabled: true,
        //     }).then(() => {
        //       workbook.xlsx.writeBuffer().then((buffer) => {
        //         saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Orders.xlsx');
        //       });
        //     });
        // },

        onExporting(e) {
            const workbook = new ExcelJS.Workbook();
            const worksheet = workbook.addWorksheet('Orders');
        
            // Define header row for Master Grid
            worksheet.columns = [
                { header: 'Order ID', key: 'OrderID', width: 15 },
                { header: 'Customer Name', key: 'Customer', width: 30 },
                { header: 'Order Date', key: 'OrderDate', width: 20 },
                { header: 'Product', key: 'Product', width: 30 },
                { header: 'Quantity', key: 'Quantity', width: 15 },
                { header: 'Unit Price', key: 'UnitPrice', width: 15 },
                { header: 'Total Price', key: 'TotalPrice', width: 15 }
            ];
        
            // Export each master row with its detail rows
            const masterGrid = e.component;
            const masterData = masterGrid.getDataSource().items();
        
            masterData.forEach(masterRow => {
                // Add master row to the worksheet
                worksheet.addRow({
                    OrderID: masterRow.OrderID,
                    Customer: masterRow.Customer,
                    OrderDate: masterRow.OrderDate,
                }).font = { bold: true }; // Make master rows bold
        
                // Fetch detail rows
                const detailData = tmkocOrderDetails.filter(item => item.OrderID === masterRow.OrderID);
                
                detailData.forEach(detailRow => {
                    worksheet.addRow({
                        Product: detailRow.Product,
                        Quantity: detailRow.Quantity,
                        UnitPrice: detailRow.UnitPrice,
                        TotalPrice: detailRow.Quantity * detailRow.UnitPrice
                    });
                });
        
                // Add an empty row for spacing after each master-detail group
                worksheet.addRow({});
            });
        
            // Save the Excel file
            workbook.xlsx.writeBuffer().then((buffer) => {
                saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Orders_with_Details.xlsx');
            });
        },
        

        // Enable Master-Detail feature for showing related order details
        masterDetail: {
            enabled: true,
            template: function (container, options) {
                // Get the OrderID of the selected master row
                var orderID = options.data.OrderID;

                // Create a container for the detail grid
                $("<div>")
                    .addClass("internal-grid")
                    .appendTo(container)
                    .dxDataGrid({
                        // Filter detail data to show only products related to the selected OrderID
                        dataSource: tmkocOrderDetails.filter(item => item.OrderID === orderID),

                        // Specify the unique key for detail grid
                        keyExpr: "Product",

                        // Define the columns to be displayed in the detail grid
                        columns: [
                            { dataField: "Product", caption: "Product" },
                            { dataField: "Quantity", caption: "Quantity", dataType: "number" },
                            { dataField: "UnitPrice", caption: "Unit Price", dataType: "number", format: "currency" },
                            {
                                dataField: "TotalPrice",
                                caption: "Total Price",
                                dataType: "number",
                                format: "currency",
                                calculateCellValue: function (rowData) {
                                    // Calculate total price for each product
                                    return rowData.Quantity * rowData.UnitPrice;
                                }
                            }
                        ],

                        // Enable border and column width auto adjustment for detail grid
                        showBorders: true,
                        columnAutoWidth: true
                    }
                );
            }
        }
    });

});

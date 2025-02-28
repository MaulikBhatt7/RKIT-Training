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
                    });
            }
        }
    });

});

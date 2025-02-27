$(() => {
    // Initialize the DevExtreme DataGrid
    $("#dataGrid").dxDataGrid({
        // Specify the data source for the grid
        dataSource: tmkocSales,

        // Define the columns to be displayed in the grid
        columns: [
            {
                // Column for Order ID
                dataField: "OrderID",
                caption: "Order ID",
                dataType: "number"
            },
            {
                // Column for Customer Name
                dataField: "Customer",
                caption: "Customer Name",
                dataType: "string"
            },
            {
                // Column for Product
                dataField: "Product",
                caption: "Product",
                dataType: "string"
            },
            {
                // Column for Quantity
                dataField: "Quantity",
                caption: "Quantity",
                dataType: "number"
            },
            {
                // Column for Unit Price
                dataField: "UnitPrice",
                caption: "Unit Price",
                dataType: "number",
                format: "currency" // Format the number as currency
            },
            {
                // Column for Order Date
                dataField: "OrderDate",
                caption: "Order Date",
                dataType: "date" // Specify the data type as date
            },
            {
                // Calculated column for Total Price
                dataField: "TotalPrice",
                caption: "Total Price",
                dataType: "number",
                format: "currency", // Format the number as currency
                calculateCellValue: function (rowData) {
                    // Calculate the total price by multiplying quantity and unit price
                    return rowData.Quantity * rowData.UnitPrice;
                }
            }
        ],

        // Display borders around the grid
        showBorders: true,

        // Display vertical lines between columns
        showColumnLines: true,

        // Display horizontal lines between rows
        showRowLines: true,

        // Enable alternating row colors for better readability
        rowAlternationEnabled: true,

        // Configure summary options
        summary: {
            // Define total summary items
            totalItems: [
                {
                    // Display the sum of quantities
                    column: "Quantity",
                    summaryType: "sum",
                    displayFormat: "Total Quantity: {0}"
                },
                {
                    // Display the sum of total prices
                    column: "TotalPrice",
                    summaryType: "sum",
                    displayFormat: "Total Sales: {0}",
                    valueFormat: "currency" // Format the summary value as currency
                }
            ]
        },

        // Allow users to reorder columns via drag-and-drop
        allowColumnReordering: true,

        // Allow users to resize columns
        allowColumnResizing: true,

        // Enable automatic column width adjustment
        columnAutoWidth: true
    });
});

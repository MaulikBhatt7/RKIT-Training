$(() => {
    // Initialize the DevExtreme DataGrid
    $("#dataGrid").dxDataGrid({
        // Specify the data source for the grid
        dataSource: tmkocSales,

        // Enable Column Hiding
        columnHidingEnabled: true,

        // Define the columns to be displayed in the grid
        columns: [
            {
                // Column for Order ID
                dataField: "OrderID",
                caption: "Order ID",
                dataType: "number",
                hidingPriority: 0,
            },
            {
                // Column for Customer Name
                dataField: "Customer",
                caption: "Customer Name",
                dataType: "string",
                hidingPriority: 5,
            },
            {
                // Column for Product
                dataField: "Product",
                caption: "Product",
                dataType: "string",
                hidingPriority: 3,
            },
            {
                // Column for Quantity
                dataField: "Quantity",
                caption: "Quantity",
                dataType: "number",
                hidingPriority: 2,
            },
            {
                // Column for Unit Price
                dataField: "UnitPrice",
                caption: "Unit Price",
                dataType: "number",
                format: "currency", // Format the number as currency
                hidingPriority: 1,
            },
            {
                // Column for Order Date
                dataField: "OrderDate",
                caption: "Order Date",
                dataType: "date", // Specify the data type as date
                hidingPriority: 4,
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
                },
                hidingPriority: 6,
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

        // Allow users to reorder columns via drag-and-drop
        allowColumnReordering: true,

        // Allow users to resize columns
        allowColumnResizing: true,

        // Enable automatic column width adjustment
        columnAutoWidth: true
    });
});

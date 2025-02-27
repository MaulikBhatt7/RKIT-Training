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
                format: "currency"
            },
            {
                // Column for Order Date
                dataField: "OrderDate",
                caption: "Order Date",
                dataType: "date"
            },
            {
                // Column for Total Price (calculated field)
                dataField: "TotalPrice",
                caption: "Total Price",
                dataType: "number",
                format: "currency",
                groupIndex: 0, // Group by this column
                calculateCellValue: function (rowData) {
                    // Calculate Total Price as Quantity * Unit Price
                    return rowData.Quantity * rowData.UnitPrice;
                }
            }
        ],

        // Enable borders around the grid
        showBorders: true,

        // Display vertical lines between columns
        showColumnLines: true,

        // Display horizontal lines between rows
        showRowLines: true,

        // Enable alternating row colors for better readability
        rowAlternationEnabled: true,

        // Configure summaries
        summary: {
            // Define group-level summaries
            groupItems: [
                {
                    // Sum of Quantity for each group
                    column: "Quantity",
                    summaryType: "sum",
                    displayFormat: "Total Quantity: {0}",
                    showInGroupFooter: true, // Show in group footer
                    recalculateWhileEditing: true // Recalculate on data change
                },
                {
                    // Sum of Total Price for each group
                    column: "TotalPrice",
                    summaryType: "sum",
                    displayFormat: "Total Sales: {0}",
                    valueFormat: "currency",
                    recalculateWhileEditing: true // Recalculate on data change
                }
            ]
        },

        // Configure grouping behavior
        grouping: {
            autoExpandAll: true // Automatically expand all groups
        },

        // Display the group panel to allow users to drag columns for grouping
        groupPanel: {
            visible: true
        },

        // Allow users to reorder columns via drag-and-drop
        allowColumnReordering: true,

        // Allow users to resize columns
        allowColumnResizing: true,

        // Enable automatic column width adjustment
        columnAutoWidth: true
    });
});

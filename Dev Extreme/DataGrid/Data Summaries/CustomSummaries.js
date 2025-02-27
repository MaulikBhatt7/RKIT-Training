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

         // Summary configuration
         summary: {
            totalItems: [
                {
                    // Custom Summary 1: Maximum Quantity Ordered
                    name: "customSummary1",
                    summaryType: "custom",
                    displayFormat: "Max Quantity: {0}"
                },
                {
                    // Custom Summary 2: Total Sales & Order Count
                    name: "customSummary2",
                    summaryType: "custom",
                    displayFormat: "Total Sales: {0}"
                }
            ],

            // Custom summary calculation function
            calculateCustomSummary: function(options) {
                // Handle the calculation of custom summary 1 (Maximum Quantity Ordered)
                if (options.name === "customSummary1") {
                    switch (options.summaryProcess) {
                        case "start":
                            options.totalValue = 0; // Initialize total value
                            break;
                        case "calculate":
                            // Compare the current row's Quantity value and update if it's higher
                            options.totalValue = Math.max(options.totalValue, options.value.Quantity);
                            break;
                        case "finalize":
                            // The final max value is already stored in totalValue
                            break;
                    }
                }

                // Handle the calculation of custom summary 2 (Total Revenue & Order Count)
                if (options.name === "customSummary2") {
                    switch (options.summaryProcess) {
                        case "start":
                            // Initialize an object to store total sales and order count
                            options.totalValue = { totalSales: 0, orderCount: 0 };
                            break;
                        case "calculate":
                            // Accumulate total sales and count the number of orders
                            options.totalValue.totalSales += options.value.Quantity * options.value.UnitPrice;
                            options.totalValue.orderCount++;
                            break;
                        case "finalize":
                            // Format the final summary output
                            options.totalValue = `Sales: $${options.totalValue.totalSales.toFixed(2)}, Orders: ${options.totalValue.orderCount}`;
                            break;
                    }
                }
            }
        },

        // Allow users to reorder columns via drag-and-drop
        allowColumnReordering: true,

        // Allow users to resize columns
        allowColumnResizing: true,

        // Enable automatic column width adjustment
        columnAutoWidth: true
    });
});

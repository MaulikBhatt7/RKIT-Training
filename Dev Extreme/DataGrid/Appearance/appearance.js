$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({
        
        // Assign the array as the data source
        dataSource: data,

        // Display borders around the entire grid
        showBorders: true,

        // Show vertical lines between columns
        showColumnLines: true,

        // Show horizontal lines between rows
        showRowLines: true,

        // Enable alternating row colors for better readability
        rowAlternationEnabled: true, 
    });
});
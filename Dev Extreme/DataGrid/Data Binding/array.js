$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#gridContainer").dxDataGrid({
        dataSource: data // Assign the array as the data source
    });
});
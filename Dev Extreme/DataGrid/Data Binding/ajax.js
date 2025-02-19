$(() => {
    // Define a custom data store using DevExtreme's CustomStore
    var data = new DevExpress.data.CustomStore({
        key: "userId", // Unique key field for each data record

        // Load function to fetch data from the server
        load() {
            return $.ajax({
                url: "https://jsonplaceholder.typicode.com/todos", // API endpoint to fetch data
                dataType: "json", // Expecting JSON response
            })
                .then((result) => result) // Return the fetched data on success
                .fail(() => {
                    throw new Error("Data Loading Error"); // Handle any errors during data loading
                });
        },
    });

    // Initialize DevExtreme DataGrid with the custom data store
    $("#gridContainer").dxDataGrid({
        dataSource: data // Assign the custom data store as the data source
    });
});

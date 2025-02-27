function sendStorageRequest(storageKey, dataType, method, data) {
    var deferred = new $.Deferred(); // Create a Deferred object to handle asynchronous operations

    var requestData = method === "GET" ? null : JSON.stringify(data); // Convert data to JSON format if not a GET request

    var storageRequestSettings = {
        url: "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees/1", // Ensure correct URL with an ID for PUT requests
        headers: {
            "Accept": "application/json", // Expect JSON response
            "Content-Type": "application/json" // Sending JSON data
        },
        method: method, // HTTP method (GET, PUT)
        data: requestData, // Data payload for PUT requests
        dataType: dataType, // Expected response format
        success: function (response) {
            console.log("Success:", response); // Log the success response
            deferred.resolve(response); // Resolve the Deferred object
        },
        error: function (error) {
            console.error("Error:", error); // Log the error response
            deferred.reject(error); // Reject the Deferred object
        }
    };

    $.ajax(storageRequestSettings); // Execute AJAX request
    return deferred.promise(); // Return a promise for asynchronous handling
}

$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    var dataGridInstance = $("#dataGrid").dxDataGrid({

        // Assign the array as the data source
        dataSource: data,

        // Define the columns for the DataGrid
        columns: [
            { dataField: "ID", caption: "ID" }, // Column for ID
            { dataField: "Name", caption: "Name" }, // Column for Name
            { dataField: "Age", caption: "Age" } // Column for Age
        ],

        // Configure the filter row settings
        filterRow: {
            visible: true, // Display the filter row
            applyFilter: 'onClick', // Apply filter only when the user clicks the apply button
            applyFilterText: 'Apply Filter', // Custom text for apply filter button
            betweenEndText: 'To', // Custom text for end value in 'between' filter
            betweenStartText: 'From', // Custom text for start value in 'between' filter
            showOperationChooser: true // Show the filter operation chooser in filter row
        },

        // Enable synchronization between the filter row and filter panel
        filterSyncEnabled: true,

        // Set a default filter condition (commented out for now)
        // filterValue: ["ID", "=", 2],

        stateStoring: {
            enabled: true, // Enable state storing
            type: "custom", // Use a custom storage mechanism
            customLoad: function () {
                return sendStorageRequest("storageKey", "json", "GET"); // Load stored state from API
            },
            customSave: function (state) {
                sendStorageRequest("storageKey", "json", "PUT", state); // Save current state to API
            },
            storageKey: "Custom Store" // Custom key identifier for storage
        }
    }).dxDataGrid("instance");
});

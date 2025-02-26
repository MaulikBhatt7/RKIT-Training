function sendStorageRequest(storageKey, dataType, method, data) {
    var deferred = new $.Deferred();
    var storageRequestSettings = {
        url: "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        method: method,
        data: data ? JSON.stringify({ name: JSON.stringify(data) }) : null,
        dataType: dataType,
        success: function (data) {
            console.log(data);
            deferred.resolve(data);
        },
        error: function (error) {
            deferred.reject(error);
        }
    };
    $.ajax(storageRequestSettings);
    return deferred.promise();
}

$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    var dataGridInstance = $("#dataGrid").dxDataGrid({

        // Assign the array as the data source
        dataSource: data,

        // Define the columns for the DataGrid
        columns: [
            // Column for ID
            { dataField: "ID", caption: "ID" },

            // Column for Name
            { dataField: "Name", caption: "Name" },

            // Column for Age
            { dataField: "Age", caption: "Age" },
        ],

        // Configure the filter panel settings
        filterPanel: {
            // Disable the filter builder
            filterEnabled: true,

            // Show the filter panel
            visible: true,

            text: {
                // Custom text for filter creation
                createFilter: "Create your filter"
            }
        },

        // Configure the filter row settings
        filterRow: {
            // Display the filter row
            visible: true,

            // Apply the filter only when the user clicks the apply button
            applyFilter: 'onClick',

            // Custom text for the apply filter button
            applyFilterText: 'Apply Filter',

            // Custom text for the end value in the 'between' filter operation
            betweenEndText: 'To',

            // Custom text for the start value in the 'between' filter operation
            betweenStartText: 'From',

            // Show the operation chooser in the filter row
            showOperationChooser: true,
        },

        // Enable synchronization between the filter row and filter panel
        filterSyncEnabled: true,

        // Set a default filter condition to show only rows where ID equals 2
        // filterValue: ["ID", "=", 2],

        stateStoring: {
            enabled: true,
            type: "custom",
            customLoad: function () {
                return sendStorageRequest("storageKey", "json", "GET");
            },
            customSave: function (state) {
                sendStorageRequest("storageKey", "json", "POST", state);
            }
        },
    }).dxDataGrid("instance");

});
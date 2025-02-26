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

            // Column for Salary
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
            type: 'localStorage',
            storageKey: 'MyLocalStorage',
        },
    }).dxDataGrid("instance");

    // Save State Button Click Event
    $("#saveStateButton").on("click", function () {
        var state = dataGridInstance.state(); // gets the current state
        console.log(state);
        localStorage.setItem("MyLocalStorage", JSON.stringify(state));
        DevExpress.ui.notify("State Saved", "success", 500);
    });

    // Load State Button Click Event
    $("#loadStateButton").on("click", function () {
        var state = JSON.parse(localStorage.getItem("MyLocalStorage"));
        dataGridInstance.state(state);
        DevExpress.ui.notify("State Loaded", "success", 500);
    });

    // Reset State Button Click Event
    $("#resetStateButton").on("click", function () {
        dataGridInstance.state(null);
        DevExpress.ui.notify("State Reset", "success", 500);
    });
});

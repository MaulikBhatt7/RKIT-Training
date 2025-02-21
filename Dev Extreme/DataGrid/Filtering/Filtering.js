$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({

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
            filterEnabled: false,

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
        filterValue: ["ID", "=", 2]
    });
});

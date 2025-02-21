$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({

        // Assign the array as the data source
        dataSource: data,

        // Define the columns for the DataGrid
        columns: [
            // Column for ID
            { dataField: "ID", caption: "ID"},

            // Column for Name with initial sorting applied
            { 
                dataField: "Name", 
                caption: "Name", 

                // Sort order index (first priority)
                sortIndex: 0, 

                // Sort in ascending order
                sortOrder: "asc" 
            },

            // Column for Age with initial sorting applied
            { 
                dataField: "Age", 
                caption: "Age", 

                // Sort order index (second priority)
                sortIndex: 1, 

                // Sort in ascending order
                sortOrder: "asc" 
            },
        ],

        // Configure sorting settings
        sorting: {
            // Enable multiple column sorting
            mode: "multiple",

            // Show sort indexes when multiple sorting is applied
            showSortIndexes: true,

            // Custom text for sorting in ascending order
            ascendingText: "Apply Sorting By Ascending Order",

            // Custom text for clearing applied sorting
            clearText: "Clear Applied Sorting",

            // Custom text for sorting in descending order
            descendingText: "Apply Sorting By Descending Order"
        }
    });
});

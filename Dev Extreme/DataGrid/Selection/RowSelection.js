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
                // Alternative: Set a different index value for different sorting priorities
                sortIndex: 0, 

                // Sort in ascending order
                // Alternative: "desc" for descending order, undefined to disable sorting
                sortOrder: "asc" 
            },

            // Column for Age with initial sorting applied
            { 
                dataField: "Age", 
                caption: "Age", 

                // Sort order index (second priority)
                // Alternative: Change the order to prioritize another column
                sortIndex: 1, 

                // Sort in ascending order
                // Alternative: "desc" for descending order, undefined to disable sorting
                sortOrder: "asc" 
            },
        ],

        // Handle selection change event
        onSelectionChanged(selectedItems) {
            selectedItems.selectedRowsData.forEach((data) => {
                console.log(`${data["Name"]} Is Selected`);
            });
        },

        // Configure selection settings
        selection: {
            // Enable multiple row selection
            // Alternative: "single" for single selection, "none" to disable selection
            mode: "multiple",

            // Set the selection mode for the "Select All" checkbox
            // Alternative: "allPages" to select all rows across pages
            selectAllMode: "page",

            // Set when checkboxes should be visible
            // Alternative: "always" to always show checkboxes, "none" to hide checkboxes, "onClick" to showcheckboxes by click.
            showCheckBoxesMode: "onLongTap",

            // Allow selecting all rows
            // Alternative: true to enable selecting all rows
            allowSelectAll: false,
        },

        // Show borders around grid cells
        // Alternative: false to hide borders
        showBorders: true

    });
});

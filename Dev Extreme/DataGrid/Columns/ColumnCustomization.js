$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({

        // Assign the array as the data source
        dataSource: data,

        // Define the columns for the DataGrid
        columns: [
            // Column for ID
            { 
                dataField: "ID",
                caption: "ID",
                alignment: "center",
                allowEditing: false,
                allowExporting: true,
                allowFiltering: true,
                allowFixing: true,
                allowGrouping: true,
                allowReordering: true,
                allowResizing: true,
                allowSearch: true,
                allowSorting: true,
                cellTemplate(container, options) {
                    return $('<a>', { href: options.value, target: '_blank' }).text(options.value);
                },
                columnFixing: {
                    enabled: true
                },
                cssClass: "cell-highlighted",
                customizeText: function(cellInfo) {
                    return "This is " + cellInfo.value + " ID";
                },
                dataType: "number",
                encodeHtml: true,
                filterOperations: [ "=", "<>", "<", ">", "<=", ">=", "between" ],
                filterType: "include",
                // filterValue: 1,
                filterValues: [1,2],
                fixed:true,
                format: {
                    type: "percent",
                    precision: 2
                },
            
               

            },

            // Column for Name with initial sorting applied
            { 
                caption: "PersonInfo", 
                alignment:"center",
                columns:["Name","Age"],

                
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
                groupCellTemplate: function(element, options) {
                    element.text("Hello "+options.value);
                },
                
                groupIndex: 0,

                // Sort order index (second priority)
                // Alternative: Change the order to prioritize another column
                sortIndex: 1, 

                // Sort in ascending order
                // Alternative: "desc" for descending order, undefined to disable sorting
                sortOrder: "asc" 
            },
        ],

        headerFilter: {
            allowSearch: true,
            searchTimeout: 1000,
            visible: true,
            width: 500,
        },

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
            // Alternative: "always" to always show checkboxes, "none" to hide checkboxes
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

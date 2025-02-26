$(() => {
    var customIDData = [1, 2, 3, 4];

    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({

        // Assign the array as the data source
        // Alternative: Can use an API endpoint or another data source type
        dataSource: data2,

        // Configures the column chooser settings
        columnChooser: {

            // Enables or disables the column chooser
            // Alternative: false (Disables column chooser)
            enabled: true,

            // Enables or disables search in the column chooser
            // Alternative: false (Disables search)
            allowSearch: true,

            // Defines the selection mode in the column chooser
            // Alternative: 'dragAndDrop' (Allows drag-and-drop selection)
            mode: 'select'
        },
    

        // Define the columns for the DataGrid
        columns: [

            {
                // Field name from the data source
                dataField: "ID",

                // Column header name
                caption: "ID",

                // Text alignment in column cells
                alignment: "center",

                // Allows or disables editing
                // Alternative: true (Allows editing)
                allowEditing: false,

                // Allows or prevents exporting
                // Alternative: false (Prevents exporting)
                allowExporting: true,

                // Enables or disables filtering
                // Alternative: false (Disables filtering)
                allowFiltering: true,

                // Enables or disables column fixing
                // Alternative: false (Disables fixing)
                allowFixing: true,

                // Enables or disables column grouping
                // Alternative: false (Disables grouping)
                allowGrouping: true,

                // Enables or disables column reordering
                // Alternative: false (Disables column reordering)
                allowReordering: true,

                // Enables or disables column resizing
                // Alternative: false (Disables column resizing)
                allowResizing: true,

                // Enables or disables searching in this column
                // Alternative: false (Disables search)
                allowSearch: true,

                // Enables or disables sorting
                // Alternative: false (Disables sorting)
                allowSorting: true,

                // Custom cell template to display values as links
                cellTemplate(container, options) {
                    return $('<a>', { href: options.value, target: '_blank' }).text(options.value);
                },

                // Enables or disables column fixing
                columnFixing: {
                    enabled: true // Alternative: false (Disables fixing for this column)
                },

                // Adds a custom CSS class
                cssClass: "cell-highlighted",

                // Customizes the displayed text in the cell
                customizeText: function (cellInfo) {
                    return "This is " + cellInfo.value + " ID";
                },

                // Defines the column data type
                // Alternative: "string", "date", "boolean"
                dataType: "number",

                // Enables or disables HTML encoding
                // Alternative: false (Disables encoding)
                encodeHtml: true,

                // Available filter operations
                filterOperations: ["=", "<>", "<", ">", "<=", ">=", "between"],

                // Defines the filter type
                // Alternative: "exclude" (Excludes values instead of including)
                filterType: "include",

                // Predefined filter values
                filterValues: [1, 2],

                // Fixes the column
                // Alternative: false (Column is not fixed)
                fixed: true,

                // Defines the column format
                format: {
                    // Alternative: "currency", "fixedPoint"
                    type: "percent",

                    // Defines precision for numerical values
                    precision: 2
                },

                // Configures the header filter options
                headerFilter: {
                    dataSource: [
                        {
                            text: "Less than 5",
                            value: ["ID", "<", 5]
                        },
                        {
                            text: "More than 7",
                            value: ["ID", ">", 7]
                        }
                    ]
                },

                // Sets the minimum column width
                minWidth: 100,

                // Unique column name
                name: "ID",

                // Shows or hides the column in the column chooser
                // Alternative: false (Hides in column chooser)
                showInColumnChooser: true
            },

            {
                // Column header name
                caption: "PersonInfo",

                // Text alignment
                alignment: "center",

                // Defines sub-columns
                columns: ["FirstName", "LastName"],

                // Configures the header filter search mode
                headerFilter: {
                    // Alternative: "contains", "endswith"
                    searchMode: "startswith"
                },

                // Sorting priority index (lower value = higher priority)
                sortIndex: 0,

                // Defines the sorting order
                // Alternative: "desc" (Descending), undefined (No sorting)
                sortOrder: "asc"
            },

            {
                // Field name from the data source
                dataField: "Age",

                // Column header name
                caption: "Age",

                // Custom group cell template
                groupCellTemplate: function (element, options) {
                    element.text("Hello " + options.value);
                },

                // Sorting priority index
                sortIndex: 1,

                // Defines the sorting order
                // Alternative: "desc", undefined
                sortOrder: "asc"
            },

            {
                // Column header name
                caption: "Options",

                // Defines the column as a button column
                type: 'buttons',

                // Column width
                width: 110,

                // Defines the action buttons
                buttons: [
                    {
                        hint: 'Edit',
                        icon: 'edit',
                        onClick(e) {
                            console.log("Edit");
                        }
                    },
                    {
                        hint: 'Delete',
                        icon: 'trash',
                        onClick(e) {
                            console.log("Delete");
                        }
                    },
                    {
                        hint: 'Clone',
                        icon: 'copy',
                        onClick(e) {
                            console.log("Copy");
                        }
                    }
                ]
            }
        ],

        // Customizes the column widths
        customizeColumns: function (columns) {
            columns[0].width = 500;
            columns[2].width = 210;
            columns[3].width = 100;
            columns[4].width = 100;
        },

        // Defines column resizing mode
        // Alternative: "nextColumn" (Resizes next column)
        columnResizingMode: "widget",

        // Configures the header filter
        headerFilter: {
            // Enables or disables search in the header filter
            // Alternative: false (Disables search)
            allowSearch: true,

            // Defines the delay before searching (in milliseconds)
            searchTimeout: 1000,

            // Shows or hides the header filter
            // Alternative: false (Hides header filter)
            visible: true,

            // Defines the width of the header filter
            width: 500
        },

        // Configures the search panel
        searchPanel: {
            // Shows or hides the search panel
            // Alternative: false (Disables search panel)
            visible: true
        },

        // Shows or hides borders around grid cells
        // Alternative: false (Hides borders)
        showBorders: true
    });
});
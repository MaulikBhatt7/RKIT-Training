$(() => {
    let apiUrl = "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees"; // API URL for CRUD operations
    let editModes = ["row", "batch", "cell", "form", "popup"]; // Different editing modes available
    let selectedMode = "row"; // Default editing mode

    // Initialize DropDownBox for selecting editing mode
    $("#editModeSelector").dxDropDownBox({
        value: selectedMode, // Set default value
        placeholder: "Select Editing Mode", // Placeholder text
        displayExpr: (item) => item, // Display the item as it is
        valueExpr: "mode", // Use the mode as the value
        showClearButton: false, // Do not show clear button
        openOnFieldClick: true, // Open dropdown on field click
        contentTemplate: function (e) {
            let list = $("<div>").dxList({
                dataSource: editModes, // Data source is the list of editing modes
                selectionMode: "single", // Allow single selection only
                selectedItem: selectedMode, // Set default selected item
                onItemClick: function (event) {
                    let selectedValue = event.itemData; // Get the selected value
                    e.component.option("value", selectedValue); // Update DropDownBox value
                    selectedMode = selectedValue; // Update selected mode
                    renderGrid(selectedValue); // Re-render the grid with new mode
                    e.component.close(); // Close the DropDownBox
                }
            });
            return list;
        }
    });

    // Define CustomStore for handling AJAX CRUD operations
    var dataStore = new DevExpress.data.CustomStore({
        key: "id", // Define the key field

        // Load data from API
        load() {
            return $.ajax({
                url: apiUrl,
                dataType: "json",
            }).fail(() => {
                throw new Error("Data Loading Error");
            });
        },

        // Insert new data
        insert(values) {
            return $.ajax({
                url: apiUrl,
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            }).done((data) => {
                console.log("Inserted:", data);
            });
        },

        // Update existing data
        update(key, values) {
            return $.ajax({
                url: `${apiUrl}/${key}`,
                method: "PUT",
                data: JSON.stringify(values),
                contentType: "application/json"
            }).done((data) => {
                console.log("Updated:", data);
            });
        },

        // Delete data
        remove(key) {
            return $.ajax({
                url: `${apiUrl}/${key}`,
                method: "DELETE"
            }).done(() => {
                console.log("Deleted:", key);
            });
        }
    });

    // Function to render the DataGrid
    function renderGrid(editingMode) {
        $("#gridContainer").dxDataGrid({
            dataSource: dataStore, // Assign the data source
            keyExpr: "id", // Define the key field
            repaintChangesOnly: true, // Optimize UI updates
            columns: [
                { dataField: "id", caption: "ID", allowEditing: false, alignment: "center" }, // ID column (non-editable)
                {
                    dataField: "name",
                    caption: "Name",
                    validationRules: [{ type: "required", message: "Name is required" }], // Validation rule for Name field
                    alignment: "center",
                    sortIndex: 0, 
                    sortOrder: "asc" // Default sorting by Name in ascending order
                },
                {
                    dataField: "salary",
                    caption: "Salary",
                    dataType: "number",
                    format: "currency",
                    validationRules: [{ type: "required", message: "Salary is required" }], // Validation rule for Salary field
                    alignment: "center"
                }
            ],
            // Editing configuration
            editing: {
                mode: editingMode, // Set the editing mode dynamically
                allowUpdating: true, // Enable row update functionality
                allowAdding: true, // Enable row addition
                allowDeleting: true, // Enable row deletion
                useIcons: true, // Show editing icons
                refreshMode: "full", // Refresh mode options: full, reshape, repaint
                selectTextOnEditStart: true, // Select text on edit start
                startEditAction: "dblClick" // Editing starts on double-click
            },
            paging: { pageSize: 10 }, // Set pagination with 10 rows per page
            onRowUpdating: function (e) {
                console.log("Row Updating", e);
            },
            onRowInserted: function (e) {
                console.log("Row Inserted", e);
            },
            onRowRemoved: function (e) {
                console.log("Row Removed", e);
            },

            // Configure the filter panel settings
            filterPanel: {
                filterEnabled: true, // Enable filtering
                visible: true, // Show the filter panel
                text: {
                    createFilter: "Create your filter" // Custom text for filter creation
                }
            },

            // Configure summary for data aggregation
            summary: {
                totalItems: [
                    {
                        column: "Salary", // Define the column for aggregation
                        summaryType: "sum", // Sum of Salary
                        displayFormat: "Total Salary: ${0}" // Display format for total salary
                    },
                ]
            },
        });
    }

    // Initial render of DataGrid with default editing mode
    renderGrid("row");
});

$(() => {
    let apiUrl = "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees"; // API URL for CRUD operations
    let editModes = ["row", "batch", "cell", "form", "popup"]; // Different editing modes available
    let selectedMode = "row"; // Default editing mode

    // DropDownBox for selecting editing mode
    $("#editModeSelector").dxDropDownBox({
        value: selectedMode,
        placeholder: "Select Editing Mode",
        displayExpr: (item) => item, // Display the item as it is
        valueExpr: "mode", // Use the mode as the value
        showClearButton: false,
        openOnFieldClick: true,
        contentTemplate: function (e) {
            let list = $("<div>").dxList({
                dataSource: editModes, // Data source is the list of editing modes
                selectionMode: "single", // Single selection mode
                selectedItem: selectedMode, // Default selected item
                onItemClick: function (event) {
                    let selectedValue = event.itemData; // Get the selected value
                    e.component.option("value", selectedValue); // Set the DropDownBox value
                    selectedMode = selectedValue; // Update the selected mode
                    renderGrid(selectedValue); // Re-render the grid with the new mode
                    e.component.close(); // Close the DropDownBox
                }
            });
            return list;
        }
    });

    // Define CustomStore for AJAX CRUD operations
    var dataStore = new DevExpress.data.CustomStore({
        key: "id",

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
            dataSource: dataStore, // Set the data source for the grid
            keyExpr: "id", // Define the key expression for the grid
            repaintChangesOnly: true, // Repaint only the changed rows
            columns: [
                { dataField: "id", caption: "ID", allowEditing: false, alignment: "center" }, // ID column
                {
                    dataField: "name",
                    caption: "Name",
                    validationRules: [{ type: "required", message: "Name is required" }], // Validation rule for name
                    alignment: "center"
                },
                {
                    dataField: "salary",
                    caption: "Salary",
                    dataType: "number",
                    format: "currency",
                    validationRules: [{ type: "required", message: "Salary is required" }], // Validation rule for salary
                    alignment: "center"
                }
            ],
            // Editing options
            editing: {
                mode: editingMode, // Set the editing mode (row, batch, cell, form, popup)
                allowUpdating: true, // Allow updating rows
                allowAdding: true, // Allow adding new rows
                allowDeleting: true, // Allow deleting rows
                useIcons: true, // Use icons for editing buttons
                refreshMode: "full", // Full refresh mode. other: reshape, repaint.
                selectTextOnEditStart: true, // Select text when editing starts
                startEditAction: "dblClick" // Start editing on double-click
            },
            paging: { pageSize: 10 }, // Set the page size to 10 rows
            onRowUpdating: function (e) {
                console.log("Row Updating", e);
            },
            onRowInserted: function (e) {
                console.log("Row Inserted", e);
            },
            onRowRemoved: function (e) {
                console.log("Row Removed", e);
            }
        });
    }

    // Initial render with default mode
    renderGrid("row");
});

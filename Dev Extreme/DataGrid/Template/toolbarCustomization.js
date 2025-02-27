$(() => {
    $("#dataGrid").dxDataGrid({
        // Use data2 as the data source
        dataSource: data2,
        keyExpr: "ID",
        showBorders: true,
        columnAutoWidth: true,

        // Grouping settings
        grouping: { 
            autoExpandAll: true 
        },

        // Show loading indicator
        loadPanel: { 
            enabled: true 
        },

        // Define data columns
        columns: [
            { dataField: "ID", caption: "ID" },
            { dataField: "FirstName", caption: "First Name" },
            { dataField: "LastName", caption: "Last Name" },
            { dataField: "Age", caption: "Age" }
        ],

        // Prepare toolbar
        onToolbarPreparing: function(e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "before",
                    // Display total record count
                    template: function () {
                        return $("<div>")
                            .addClass("informer")
                            .append(
                                $("<div>").addClass("count").text(data2.length),
                                $("<span>").text(" Total Records")
                            );
                    }
                },
                {
                    location: "before",
                    widget: "dxSelectBox",
                    options: {
                        width: 200,
                        items: [
                            { value: "FirstName", text: "Group by First Name" },
                            { value: "LastName", text: "Group by Last Name" },
                            { value: "Age", text: "Group by Age" }
                        ],
                        displayExpr: "text",
                        valueExpr: "value",
                        placeholder: "Select Grouping",
                        // Handle grouping selection
                        onValueChanged: function (e) {
                            dataGrid.clearGrouping();
                            dataGrid.columnOption(e.value, "groupIndex", 0);
                        }
                    }
                },
                {
                    location: "before",
                    widget: "dxButton",
                    options: {
                        text: "Collapse All",
                        // Handle collapse/expand button click
                        onClick: function (e) {
                            const expanding = e.component.option("text") === "Expand All";
                            dataGrid.option("grouping.autoExpandAll", expanding);
                            e.component.option("text", expanding ? "Collapse All" : "Expand All");
                        }
                    }
                },
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        icon: "refresh",
                        text: "Refresh",
                        // Refresh data grid content
                        onClick: function () {
                            dataGrid.refresh();
                        }
                    }
                },
                {
                    location: "after",
                    widget: "dxButton",
                    options: {
                        icon: "columnchooser",
                        text: "Columns",
                        // Show column chooser
                        onClick: function () {
                            dataGrid.showColumnChooser();
                        }
                    }
                }
            );
        },
    }).dxDataGrid("instance");
});
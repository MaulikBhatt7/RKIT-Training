$(() => {
    $("#dataGrid").dxDataGrid({
        dataSource: data, // Using your existing data
        
        allowColumnReordering: false,
        showBorders: true,

        grouping: {
            allowCollapsing: true,
            autoExpandAll: true,
            contextMenuEnabled: true,
            expandMode: "rowClick",
        },

        groupPanel: {
            allowColumnDragging: true,
            emptyPanelText: "Drag Column Here To Group",
            visible: true,
        },

        columns: [
            { dataField: "name", caption: "Name" },
            { 
                dataField: "age", 
                caption: "Age",
                groupIndex: 0, // Set grouping by age
                groupCellTemplate: function(container, options) {
                    container.addClass("merged-group-cell");
                    container.text("Age: " + options.value);
                }
            },
            { dataField: "salary", caption: "Salary" }
        ]
    });
});

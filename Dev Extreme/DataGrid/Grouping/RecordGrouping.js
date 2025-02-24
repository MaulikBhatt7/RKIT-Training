$(() => {
    // Initialize DevExtreme DataGrid with the custom data store
    $("#dataGrid").dxDataGrid({
        // Assign the array as the data source
        dataSource: data, 
        
        // Disable column reordering
        allowColumnReordering: false,
        
        grouping: {
            // Allow collapsing of grouped rows
            allowCollapsing: true,
            
            // Automatically expand all groups
            autoExpandAll: true,
            
            // Enable context menu for grouping
            contextMenuEnabled: true,
            
            // Set grouping expand mode to "rowClick"
            expandMode: "rowClick", // Can also be set to "buttonClick"
        },
        
        groupPanel: {
            // Allow dragging of columns to the group panel
            allowColumnDragging: true,
            
            // Text to display when the group panel is empty
            emptyPanelText: "Drag Column Here To Group",
            
            // Make the group panel visible
            visible: true,
        },
    });
});
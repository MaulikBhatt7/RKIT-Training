$(() => {
    $("#treeViewContainer").dxTreeView({
        
        // The data source for the tree view
        items: menuData2, // Alternative: Use 'dataSource' for dynamic data fetching
        
        // Defines the structure of the data
        dataStructure: "tree", // Alternative: "plain" (for a flat data structure)
        
        // Specifies the unique identifier field
        keyExpr: "id",
        
        // Specifies the parent identifier field for hierarchical relationships
        parentIdExpr: "parentId",
        
        // Defines which field will be displayed as node text
        displayExpr: "name",
        
        // Specifies whether a node has child items
        hasItemsExpr: "items", // Alternative: Can be inferred automatically if using 'dataSource'
        
        // Enables checkboxes for selection
        showCheckBoxesMode: "normal", // Alternatives: "none", "selectAll", "multiple"
        
        // Enables search functionality
        searchEnabled: true,
        
        // Defines the search behavior
        searchMode: "contains", // Alternatives: "startswith", "equals"
        
        // Customizes the search input options
        searchEditorOptions: { placeholder: "Search items..." },
        
        // Expands nodes recursively on load
        expandNodesRecursive: true, // Alternative: false (to expand only top-level nodes)
        
        // Ensures selection propagates to child nodes
        selectNodesRecursive: true, // Alternative: false (to select only the clicked node)
        
        // Enables an option to expand all nodes at once
        expandAllEnabled: true, // Alternative: false (to disable expand-all functionality)
        
        // Allows selection by clicking the node
        selectByClick: true, // Alternative: false (selection only via checkboxes if enabled)
        
        // Defines the selection mode
        selectionMode: "multiple", // Alternatives: "single", "none"
        
        // Enables virtual scrolling for performance optimization
        virtualModeEnabled: true, // Alternative: false (loads all items at once)
        
        // Specifies the event that triggers node expansion
        expandEvent: "dblclick", // Alternative: "click"
        
        // Event triggered when selection changes
        onItemSelectionChanged: (e) => {
            console.log("Selection changed: ", e.node);
        },
        
        // Event triggered when a node is expanded
        onItemExpanded: (e) => {
            console.log("Expanded: ", e.node.text);
        },
        
        // Event triggered when a node is collapsed
        onItemCollapsed: (e) => {
            console.log("Collapsed: ", e.node.text);
        },
        
        // Event triggered when the TreeView is fully rendered
        onContentReady: () => {
            console.log("TreeView Loaded");
        },
        
        // Event triggered when the TreeView is initialized
        onInitialized: () => {
            console.log("TreeView Initialized");
        },
        
        // Event triggered when an option is changed dynamically
        onOptionChanged: (e) => {
            console.log("Option changed: ", e);
        }
    });
});
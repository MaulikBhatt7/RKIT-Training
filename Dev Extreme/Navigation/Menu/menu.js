$(() => {
    
    $("#menuContainer").dxMenu({
        
        // The data source for the menu
        items: menuData, 
        
        // Enables visual feedback when items are pressed
        // activeStateEnabled: true, // Alternative: false (disable active state effect)
        
        // Hides submenus when the mouse leaves the menu area
        hideSubmenuOnMouseLeave: true, // Alternative: false (keep submenus visible)
        
        // Defines which field will be displayed as menu text
        displayExpr: 'name',
        
        // Enables responsive behavior for small screens
        adaptivityEnabled: true, // Alternative: false (disable adaptive behavior)
        
        // Defines menu orientation (horizontal by default)
        // orientation: 'vertical', // Alternative: 'horizontal' (default)
        
        // Defines how the first submenu is displayed
        showFirstSubmenuMode: "onHover", // Alternative: "onClick"
        
        // Defines how other submenus are displayed
        showSubmenuMode: "onHover", // Alternative: "onClick"
        
        // Event triggered when a menu item is clicked
        onItemClick: (e) => {
            $("#toast").dxToast({
                message: "Clicked: " + e.itemData.name,
                type: "success",
                displayTime: 2000
            }).dxToast("show");
        },
        
        // Event triggered before submenu starts hiding
        onSubmenuHiding: () => {
            console.log("Hiding...")
        },
        
        // Event triggered before submenu starts showing
        onSubmenuShowing: () => {
            console.log("Showing...")
        },
        
        // Event triggered after submenu is fully shown
        onSubmenuShown: () => {
            console.log("Shown...")
        },
        
        // Event triggered after submenu is fully hidden
        onSubmenuHidden: () => {
            console.log("Hidden...")
        },
    });
});
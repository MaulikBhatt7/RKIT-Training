$(() => {
    
    $("#menuContainer").dxMenu({
        dataSource: menuData,
        hideSubmenuOnMouseLeave: true,
        displayExpr: 'name',
        adaptivityEnabled: true,
        aniamtion: {
            hide: { type: 'slide', from: 1, to: 0, duration: 100 },
            show: 1
        },
        orientation: 'vertical',
        onSubmenuHiding: () => {
            console.log("Hiding...")
        },
        onSubmenuShowing: () => {
            console.log("Showing...")
        },
        onSubmenuShown: () => {
            console.log("Shown...")
        },
        onSubmenuHidden: () => {
            console.log("Hidden...")
        },
        showSubmenuMode: 'onHover'
    });

});
# Navigation Documentation

## Menu

### Overview

DevExtreme Menu component provides a flexible and customizable way to create menus in your application. These components include various options and methods to enhance the user experience.

#### Important Options

- `orientation`: Specifies the orientation of the menu. Possible values are "horizontal" and "vertical".
- `submenuDirection`: Specifies the direction in which submenus are displayed. Possible values are "auto", "leftOrTop", and "rightOrBottom".
- `showFirstSubmenuMode`: Configures the mode in which the first submenu is shown. It includes the following options:
  - `name`: Specifies the mode name. Possible values are "onClick" and "onHover".
  - `delay`: Specifies the delay for showing and hiding the submenu.

#### Methods

- `getItem(index)`: Returns the item at the specified index.
- `getSubMenuInstance(rootElement)`: Returns the submenu instance for the specified root element.

#### Events

- `onSubmenuShowing`: Raised before a submenu is shown.
- `onSubmenuShown`: Raised after a submenu is shown.
- `onSubmenuHiding`: Raised before a submenu is hidden.
- `onSubmenuHidden`: Raised after a submenu is hidden.

### Usage Example

```javascript
$(function () {
  $("#menu").dxMenu({
    dataSource: menuItems,
    orientation: "horizontal",
    submenuDirection: "auto",
    onSubmenuShowing: function (e) {
      console.log("Submenu is showing");
    },
    onSubmenuShown: function (e) {
      console.log("Submenu is shown");
    },
    onSubmenuHiding: function (e) {
      console.log("Submenu is hiding");
    },
    onSubmenuHidden: function (e) {
      console.log("Submenu is hidden");
    },
  });
});
```

## TreeView

### Overview

DevExtreme TreeView component provides a flexible and customizable way to create tree views in your application. These components include various options and methods to enhance the user experience.

#### Important Options

- `dataSource`: Configures the data source for the tree view.
- `searchEnabled`: Enables the search functionality within the tree view.
- `showCheckBoxesMode`: Configures the visibility of checkboxes in the tree view. Possible values are "none", "normal", and "selectAll".

#### Methods

- `getNodes()`: Returns all nodes in the tree view.
- `getNode(index)`: Returns the node at the specified index.
- `selectItem(itemElement)`: Selects the specified item element.

#### Events

- `onItemSelectionChanged`: Raised when an item is selected or unselected.
- `onItemExpanded`: Raised when an item is expanded.
- `onItemCollapsed`: Raised when an item is collapsed.

### Usage Example

```javascript
$(function () {
  $("#treeview").dxTreeView({
    dataSource: treeItems,
    searchEnabled: true,
    showCheckBoxesMode: "normal",
    onItemSelectionChanged: function (e) {
      console.log("Item selection changed");
    },
    onItemExpanded: function (e) {
      console.log("Item expanded");
    },
    onItemCollapsed: function (e) {
      console.log("Item collapsed");
    },
  });
});
```

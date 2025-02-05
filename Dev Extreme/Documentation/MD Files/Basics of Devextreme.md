# DevExtreme Basics:

DevExtreme is a comprehensive JavaScript framework for building responsive web applications. It provides a rich set of UI widgets and data visualization components that support multiple front-end frameworks such as jQuery, Angular, React, and Vue.

This guide focuses on DevExtreme with jQuery, covering all the fundamental topics in great detail.

## 1. Introduction to DevExtreme

### What is DevExtreme?

DevExtreme is a set of UI components designed to work with modern web applications. It includes:

- Data Grid, TreeList, and Pivot Grid for handling data.
- Charts, Gauges, and Maps for data visualization.
- Form components like DatePickers, SelectBoxes, and TextBoxes.
- Layout widgets such as Tabs, Accordions, and Panels.

### Why Use DevExtreme?

- Cross-browser & cross-platform support (works on desktops and mobile devices).
- Highly customizable with themes and templates.
- Integration with jQuery, Angular, React, and Vue.
- Rich data binding support, including remote and local data sources.
- Built-in accessibility (ARIA, keyboard navigation, screen reader support).

## 2. Installation – NuGet Package

Since you are using DevExtreme with jQuery via CDN, NuGet is not required for front-end dependencies. However, if you want to manage it within an ASP.NET project, you can install it via NuGet.

### Steps to Install DevExtreme via NuGet in an ASP.NET Project

1. Open Visual Studio.
2. Go to Tools → NuGet Package Manager → Manage NuGet Packages for Solution.
3. Search for `DevExtreme.Web` (Version 21.1.3).
4. Click Install.

### Alternative: Using DevExtreme via CDN (jQuery)

For direct inclusion in a jQuery-based web application, add the following CDN links in your HTML file:

```html
<!-- jQuery (required for DevExtreme) -->
<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

<!-- DevExtreme CSS -->
<link
  rel="stylesheet"
  href="https://cdn3.devexpress.com/jslib/latest/css/dx.light.css"
/>

<!-- DevExtreme JS -->
<script src="https://cdn3.devexpress.com/jslib/latest/js/dx.all.js"></script>
```

Now you can start using DevExtreme widgets.

## 3. Widget Basics - jQuery

### What is a Widget in DevExtreme?

A widget in DevExtreme is a reusable UI component that provides interactive functionality, such as grids, charts, and form inputs.

### Commonly Used Widgets

- `dxDataGrid` – Displays tabular data.
- `dxChart` – Creates visual data charts.
- `dxButton` – Renders a customizable button.
- `dxTextBox` – Input field for text.
- `dxSelectBox` – Dropdown selection control.

## 4. Create and Configure a Widget

### Creating a Widget in jQuery

You can create a DevExtreme widget using jQuery selectors.

**Example: Creating a Button widget**

```html
<div id="myButton"></div>

<script>
  $(function () {
    $("#myButton").dxButton({
      text: "Click Me",
      onClick: function () {
        alert("Button clicked!");
      },
    });
  });
</script>
```

- `#myButton` is the HTML container for the widget.
- `dxButton({...})` initializes a DevExtreme Button widget.
- `onClick` is an event handler that triggers an alert when clicked.

## 5. Get a Widget Instance

Sometimes, you need to access a widget’s instance to interact with it dynamically.

### Getting an Instance of a Widget

Use `.dxWidgetName("instance")` to retrieve a widget’s instance.

**Example:**

```javascript
var buttonInstance = $("#myButton").dxButton("instance");
console.log(buttonInstance);
```

This allows you to access the widget's methods and properties.

## 6. Get and Set Options

You can get or modify widget options dynamically.

### Getting an Option

```javascript
var buttonText = $("#myButton").dxButton("option", "text");
console.log(buttonText); // Output: Click Me
```

### Setting an Option

```javascript
$("#myButton").dxButton("option", "text", "New Text");
```

This updates the button text dynamically.

## 7. Call Methods

Widgets provide various methods for performing actions.

### Example: Calling a Method on `dxTextBox`

```html
<input type="text" id="myTextBox" />

<script>
  $(function () {
    $("#myTextBox").dxTextBox();

    // Set value using method
    $("#myTextBox").dxTextBox("option", "value", "Hello, DevExtreme!");
  });
</script>
```

`.dxTextBox("option", "value", "Hello, DevExtreme!")` updates the value of the text box.

## 8. Handle Events

Each widget has built-in events that you can handle.

### Example: Handling the `onValueChanged` Event

```html
<input type="text" id="nameBox" />

<script>
  $(function () {
    $("#nameBox").dxTextBox({
      value: "John Doe",
      onValueChanged: function (e) {
        console.log("New value: " + e.value);
      },
    });
  });
</script>
```

When the text value changes, the new value is logged in the console.

### List of Common Events

- `onClick` (for buttons)
- `onValueChanged` (for input fields)
- `onSelectionChanged` (for dropdowns)
- `onRowInserted` (for grids)
- `onOptionChanged` (for any widget)

## 9. Destroy a Widget

To remove a widget and free up memory, use `.dxWidgetName("dispose")`.

### Example: Destroying a Widget

```javascript
var textBox = $("#nameBox").dxTextBox("instance");

// Destroy the widget
textBox.dispose();

// Remove the HTML element
$("#nameBox").remove();
```

This:

- Disposes of the widget instance.
- Removes the element from the DOM.

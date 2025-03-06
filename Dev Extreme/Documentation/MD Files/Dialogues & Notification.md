# Dialogues & Notification Documentation

### Load Indicator

The Load Indicator component notifies users that a process is in progress.

#### Important Options

- `indicatorSrc`: Specifies a custom indicator image source.

#### Methods

- `show()`: Shows the load indicator.
- `hide()`: Hides the load indicator.

#### Events

- `onContentReady`: Raised when the content is ready.
- `onDisposing`: Raised before the widget is removed.

### Usage Example

```javascript
$(function () {
  $("#loadIndicator").dxLoadIndicator({
    indicatorSrc: "path/to/indicator.gif",
    onContentReady: function (e) {
      console.log("Content is ready");
    },
  });

  var loadIndicator = $("#loadIndicator").dxLoadIndicator("instance");
  loadIndicator.show();
});
```

### Load Panel

The Load Panel is a UI component notifying the viewer that a process is in progress.

#### Important Options

- `message`: Specifies the message displayed on the load panel.
- `shadingColor`: Specifies the shading color.
- `showIndicator`: Specifies whether to show the loading indicator.
- `showPane`: Specifies whether to show the pane.

#### Methods

- `show()`: Shows the load panel.
- `hide()`: Hides the load panel.

#### Events

- `onShowing`: Raised before the load panel is shown.
- `onShown`: Raised after the load panel is shown.
- `onHiding`: Raised before the load panel is hidden.
- `onHidden`: Raised after the load panel is hidden.

### Usage Example

```javascript
$(function () {
  $("#loadPanel").dxLoadPanel({
    message: "Loading...",
    shadingColor: "rgba(0,0,0,0.4)",
    showIndicator: true,
    showPane: true,
    onShowing: function (e) {
      console.log("Load panel is showing");
    },
  });

  var loadPanel = $("#loadPanel").dxLoadPanel("instance");
  loadPanel.show();
});
```

### Popup

The Popup component is a UI component that displays a modal window.

#### Important Options

- `title`: Specifies the title of the popup.
- `showTitle`: Specifies whether to show the title.
- `visible`: Specifies whether the popup is visible.
- `showCloseButton`: Specifies whether to show the close button.

#### Methods

- `show()`: Shows the popup.
- `hide()`: Hides the popup.

#### Events

- `onShowing`: Raised before the popup is shown.
- `onShown`: Raised after the popup is shown.
- `onHiding`: Raised before the popup is hidden.
- `onHidden`: Raised after the popup is hidden.

### Usage Example

```javascript
$(function () {
  var popupContentTemplate = function () {
    return $("<div>").text("Popup content");
  };

  $("#popup").dxPopup({
    title: "Information",
    contentTemplate: popupContentTemplate,
    width: 300,
    height: 200,
    showTitle: true,
    visible: false,
    showCloseButton: true,
    onShowing: function (e) {
      console.log("Popup is showing");
    },
  });

  var popup = $("#popup").dxPopup("instance");
  popup.show();
});
```

### Popover

The Popover component is a UI component that displays a small overlay window.

#### Important Options

- `position`: Specifies the position of the popover.
- `visible`: Specifies whether the popover is visible.

#### Methods

- `show()`: Shows the popover.
- `hide()`: Hides the popover.

#### Events

- `onShowing`: Raised before the popover is shown.
- `onShown`: Raised after the popover is shown.
- `onHiding`: Raised before the popover is hidden.
- `onHidden`: Raised after the popover is hidden.

### Usage Example

```javascript
$(function () {
  $("#popover").dxPopover({
    position: {
      my: "top center",
      at: "bottom center",
      of: "#button",
    },
    visible: false,
    onShowing: function (e) {
      console.log("Popover is showing");
    },
  });

  var popover = $("#popover").dxPopover("instance");
  $("#button").on("click", function () {
    popover.show();
  });
});
```

### Toast

The Toast component is a UI component that displays a notification message.

#### Important Options

- `message`: Specifies the message displayed in the toast.
- `type`: Specifies the type of the toast. Possible values are "info", "warning", "error", "success".
- `displayTime`: Specifies the time span in milliseconds during which the toast is visible.
- `position`: Specifies the position of the toast.

#### Methods

- `show()`: Shows the toast.
- `hide()`: Hides the toast.

#### Events

- `onShowing`: Raised before the toast is shown.
- `onShown`: Raised after the toast is shown.
- `onHiding`: Raised before the toast is hidden.
- `onHidden`: Raised after the toast is hidden.

### Usage Example

```javascript
$(function () {
  $("#toast").dxToast({
    message: "This is a toast notification",
    type: "info",
    displayTime: 2000,
    position: "top center",
    onShowing: function (e) {
      console.log("Toast is showing");
    },
  });

  var toast = $("#toast").dxToast("instance");
  toast.show();
});
```

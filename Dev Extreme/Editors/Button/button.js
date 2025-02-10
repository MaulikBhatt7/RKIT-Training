$(() => {
    // Initialize button with all properties
    $("#buttonContainer-main").dxButton({
        // Display text on button
        text: "All Properties",

        // Set custom attributes
        elementAttr: { class: "btn-demo" },

        // Disable or enable button
        disabled: false,

        // Enable focus state
        focusStateEnabled: true,

        // Specify height
        height: 50,

        // Specify hint on hover (tool-tip)
        hint: "Hello World",

        // Enable hover state
        hoverStateEnabled: true,

        // Icon for the button
        icon: "favorites",

        // Perform anything on content ready
        onContentReady: null,

        // Perform anything on disposing
        onDisposing: null,

        // Perform anything on initialization
        onInitialized: null,

        // On option changed event
        onOptionChanged: function (e) {
            if (e.name === "changedProperty") {
                // handle the property change here
            }
        },

        // Convert text right to left
        rtlEnabled: false,

        // Styling mode of the button
        stylingMode: "outlined", // contained

        // Specify number of element during tab
        tabIndex: 2,

        // Template for the button content
        template: "content",

        // Type of the button
        type: "default", // normal, success, danger

        // Behave like submit button
        useSubmitBehavior: false,

        // Visibility of the button
        visible: true,

        // Specify width
        width: 300,

        // On click event
        onClick: function () {
            alert("Hello world!");
        }
    });

    // Initialize button of type normal
    $("#buttonContainer-1").dxButton({
        // Type of the button
        type: "normal",

        // Display text on button
        text: "Normal Type",

        // Specify number of element during tab
        tabIndex: 1
    });

    // Initialize button of type default
    $("#buttonContainer-2").dxButton({
        // Type of the button
        type: "default",

        // Display text on button
        text: "Default Type"
    });

    // Initialize button of type success
    $("#buttonContainer-3").dxButton({
        // Type of the button
        type: "success",

        // Display text on button
        text: "Success Type"
    });

    // Initialize button of type danger and outlined mode
    $("#buttonContainer-4").dxButton({
        // Type of the button
        type: "danger",

        // Display text on button
        text: "Danger Type and Outlined Mode",

        // Styling mode of the button
        stylingMode: "outlined"
    });
});
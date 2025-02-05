$(() => {
    // Initialize the DropDownBox component with specified options
    $('#all-properties').dxDropDownBox({

        // Allow entering a custom value
        acceptCustomValue: true,

        // Set the shortcut key to focus on the component
        accessKey: 'D',

        // Enable active state on interaction
        activeStateEnabled: false,

        // Add custom buttons to the input field
        buttons: [{
            name: 'clear',
            icon: 'clear',
            onClick: () => {
                // Clear the value when the clear button is clicked
                $('#all-properties').dxDropDownBox('instance').clear();
            }
        }],

        // Define a custom template for the drop-down content
        contentTemplate: function (e) {
            var fruits = ["Apple", "Banana", "Cherry", "Mango", "Orange"];

            // Create a dxList component for selecting multiple items
            var list = $('<div>').dxList({
                dataSource: fruits,
                selectionMode: 'multiple', // ✅ Multiple selection enabled
                searchEnabled: true,
                itemTemplate: function (data) {
                    return $('<div>').text(data);
                },
                onSelectionChanged: function (selectionEvent) {
                    // Get all selected values
                    var selectedValues = selectionEvent.component.option('selectedItems');

                    // Set selected values in the drop-down box
                    e.component.option('value', selectedValues.join(', ')); // Join for display

                    //e.component.close();
                },
                showSelectionControls: true // ✅ Shows checkboxes for multiple selection
            });

            // Append the list to the drop-down content area
            e.component.content().append(list);
        },

        // Enable search in the drop-down
        searchEnabled: true,

        // Render the drop-down content immediately
        deferRendering: false,

        // Enable the component
        disabled: false,

        // Specify the expression used to display values
        displayExpr: function (item) {
            return item ? item : "";
        },

        // Customize the displayed value text
        displayValueFormatter: function (value) {
            return 'Selected: ' + value;
        },

        // Define a custom template for the drop-down button
        dropDownButtonTemplate: function () {
            return $("<span>").addClass("custom-button").text("▼");
        },

        //// Set options for the drop-down field
        //dropDownOptions: {
        //    width: 300,
        //    height: 200
        //},

        // Specify custom attributes for the component container
        elementAttr: {
            class: 'custom-drop-down'
        },

        //// Set the height of the component
        //height: 40,

        // Set a hint text for the component
        hint: 'Choose an option',

        // Enable hover state
        hoverStateEnabled: true,

        // Set attributes for the input element
        inputAttr: {
            placeholder: 'Enter value'
        },

        // Indicate that the value is valid
        isValid: true,

        // Set a label for the component
        label: 'Select Fruit',

        // Set the display mode for the label
        labelMode: 'floating',

        // Set the maximum length for the input
        maxLength: 20,

        // Set the name attribute for the underlying HTML element
        name: 'fruit-selector',

        // Define a function for the change event
        onChange: function (e) {
            console.log('Value changed: ' + e.value);
        },

        // Define a function for the closed event
        onClosed: function () {
            console.log('Drop-down closed');
        },

        // Define a function for the copy event
        onCopy: function () {
            console.log('Text copied');
        },

        // Define a function for the cut event
        onCut: function () {
            console.log('Text cut');
        },

        // Define a function for the disposing event
        onDisposing: function () {
            console.log('Component is being disposed');
        },

        // Define a function for the Enter key event
        onEnterKey: function () {
            console.log('Enter key pressed');
        },

        // Define a function for the focus in event
        onFocusIn: function () {
            console.log('Focused');
        },

        // Define a function for the focus out event
        onFocusOut: function () {
            console.log('Lost focus');
        },

        // Define a function for the initialized event
        onInitialized: function (e) {
            console.log('Component initialized');
        },

        // Define a function for the input event
        onInput: function (e) {
            console.log('Input changed: ' + e.value);
        },

        // Define a function for the key down event
        onKeyDown: function () {
            console.log('Key down');
        },

        // Define a function for the key up event
        onKeyUp: function () {
            console.log('Key up');
        },

        // Define a function for the opened event
        onOpened: function () {
            console.log('Drop-down opened');
        },

        // Define a function for the option changed event
        onOptionChanged: function (e) {
            console.log('Option changed: ' + e.name);
        },

        // Define a function for the paste event
        onPaste: function () {
            console.log('Text pasted');
        },

        // Define a function for the value changed event
        onValueChanged: function (e) {
            console.log('Value changed: ' + e.value);
        },

        // Indicate that the drop-down is open
        opened: false,

        // Allow opening the drop-down by clicking the text field
        openOnFieldClick: true,

        // Set a placeholder text
        placeholder: 'Select a value',

        // Indicate that the component is not read-only
        readOnly: false,

        // Disable right-to-left representation
        rtlEnabled: false,

        // Show the Clear button
        showClearButton: true,

        // Show the drop-down button
        showDropDownButton: true
    });
});
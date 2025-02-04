$(() => {

    // Creating a CheckBox with all available properties in DevExtreme v21.1
    var allPropertiesCheckBox = $('#all-properties').dxCheckBox({

        // Sets a shortcut key for accessibility
        accessKey: 'm',

        // Enables active state styling
        activeStateEnabled: true,

        // Checkbox is enabled
        disabled: false,

        // Additional attributes for the root element
        elementAttr: {},

        // Disables three-state mode (true, false, indeterminate)
        enableThreeStateBehavior: false,

        // Enables focus styling
        focusStateEnabled: true,

        // Tooltip hint text
        hint: "Click Here",

        // Enables hover styling
        hoverStateEnabled: true,

        // Validation status, initially set to invalid
        isValid: false,

        // Name attribute for form submission
        name: "",

        // Event triggered when content is ready+
        onContentReady: (e) => console.log("Event: contentReady triggered", e),

        // Event triggered when the component is initialized
        onInitialized: (e) => console.log("Event: initialized triggered", e),

        // Event triggered when an option is changed
        onOptionChanged: (e) => console.log("Event: optionChanged triggered", e),

        // Event triggered when value changes
        onValueChanged: (e) => console.log("Event: valueChanged triggered", e),

        // Event triggered when the component is disposed
        onDisposing: (e) => console.log("Event: disposing triggered", e),

        // Makes the checkbox read-only (cannot be changed by user)
        readOnly: true,

        // Enables right-to-left support (false means left-to-right)
        rtlEnabled: false,

        // Specifies the tab order of the component
        tabIndex: 0,

        // Text label for the checkbox
        text: "This is Text",

        // Defines how validation messages are displayed
        validationMessageMode: "auto",

        // Specifies where the validation message should appear
        validationMessagePosition: "bottom",

        // Specifies the validation status
        validationStatus: "valid",

        // Initial value (unchecked)
        value: false,

        // Determines visibility of the checkbox
        visible: true

    }).dxCheckBox('instance');

    // Creating a checked CheckBox
    var checkedCheckBox = $('#checked').dxCheckBox({

        // Sets an accessibility shortcut key
        accessKey: '+',

        // Checkbox is checked initially
        value: true,

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Checked' }

    }).dxCheckBox('instance');

    // Creating an unchecked CheckBox
    var uncheckedCheckBox = $('#unchecked').dxCheckBox({

        // Checkbox is unchecked initially
        value: false,

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Unchecked' }

    }).dxCheckBox('instance');

    // Creating an indeterminate CheckBox
    var indeterminateCheckBox = $('#indeterminate').dxCheckBox({

        // Checkbox is in an indeterminate state initially
        value: null,

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Indeterminate' }

    }).dxCheckBox('instance');

    // Creating a CheckBox with three-state mode enabled
    var threeStateCheckBox = $('#threeStateMode').dxCheckBox({

        // Enables three-state behavior
        enableThreeStateBehavior: true,

        // Checkbox is in an indeterminate state initially
        value: null,

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Three state mode' }

    }).dxCheckBox('instance');

    // Creating a CheckBox with an event handler
    var handlerCheckBox = $('#handler').dxCheckBox({

        // Checkbox is in an indeterminate state initially
        value: null,

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Handle value change' },

        // Event triggered when value changes
        onValueChanged(data) {
            disabledCheckBox.option('value', data.value);
            console.log("Handler CheckBox Value Changed:", data.value);
        }

    }).dxCheckBox('instance');

    // Creating a disabled CheckBox
    var disabledCheckBox = $('#disabled').dxCheckBox({

        // Checkbox is in an indeterminate state initially
        value: null,

        // Disables the checkbox
        disabled: true,

        // Tooltip hint text
        hint: "This is disabled",

        // Sets an ARIA label for accessibility
        elementAttr: { 'aria-label': 'Disabled' }

    }).dxCheckBox('instance');

    // Creating a CheckBox with a text label
    var withTextCheckBox = $('#withText').dxCheckBox({

        // Checkbox is checked initially
        value: true,

        // Sets a label for the checkbox
        text: 'Label'

    }).dxCheckBox('instance');

    // Demonstrating Methods

    // Postpone updates
    allPropertiesCheckBox.beginUpdate();
    allPropertiesCheckBox.option('text', "Updated in beginUpdate()");
    console.log("beginUpdate() called...");

    // Resume updates
    allPropertiesCheckBox.endUpdate();
    console.log("endUpdate() called, UI refreshed.");

    // Focus the checkbox after 2 seconds
    setTimeout(() => {
        allPropertiesCheckBox.focus();
        console.log("focus() method called.");
    }, 2000);

    // Reset CheckBox to default value after 4 seconds
    setTimeout(() => {
        allPropertiesCheckBox.reset();
        console.log("reset() method called, value reset to default.");
    }, 4000);

    // Set a new value dynamically after 6 seconds
    setTimeout(() => {
        allPropertiesCheckBox.option('value', true);
        console.log("option() method called: value set to true.");
    }, 6000);

    // Clear the value after 8 seconds
    setTimeout(() => {
        allPropertiesCheckBox.reset();
        console.log("reset() method called, value reset.");
    }, 8000);

    // Repaint component after 10 seconds
    setTimeout(() => {
        allPropertiesCheckBox.repaint();
        console.log("repaint() method called, UI refreshed.");
    }, 10000);

    // Register a key handler for the "Enter" key
    allPropertiesCheckBox.registerKeyHandler("enter", function () {
        console.log("Enter key pressed.");
    });

    // Subscribe to an event dynamically
    allPropertiesCheckBox.on("valueChanged", function (e) {
        console.log("Dynamically subscribed: Value changed to", e.value);
    });

    // Unsubscribe from an event after 12 seconds
    setTimeout(() => {
        allPropertiesCheckBox.off("valueChanged");
        console.log("off() method called, event unsubscribed.");
    }, 12000);

    // Dispose of the CheckBox after 14 seconds
    setTimeout(() => {
        allPropertiesCheckBox.dispose();
        console.log("dispose() method called, CheckBox instance removed.");
    }, 14000);

});

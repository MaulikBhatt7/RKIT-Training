$(() => {
    console.clear(); // Clears console for a clean start
    console.log("Initializing DevExtreme CheckBoxes...");

    // CheckBox with available properties in v21.1
    var allPropertiesCheckBox = $('#all-properties').dxCheckBox({
        accessKey: 'm',
        activeStateEnabled: true,
        disabled: false,
        elementAttr: {},
        enableThreeStateBehavior: false,
        focusStateEnabled: true,
        hint: "Click Here",
        hoverStateEnabled: true,
        isValid: false,
        name: "",
        onContentReady: (e) => console.log("Event: contentReady triggered", e),
        onInitialized: (e) => console.log("Event: initialized triggered", e),
        onOptionChanged: (e) => console.log("Event: optionChanged triggered", e),
        onValueChanged: (e) => console.log("Event: valueChanged triggered", e),
        onDisposing: (e) => console.log("Event: disposing triggered", e),
        readOnly: true,
        rtlEnabled: false,
        tabIndex: 0,
        text: "This is Text",
        validationMessageMode: "auto",
        validationMessagePosition: "bottom",
        validationStatus: "valid",
        value: false,
        visible: true
    }).dxCheckBox('instance');

    // Additional CheckBoxes
    var checkedCheckBox = $('#checked').dxCheckBox({
        accessKey: '+',
        value: true,
        elementAttr: { 'aria-label': 'Checked' }
    }).dxCheckBox('instance');

    var uncheckedCheckBox = $('#unchecked').dxCheckBox({
        value: false,
        elementAttr: { 'aria-label': 'Unchecked' }
    }).dxCheckBox('instance');

    var indeterminateCheckBox = $('#indeterminate').dxCheckBox({
        value: null,
        elementAttr: { 'aria-label': 'Indeterminate' }
    }).dxCheckBox('instance');

    var threeStateCheckBox = $('#threeStateMode').dxCheckBox({
        enableThreeStateBehavior: true,
        value: null,
        elementAttr: { 'aria-label': 'Three state mode' }
    }).dxCheckBox('instance');

    var handlerCheckBox = $('#handler').dxCheckBox({
        value: null,
        elementAttr: { 'aria-label': 'Handle value change' },
        onValueChanged(data) {
            disabledCheckBox.option('value', data.value);
            console.log("Handler CheckBox Value Changed:", data.value);
        }
    }).dxCheckBox('instance');

    var disabledCheckBox = $('#disabled').dxCheckBox({
        value: null,
        disabled: true,
        hint: "This is disabled",
        elementAttr: { 'aria-label': 'Disabled' }
    }).dxCheckBox('instance');

    var withTextCheckBox = $('#withText').dxCheckBox({
        value: true,
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

    // Focus
    setTimeout(() => {
        allPropertiesCheckBox.focus();
        console.log("focus() method called.");
    }, 2000);

    // Reset CheckBox to default value
    setTimeout(() => {
        allPropertiesCheckBox.reset();
        console.log("reset() method called, value reset to default.");
    }, 4000);

    // Set a new value dynamically
    setTimeout(() => {
        allPropertiesCheckBox.option('value', true);
        console.log("option() method called: value set to true.");
    }, 6000);

    // Clear the value
    setTimeout(() => {
        allPropertiesCheckBox.reset();
        console.log("reset() method called, value reset.");
    }, 8000);

    // Repaint component
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

    // Unsubscribe from an event
    setTimeout(() => {
        allPropertiesCheckBox.off("valueChanged");
        console.log("off() method called, event unsubscribed.");
    }, 12000);

    // Dispose of the CheckBox after some time
    setTimeout(() => {
        allPropertiesCheckBox.dispose();
        console.log("dispose() method called, CheckBox instance removed.");
    }, 14000);
});
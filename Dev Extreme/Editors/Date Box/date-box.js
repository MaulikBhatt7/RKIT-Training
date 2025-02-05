$(function () {

    // Initializing a DateBox with various properties
    var dateBox = $('#all-properties').dxDateBox({

        // Sets the initial date value
        //value: new Date(),

        // Sets a shortcut key for accessibility
        accessKey: 'm',

        // Allows users to enter a custom date value manually
        acceptCustomValue: true,

        // Custom text for the apply button
        applyButtonText: 'Apply',

        // Custom text for the cancel button
        cancelButtonText: 'Cancel',

        // Enables adaptive UI behavior on small screens
        adaptivityEnabled: true,

        // Message displayed when selected date is out of the allowed range
        dateOutOfRangeMessage: 'Date is out of range!',

        // Defines the format for serializing date values
        dateSerializationFormat: 'yyyy-MM-dd',

        // Defines the format for displaying the date
        displayFormat: 'yyyy/MM/dd',

        // Ensures content is rendered immediately
        deferRendering: false,

        // Enables or disables the DateBox
        disabled: false,

        // Specifies dates that should be disabled
        disabledDates: [new Date(2025, 1, 14)],

        // Custom template for the drop-down button
        dropDownButtonTemplate: function () {
            return $('<span>').addClass("dx-icon dx-icon-event");
        },

        // Additional attributes for the root element
        elementAttr: { class: 'date-box' },

        // Enables focus styling
        focusStateEnabled: true,

        // Sets the height of the DateBox
        height: 40,

        // Tooltip hint text
        hint: 'Pick a date',

        // Enables hover styling
        hoverStateEnabled: true,

        // Additional attributes for the input field
        inputAttr: { 'aria-label': 'Date Box' },

        // Defines whether the initial value is valid
        isValid: true,

        // Sets the maximum selectable date
        max: new Date(2030, 11, 31),

        // Sets the minimum selectable date
        min: new Date(2000, 0, 1),

        // Name attribute for form submission
        name: 'dateBox',

        // Specifies the type of date picker
        pickerType: 'rollers',

        // Placeholder text for the input field
        placeholder: 'Select Date',

        // Allows or restricts user input
        readOnly: false,

        // Enables right-to-left text support
        rtlEnabled: false,

        // Hides the analog clock in time selection
        showAnalogClock: true,

        // Shows a clear button to reset the date field
        showClearButton: true,

        // Disables spellchecking in the input field
        spellcheck: false,

        // Sets the styling mode (outlined, underlined, or filled)
        stylingMode: 'outlined',

        // Specifies the type of date input (date, time, datetime)
        type: 'datetime',

        // Determines whether the component participates in form submission
        useSubmitBehavior: false,

        // Custom validation error message
        validationErrors: [{message: "Enter valid date"}],

        // Defines how validation messages are displayed
        validationMessageMode: 'auto',

        // Controls the visibility of the DateBox
        visible: true,

        // Sets the width of the DateBox
        width: 200,

        // Event triggered when the value changes
        onValueChanged: function (e) {
            console.log('Date Changed:', e.value);
        },

        // Event triggered when the DateBox receives focus
        onFocusIn: function () {
            console.log('DateBox Focused');
        },

        // Event triggered when the DateBox loses focus
        onFocusOut: function () {
            console.log('DateBox Unfocused');
        },

        // Event triggered when the DateBox dropdown is opened
        onOpened: function () {
            console.log('DateBox Opened');
        },

        // Event triggered when the DateBox dropdown is closed
        onClosed: function () {
            console.log('DateBox Closed');
        },

        // Event triggered when a key is pressed down
        onKeyDown: function (e) {
            console.log('Key Down:', e.event.key);
        },

        // Event triggered when a key is released
        onKeyUp: function (e) {
            console.log('Key Up:', e.event.key);
        },

        // Event triggered when a key is pressed
        onKeyPress: function (e) {
            console.log('Key Pressed:', e.event.key);
        }

    }).dxDateBox('instance');

    // Demonstrating Methods

    // Apply various methods after a delay of 5 seconds
    setTimeout(() => {

        // Focus on the DateBox
        dateBox.focus();

        // Remove focus from the DateBox
        dateBox.blur();

        // Log the root element of the DateBox
        console.log(dateBox.element());

        // Log the input field of the DateBox
        console.log(dateBox.field());

        // Set a new date value
        dateBox.option('value', new Date(2025, 5, 10));

    }, 5000);

    // Creating buttons to demonstrate functionality

    // Button to open the DateBox dropdown
    $('<button>Open</button>').appendTo('body').click(() => dateBox.open());

    // Button to close the DateBox dropdown
    $('<button>Close</button>').appendTo('body').click(() => dateBox.close());

    // Button to reset the DateBox value
    $('<button>Reset</button>').appendTo('body').click(() => dateBox.reset());

    // Button to dispose of the DateBox instance
    $('<button>Dispose</button>').appendTo('body').click(() => dateBox.dispose());

});

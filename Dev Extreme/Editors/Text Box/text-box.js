$(() => {
    // Initialize simple text box with a preset value and ARIA label for accessibility
    $('#simple').dxTextBox({
        // Preset value for the text box
        value: 'Maulik',

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Name' },
    });

    // Initialize text box with a placeholder, clear button, and ARIA label for accessibility
    $('#placeholder').dxTextBox({
        // Placeholder text for the text box
        placeholder: 'Enter Full Name',

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Full Name' },

        // Show clear button inside the text box
        showClearButton: true,
    });

    // Initialize password text box with toggle visibility button and ARIA label for accessibility
    var passwordEditor = $('#password').dxTextBox({
        // Mode for the text box input type
        mode: 'password', // Accepted Values: 'email' | 'password' | 'search' | 'tel' | 'text' | 'url'

        // Placeholder text for the text box
        placeholder: 'Enter password',

        // Button to toggle password visibility
        buttons: [{
            name: 'password',
            location: 'after',
            options: {
                icon: 'favorites',
                stylingMode: 'text',
                onClick() {
                    passwordEditor.option('mode', passwordEditor.option('mode') === 'text' ? 'password' : 'text');
                },
            },
        }],

        // Preset value for the text box
        value: 'mb@123',

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Password' },
    }).dxTextBox('instance');

    // Initialize text box with input mask for mobile number, custom mask rules, and ARIA label for accessibility
    $('#mobile-no').dxTextBox({
        // Input mask for the text box
        mask: '+(\\9X) 00000 00000',

        // Character used to fill in the mask
        maskChar: '-',

        // Message to display when the input does not match the mask
        maskInvalidMessage: "Enter Valid Mobile",

        // Custom mask rules
        maskRules: { 'X': /[1-9]/ },

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Mobile' }
    });

    // Initialize text box with a placeholder, clear button, ARIA label for accessibility, and value change event
    $('#full-name').dxTextBox({
        // Preset value for the text box
        value: 'Maulik',

        // Show clear button inside the text box
        showClearButton: true,

        // Placeholder text for the text box
        placeholder: 'Enter full name',

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Full Name' },

        // Event triggered on value change
        valueChangeEvent: 'keyup',
        onValueChanged(data) {
            emailEditor.option('value', `${data.value.replace(/\s/g, '').toLowerCase()}@temp.com`);
        },

        // Styling mode for the text box
        stylingMode: 'filled' // Accepted Values: 'outlined' | 'underlined' | 'filled'
    });

    // Initialize read-only text box for email with preset value and ARIA label for accessibility
    const emailEditor = $('#email').dxTextBox({
        // Preset value for the text box
        value: 'maulik@temp.com',

        // Make the text box read-only
        readOnly: true,

        // ARIA label for accessibility
        inputAttr: { 'aria-label': 'Email' },

        // Disable hover state for the text box
        hoverStateEnabled: false,
    }).dxTextBox('instance');
});
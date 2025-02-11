$(() => {
    // Set the maximum date to 21 years ago from today
    var maxDate = new Date();
    maxDate.setFullYear(maxDate.getFullYear() - 21);

    // Simulate an asynchronous request to check if the email is already registered
    var sendRequest = function (value) {
        var invalidEmail = 'test@dx-email.com';
        var d = $.Deferred();
        setTimeout(() => {
            d.resolve(value !== invalidEmail);
        }, 1000);
        return d.promise();
    };

    // Toggle password visibility
    var changePasswordMode = function (name) {
        var editor = $(name).dxTextBox('instance');
        editor.option('mode', editor.option('mode') === 'text' ? 'password' : 'text');
    };

    // Initialize the validation summary
    $('#summary').dxValidationSummary({});

    // Email validation
    $('#email-validation').dxTextBox({
        inputAttr: { 'aria-label': 'Email' },
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Email is required',
        }, {
            type: 'email',
            message: 'Email is invalid',
        }, {
            type: 'async',
            message: 'Email is already registered',
            validationCallback(params) {
                return sendRequest(params.value);
            },
        }],
        validationGroup: "my-form"
    });

    // Password validation
    $('#password-validation').dxTextBox({
        mode: 'password',
        inputAttr: { 'aria-label': 'Password' },
        buttons: [{
            name: 'password',
            location: 'after',
            options: {
                icon: 'favorites',
                stylingMode: 'text',
                onClick: () => changePasswordMode('#password-validation'),
            },
        }],
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Password is required',
        }],
        validationGroup: "my-form"
    });

    // Confirm password validation
    $('#confirm-password-validation').dxTextBox({
        mode: 'password',
        inputAttr: { 'aria-label': 'Confirm Password' },
        buttons: [{
            name: 'password',
            location: 'after',
            options: {
                icon: 'favorites',
                stylingMode: 'text',
                onClick: () => changePasswordMode('#confirm-password-validation'),
            },
        }],
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'compare',
            comparisonTarget() {
                var password = $('#password-validation').dxTextBox('instance');
                if (password) {
                    return password.option('value');
                }
                return null;
            },
            message: "'Password' and 'Confirm Password' do not match.",
        },
        {
            type: 'required',
            message: 'Confirm Password is required',
        }],
        validationGroup: "my-form"
    });

    // Name validation
    $('#name-validation').dxTextBox({
        value: 'MB',
        inputAttr: { 'aria-label': 'Name' },
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Name is required',
        }, {
            type: 'pattern',
            pattern: /^[^0-9]+$/,
            message: 'Do not use digits in the Name.',
        }, {
            type: 'stringLength',
            min: 2,
            message: 'Name must have at least 2 symbols',
        }],
        validationGroup: "my-form"
    });

    // Date of birth validation
    $('#date-validation').dxDateBox({
        invalidDateMessage: 'The date must have the following format: MM/dd/yyyy',
        inputAttr: { 'aria-label': 'Date' },
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Date of birth is required',
        }, {
            type: 'range',
            max: maxDate,
            message: 'You must be at least 21 years old',
        }],
        validationGroup: "my-form"
    });

    // Country validation
    $('#country-validation').dxSelectBox({
        dataSource: ["India", "Australia"],
        inputAttr: { 'aria-label': 'Country' },
        validationMessagePosition: 'left',
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Country is required',
        }],
        validationGroup: "my-form"
    });

    // City validation
    $('#city-validation').dxTextBox({
        validationMessagePosition: 'left',
        inputAttr: { 'aria-label': 'City' },
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'City is required',
        }, {
            type: 'pattern',
            pattern: '^[^0-9]+$',
            message: 'Do not use digits in the City name.',
        }, {
            type: 'stringLength',
            min: 2,
            message: 'City must have at least 2 symbols',
        }],
        validationGroup: "my-form"
    });

    // Address validation
    $('#address-validation').dxTextBox({
        validationMessagePosition: 'left',
        inputAttr: { 'aria-label': 'Address' },
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'required',
            message: 'Address is required',
        }],
        validationGroup: "my-form"
    });

    // Phone validation
    $('#phone-validation').dxTextBox({
        mask: '+(\\9X) 00000 00000',
        inputAttr: { 'aria-label': 'Phone' },
        maskRules: {
            X: /[1-9]/,
        },
        maskInvalidMessage: 'The phone must have a correct Indian phone format',
        validationMessagePosition: 'left',
        onFocusOut: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'pattern',
            pattern: /^\(\+9[1-9]\) \d{5} \d{5}$/,
            message: 'The phone must have a correct Indian phone format',
        }],
        validationGroup: "my-form"
    });

    // Terms and conditions checkbox validation
    $('#check').dxCheckBox({
        value: false,
        text: 'I agree to the Terms and Conditions',
        validationMessagePosition: 'right',
        onValueChanged: function () {
            // Validate the current group and focus on the first invalid field if there are errors
            var result = DevExpress.validationEngine.validateGroup("my-form");
            if (!result.isValid) {
                result.brokenRules[0].validator.focus();
            }
        }
    }).dxValidator({
        validationRules: [{
            type: 'compare',
            comparisonTarget() { return true; },
            message: 'You must agree to the Terms and Conditions',
        }],
        validationGroup: "my-form"
    });

    // Handle form submission
    $('#form').on('submit', (e) => {
        var result = DevExpress.validationEngine.validateGroup("my-form");
        if (result.isValid) {
            DevExpress.ui.notify({
                message: 'You have submitted the form',
                position: {
                    my: 'center top',
                    at: 'center top',
                },
            }, 'success', 3000);
        } else {
            // Focus on the first invalid field if there are errors
            result.brokenRules[0].validator.focus();
        }
        e.preventDefault();
    });

    // Submit button
    $('#button').dxButton({
        width: '120px',
        text: 'Register',
        type: 'default',
        useSubmitBehavior: true,
    });
});
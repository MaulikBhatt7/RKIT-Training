$(() => {
    $("#numberBox").dxNumberBox({

        // Minimum value for the number input (0 in this case)
        min: 0,

        // Maximum value for the number input (100 in this case)
        max: 1,

        // Format the value as a percentage (values will be shown as percentages)
        format: {
            type: "percent", // Percentage format
            precision: 2 // Optional: Precision for decimal points
        },

        // Placeholder text shown when the input is empty
        placeholder: "Percentage",

        // Set the initial value to null (input will be empty at the start)
        value: null,

        // Show the spin buttons (arrows) for incrementing or decrementing the value
        showSpinButtons: true,

        // Show a clear button (✖) to reset the input value
        showClearButton: true,

        // Set the step value for the spin buttons (step size is 10)
        step: 0.10,

        // Use large spin buttons for easier clicking
        useLargeSpinButtons: true
    });
});

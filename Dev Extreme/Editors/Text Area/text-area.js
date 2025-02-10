$(() => {
    $("#textArea").dxTextArea({
        // Enables or disables the auto-resize feature
        autoResizeEnabled: true,

        // Sets the minimum height of the text area
        minHeight: 20,

        // Sets the maximum height of the text area
        maxHeight: 100,

        // Specifies the placeholder text for the text area
        placeholder: "U.S.A",

        // Sets the maximum number of characters allowed in the text area
        maxLength: "25",

        // Disables the spellcheck feature
        spellcheck: false, // default value is true.

        // Sets the initial value of the text area
        value: "Hello",

        // Event handler for the value changed event
        onValueChanged: (e) => {
            console.log("Value Changed: " + e.value);
        }
    });
});
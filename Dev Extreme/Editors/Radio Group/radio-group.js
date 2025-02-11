$(() => {
    // Initialize the first radio group with a data source of numbers
    $("#radioGroup").dxRadioGroup({
        // The data source for the radio group items
        dataSource: [11, 12],

        // Hint text that appears when the user hovers over the radio group
        hint: 'Select Standard',

        // Layout of the radio buttons, can be 'horizontal' or 'vertical'
        layout: 'horizontal',

        // The default selected value
        value: 11
    });

    // Initialize the second radio group with custom items and a template
    $('#customRadioGroup').dxRadioGroup({
        // The items for the radio group
        items: ['Low', 'Normal', 'Urgent', 'High'],

        // The default selected value
        value: 'Normal',

        // Custom template for the radio group items
        itemTemplate(itemData, _, itemElement) {
            itemElement
                // Add a class to the parent element based on the item data
                .parent().addClass(itemData.toLowerCase())

                // Set the text of the item element
                .text(itemData);
        },
    });
});
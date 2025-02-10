$(() => {


    var fromUngroupedData = new DevExpress.data.DataSource({
        store: {
            type: 'array',
            data: studentList
        },
        group: 'Age',
    });

    // Initialize SelectBox for simple name list
    $("#simple-name-list").dxSelectBox({
        items: studentNames,
        placeholder: "Select Name",
        height: 50,
        searchEnabled: true,
        showClearButton: true,
    });

    // Initialize SelectBox for student list
    $("#object-list").dxSelectBox({
        dataSource: fromUngroupedData,
        placeholder: "Select Name",
        height: 50,
        searchEnabled: true,
        showClearButton: true,
        displayExpr: "Name",
        //fieldTemplate(data, container) {
        //    // Create the custom field container
        //    var result = $("<div class='student-name'></div>");

        //    // Initialize dxTextBox directly on the result container
        //    result.dxTextBox({
        //        value: data && data.Name,
        //        readOnly: true,
        //        inputAttr: { 'aria-label': 'Name' },
        //    });

        //    // Append the result to the container
        //    container.append(result);
        //},
        itemTemplate(data) {
            return `<div class='product-name'>${data.Name}</div>`;
        },
        onValueChanged(data) {
            $('.current-value > span').text(data.value.Name);
            DevExpress.ui.notify(`The value is changed to: "${data.value.Name}"`);
            console.log(data);
        },
        grouped: true
    });
});

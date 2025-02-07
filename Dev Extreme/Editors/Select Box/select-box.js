$(() => {
    $("#simple-name-list").dxSelectBox({
        items: studentNames,
        placeholder: "Select Name",
        height: 50,
        enableSearch:true
    })
})
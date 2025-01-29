
// All properties of button
$(function () {
    $("#buttonContainer-main").dxButton({
        text: "All Properties", // display text on button
        elementAttr: {class: "btn-demo"}, // set custom attributes
        disabled:false, // used to disable or enable button
        focusStateEnabled:true, // enable focus state
        height:50, // specify height
        hint:"Hello World", // specify hint on hover (tool-tip)
        hoverStateEnabled:true, // enable hover state
        icon:"favorites", // icons
        onContentReady:null, // perform anything on content ready
        onDisposing:null, // perform anything on disposing
        onInitialized:null, // perform anything on initialization
        onOptionChanged: function(e) {
            if(e.name === "changedProperty") {
                // handle the property change here
            }
        }, // on option changed event
        rtlEnabled:false, // convert text right to left
        stylingMode:"outlined", // contained
        tabIndex:0, // specify number of element during tab
        template:"content",
        type:"default", // normal, success, danger
        useSubmitBehavior:false, // vehave like submit button
        visible:true,  // visiblity true or false
        width:300, // speecify width
        onClick: function () {
            alert("Hello world!");
        }  // on click event
    });
});


$(
    function () {
        $("#buttonContainer-1").dxButton(
            {
                type: "normal",
                text: "Normal Type"
            }
        );
    }
);

$(
    function () {
        $("#buttonContainer-2").dxButton(
            {
                type: "default",
                text: "Default Type"
            }
        );
    }
);

$(
    function () {
        $("#buttonContainer-3").dxButton(
            {
                type: "success",
                text: "Success Type"
            }
        );
    }
);

$(
    function () {
        $("#buttonContainer-4").dxButton(
            {
                type: "danger",
                text: "Danger Type"
            }
        );
    }
);

$(
    function () {
        $("#buttonContainer-4").dxButton(
            {
                type: "danger",
                text: "Danger Type and Style Outlined",
                stylingMode: "outlined",
                width: 300
            }
        );
    }
);
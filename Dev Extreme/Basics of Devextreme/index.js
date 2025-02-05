
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
        tabIndex:2, // specify number of element during tab
        template:"content",
        type:"default", // normal, success, danger
        useSubmitBehavior:false, // behave like submit button
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
        text: "Normal Type",
        tabIndex: 1
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
        text: "Danger Type and Outlined Mode",
        stylingMode: "outlined"
      }
    );
  }
);




$("#gridContainer").dxDataGrid({
  dataSource: [
    { ID: 1, Name: "MB", Age: 30 },
    { ID: 2, Name: "YK", Age: 25 },
    { ID: 3, Name: "MB", Age: 30 },
    { ID: 4, Name: "YK", Age: 25 },
    { ID: 5, Name: "MB", Age: 30 },
    { ID: 6, Name: "YK", Age: 25 }
  ],
  columns: ["ID", "Name", "Age"],
  paging: { pageSize: 5 },
  filterRow: { visible: true }
});

let grid = $("#gridContainer").dxDataGrid("instance");
console.log(grid);

let pageSize = grid.option("paging.pageSize");
console.log(pageSize);

grid.option("paging.pageSize", 3);


grid.option({
  "paging.pageSize": 2,
  "filterRow.visible": false
});


grid.selectRows([1]); 

grid.option("onRowClick", function(e) {
  alert("Clicked row data: " + JSON.stringify(e.data));
});

// grid.dispose(); //or $("#gridContainer").dxDataGrid("dispose");

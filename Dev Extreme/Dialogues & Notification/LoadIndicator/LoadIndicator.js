$(function() {
    var loadIndicator = $("#loadIndicator").dxLoadIndicator({
        visible: false
    }).dxLoadIndicator("instance");

    $("#showImageButton").dxButton({
        text: "Show Image",
        onClick: function() {
            loadIndicator.option("visible", true); // Show LoadIndicator
            
            var img = $("#onlineImage");
            // img.hide();
            img.attr("src", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRUHGVaEBzz6TZ2DDSFfnTkqi7p86Eg3riyYXWGMb-fyb1TvtFs_vZsj1Q3mDWcAZJnypM&usqp=CAU");
            
            img.on("load", function () {
                console.log("Hello")
                loadIndicator.option("visible", false); // Hide LoadIndicator when image loads
                img.show(); // Show the image
            });
        }
    });
});
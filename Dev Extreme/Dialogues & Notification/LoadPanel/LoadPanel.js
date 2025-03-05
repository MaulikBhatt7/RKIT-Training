$(function() {
            // Initialize LoadPanel inside the image container
            var loadPanel = $("#loadPanel").dxLoadPanel({
                shadingColor: "rgba(12, 10, 150, 0.4)", // Background overlay color
                position: { of: "#imageContainer" }, // Position inside the container
                visible: false, // Initially hidden
                message: "Loading Image...", // Custom message
                showIndicator: true, // Show spinner
                showPane: true, // Show background panel
                closeOnOutsideClick: false,
            }).dxLoadPanel("instance");

            $("#showImageButton").dxButton({
                text: "Show Image",
                onClick: function() {
                    loadPanel.show(); // Show LoadPanel
                    $("#placeholderText").hide(); // Hide placeholder text

                    var img = $("#onlineImage");
                    img.hide(); // Hide any previous image
                    img.attr("src", "https://asset.gecdesigns.com/img/wallpapers/blue-purple-beautiful-scenery-ultra-hd-wallpaper-4k-sr10012421-1706505497434-cover.webp");
                    
                    img.on("load", function() {
                        loadPanel.hide(); // Hide LoadPanel when image is fully loaded
                        img.show(); // Show the loaded image
                    });
                }
            });
        });
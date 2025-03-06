$(function () {
    // Button to Show Normal Popup
    $("#showPopupButton").dxButton({

        // Text displayed on the button
        text: "Show Popup",  

        // Button width in pixels
        width: 300,  

        // Button type: "default", "normal", "success", "danger", etc.
        type: "default",  

        // Event triggered when the button is clicked
        onClick: function () {
            popup.show(); // Show the normal popup when clicked
        }
    });

    // Button to Show Popup with ScrollView
    $("#showPopupWithScrollViewButton").dxButton({

        // Text displayed on the button
        text: "Show Popup with ScrollView",  

        // Button width in pixels
        width: 300,  

        // Button type
        type: "default",  

        // Event triggered when the button is clicked
        onClick: function () {
            popupWithScrollView.show(); // Show the popup with ScrollView when clicked
        }
    });

    // Normal Popup Instance
    let popup = $("#popupContainer").dxPopup({

        // Title displayed on top of the popup
        title: "Simple Popup",  

        // Width of the popup in pixels
        width: 400,  

        // Height of the popup in pixels
        height: 250,  

        // Initial visibility of the popup (true: visible, false: hidden)
        visible: false,  

        // Close the popup when clicking outside (true/false)
        closeOnOutsideClick: true,  

        // Show or hide the close button (true/false)
        showCloseButton: false,  

        // Enable or disable dragging (true/false)
        dragEnabled: false,  

        // Enable or disable resizing (true/false)
        resizeEnabled: true,  

        // Enable shading (true/false)
        shading: true,  

        // Shading color when the popup is visible (RGBA format)
        shadingColor: "rgba(0, 255, 255, 0.8)",  

        // Display the popup in full-screen mode (true/false)
        fullScreen: false,  

        // Show or hide the title bar (true/false)
        showTitle: true,  

        // Animation settings for showing and hiding the popup
        animation: {
            // Animation when the popup appears
            show: { type: "fadeIn", duration: 5000 },  

            // Animation when the popup disappears
            hide: { type: "fadeOut", duration: 3000 }  
        },

        // Toolbar items inside the popup (buttons, etc.)
        toolbarItems: [
            {
                // Toolbar location: "top" or "bottom"
                toolbar: "bottom",  

                // Button position within the toolbar: "before", "center", or "after"
                location: "after",  

                // Type of widget to display in the toolbar
                widget: "dxButton",  

                // Button configuration inside the popup
                options: {
                    
                    // Button text
                    text: "Close",  

                    // Event triggered when clicking the button
                    onClick: function () {
                        popup.hide(); // Hide the popup when clicking the close button
                    }
                }
            }
        ],

        // Event triggered before the popup appears
        onShowing: function () {
            console.log("Popup is about to show");
        },

        // Event triggered when the popup is fully visible
        onShown: function () {
            console.log("Popup is shown");
        },

        // Event triggered before the popup hides
        onHiding: function () {
            console.log("Popup is about to hide");
        },

        // Event triggered when the popup is fully hidden
        onHidden: function () {
            console.log("Popup is hidden");
        }

    }).dxPopup("instance");


    // Content for ScrollView inside the popup
    let scrollViewContent = `
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
        <p>Vestibulum et lacus nec justo dignissim hendrerit.</p>
        <p>Curabitur aliquam metus nec magna commodo, eu pharetra risus rhoncus.</p>
        <p>Fusce tincidunt nisl id augue congue, eget tincidunt sapien consequat.</p>
        <p>Proin ut ex nec sapien cursus facilisis.</p>
        <p>Donec vulputate risus ut felis dictum, sed fermentum nisi aliquet.</p>
        <p>Suspendisse potenti. Integer vehicula massa a est ultricies accumsan.</p>
        <p>Aliquam auctor metus ut sem tempus, id ultrices turpis placerat.</p>
    `;

    // Popup with ScrollView Instance
    let popupWithScrollView = $("#popupWithScrollView").dxPopup({

        // Title displayed on top of the popup
        title: "Popup with ScrollView",  

        // Width of the popup in pixels
        width: 360,  

        // Height of the popup in pixels
        height: 320,  

        // Initial visibility of the popup (true: visible, false: hidden)
        visible: false,  

        // Close the popup when clicking outside (true/false)
        closeOnOutsideClick: true,  

        // Show or hide the close button (true/false)
        showCloseButton: true,  

        // Enable or disable dragging (true/false)
        dragEnabled: true,  

        // Enable or disable resizing (true/false)
        resizeEnabled: true,  

        // Toolbar items inside the popup
        toolbarItems: [
            {
                // Type of widget inside the toolbar
                widget: "dxButton",  

                // Toolbar location: "top" or "bottom"
                toolbar: "bottom",  

                // Button position in the toolbar: "before", "center", or "after"
                location: "center",  

                // Button configuration
                options: {
                    
                    // Button text
                    text: "Close",  

                    // Button type: "default", "normal", "success", "danger", etc.
                    type: "default",  

                    // Styling mode: "text", "outlined", or "contained"
                    stylingMode: "contained",  

                    // Button width in pixels
                    width: 300,  

                    // Event triggered when clicking the button
                    onClick: function () {
                        popupWithScrollView.hide(); // Hide the popup when clicking the close button
                    }
                }
            }
        ],

        // Custom content inside the popup (using ScrollView)
        contentTemplate: function () {
            
            // Create a div container for the ScrollView
            let $scrollView = $("<div/>");

            // Append the content inside the ScrollView
            $scrollView.append($("<div/>").html(scrollViewContent));

            // Initialize the ScrollView inside the div
            $scrollView.dxScrollView({

                // ScrollView width (can be %, px, etc.)
                width: "100%",  

                // ScrollView height
                height: "100%"  

            });

            return $scrollView; // Return the ScrollView container
        }

    }).dxPopup("instance");

});

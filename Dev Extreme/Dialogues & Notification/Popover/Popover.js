$(function () {

    // Button to Show Normal Popover
    $("#showPopoverButton").dxButton({

        // Set button text
        text: "Show Popover",  

        // Set button width
        width: 300,  

        // Default button style
        type: "default",  

        // Click event handler
        onClick: function (e) {
            popover.show(); // Show popover near the button
        }
    });

    // Button to Show Popover with ScrollView
    $("#showPopoverWithScrollViewButton").dxButton({

        // Set button text
        text: "Show Popover with ScrollView",  

        // Set button width
        width: 300,  

        // Default button style
        type: "default",  

        // Click event handler
        onClick: function (e) {
            popoverWithScrollView.show(e.component.element()); // Show popover near the button
        }
    });

    // Normal Popover Instance
    let popover = $("#popoverContainer").dxPopover({

        // Set target element for popover
        target: "#popoverContainer", 

        // Title of the popover
        title: "Simple Popover",  

        // Set popover width
        width: 300,  

        // Set popover height
        height: 200,  

        // Initially hidden
        visible: false,  

        // Close popover when clicking outside
        closeOnOutsideClick: true,  

        // Show close button in the popover
        showCloseButton: true,  

        // Disable dragging of popover
        dragEnabled: false,  

        // Allow resizing of popover
        resizeEnabled: true,  

        // Show popover on mouse enter
        showEvent: 'mouseenter',  

        // Hide popover on mouse leave
        hideEvent: 'mouseleave',  

        // Enable background shading
        shading: true,  

        // Set shading color
        shadingColor: "rgba(0, 255, 255, 0.8)",  

        // Position the popover relative to the target container
        position: { of: "#targetContainer" },

        // Set animation options
        animation: {
            show: { 
                type: "fade", 
                duration: 500 
            },  
            hide: { 
                type: "fade", 
                duration: 300 
            }  
        },

        // Define the content template
        contentTemplate: function () {
            return "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum et lacus nec justo dignissim hendrerit. Curabitur aliquam metus nec magna commodo, eu pharetra risus rhoncus.";
        }
    }).dxPopover("instance");

    // Content for ScrollView inside the popover
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

    // Popover with ScrollView Instance
    let popoverWithScrollView = $("#popoverWithScrollView").dxPopover({

        // Set target element for popover
        target: "#showPopoverWithScrollViewButton", 

        // Title of the popover
        title: "Popover with ScrollView",

        // Set popover width
        width: 360,  

        // Set popover height
        height: 220,  

        // Initially hidden
        visible: false,  

        // Close popover when clicking outside
        closeOnOutsideClick: true,  

        // Show close button in the popover
        showCloseButton: true,  

        // Enable dragging of popover
        dragEnabled: true,  

        // Allow resizing of popover
        resizeEnabled: true,  

        // Show popover on mouse enter
        showEvent: 'mouseenter',

        // Position the popover below the target element
        position: 'bottom', 

        // Define the content template with a ScrollView
        contentTemplate: function () {
            let $scrollView = $("<div/>");
            $scrollView.append($("<div/>").html(scrollViewContent));
            $scrollView.dxScrollView({ 
                width: "100%", 
                height: "100%" 
            });
            return $scrollView;
        }
    }).dxPopover("instance");
});

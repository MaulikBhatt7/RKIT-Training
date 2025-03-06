$(function () {
    
    // Button to Show a Normal Toast
    $("#showToastButton").dxButton({
        
        // Text displayed on the button
        text: "Show Toast",  
        
        // Button width in pixels
        width: 300,  
        
        // Button style type: "default", "normal", "success", etc.
        type: "default",  
        
        // Event triggered when the button is clicked
        onClick: function () {
            showStackedToasts(); // Call function to show stacked toasts sequentially
        }
    });

    
    // Button to Show Stacked Toasts
    $("#showStackedToastButton").dxButton({
        
        // Text displayed on the button
        text: "Show Stacked Toasts",  
        
        // Button width in pixels
        width: 300,  
        
        // Button style type
        type: "default",  
        
        // Event triggered when the button is clicked
        onClick: function () {
            showToast("First toast message", "success");  
            showToast("Second toast message", "warning");  
            showToast("Third toast message", "error");  
        }
    });

    
    // Function to show a single toast notification
    function showToast(message, type) {
        
        // Log message for debugging
        console.log("Showing toast: " + message);
        
        $("#toastContainer").dxToast({
            
            // The message text displayed inside the toast
            message: message,  
            
            // Type of toast: "info", "warning", "error", "success"
            type: type,  
            
            // Duration in milliseconds before toast disappears
            displayTime: 3000,  
            
            // Animation settings for showing and hiding the toast
            animation: {
                
                // Animation when the toast appears
                show: { type: "fade", duration: 500 },  
                
                // Animation when the toast disappears
                hide: { type: "fade", duration: 500 }  
            },
            
            // Enables closing the toast by clicking on it
            closeOnClick: true,  
            
            // Toast width settings
            width: "auto",  
            
            // Toast height settings
            height: "auto",  
            
            // Maximum width for the toast container
            maxWidth: 400,  
            
            // Minimum width for the toast container
            minWidth: 200,  
            
            // Enables or disables right-to-left text direction
            rtlEnabled: false,  

        }).dxToast("show"); // Show the toast
    }

    
    // Function to show multiple toasts sequentially (Simulated Stacking)
    function showStackedToasts() {
        
        // Array of toast messages with different types
        let messages = [
            { message: "Toast 1 - Info", type: "info" },
            { message: "Toast 2 - Success", type: "success" },
            { message: "Toast 3 - Warning", type: "warning" },
            { message: "Toast 4 - Error", type: "error" }
        ];

        // Initial delay before showing the first toast
        let delay = 0;

        // Iterate through each toast message and show them with a delay
        messages.forEach((toast) => {
            setTimeout(() => {
                showToast(toast.message, toast.type);
            }, delay);

            // Increment delay to space out toasts
            delay += 2000;  
        });
    }

});

let isValid = false
let apiURL = "https://632158b682f8687273afe9c3.mockapi.io/StudentDetails"

/**
 * Event: Focus and Blur Event Handlers
 * Description: Adds visual feedback for form fields by changing the background color when they are focused or blurred.
 * Parameters: None
 * Returns: None
 * From: User focusing or blurring input fields
 */
function HandleFocus(event) {
    $(event.target).css("background-color", "#f0f8ff");
}

function HandleBlur(event) {
    $(event.target).css("background-color", "");
}

/**
 * Event: Form Validation with jQuery Validation Plugin
 * Description: Validates the form using the jQuery Validation Plugin. Ensures all fields are filled correctly.
 * If validation fails, error messages are displayed. If successful, form data is submitted via AJAX.
 * Parameters: None
 * Returns: None
 * From: User submitting the form
 */
$('#registrationForm').validate({
    rules: {
        student_name: { required: true },
        email: { required: true, email: true },
        password: { required: true, minlength: 6 },
        confirm_password: { required: true, equalTo: "#password" },
        dob: { required: true, date: true },
        phone_number: { required: true, digits: true, minlength: 10, maxlength: 10 }
    },
    messages: {
        student_name: "Full Name is required.",
        email: { required: "Email is required.", email: "Please enter a valid email address." },
        password: { required: "Password is required.", minlength: "Password must be at least 6 characters long." },
        confirm_password: { required: "Confirm Password is required.", equalTo: "Passwords do not match." },
        dob: "Date of Birth is required.",
        phone_number: { required: "Phone number is required.", digits: "Please enter a valid phone number.", minlength: "Phone number must be exactly 10 digits.", maxlength: "Phone number must be exactly 10 digits." }
    },
    errorPlacement: function (error, element) {
        let errorSpanId = element.attr("id") + "_error";
        $("#" + errorSpanId).html(error).show();
    },
    success: function(label, element) {
        let errorSpanId = $(element).attr("id") + "_error";
        $("#" + errorSpanId).hide();
    },
    submitHandler: function(form) {
        // Proceed with form submission if validation is successful
        isValid = true;
    }
});

/**
 * Event: Form Submission
 * Description: Handles the form submission event. If the form is valid, sends the form data via AJAX to the API.
 * If the submission is successful, shows a success message and redirects the user.
 * If there's an error, shows an error message.
 * Parameters: e (event) - The form submission event
 * Returns: None
 * From: User submitting the form
 */
$('#registrationForm').on('submit', function (e) {
    e.preventDefault(); // Prevent default form submission

    if (isValid) {
        // Prepare form data for submission
        let formData = {
            FullName: $('#name').val(),
            Email: $('#email').val(),
            DOB: $('#dob').val(),
            PhoneNo: $('#phone').val(),
            Password: $('#password').val()
        };
        console.log("Submitting form data:", formData);

        // Perform AJAX call to submit the form data to the API
        $.ajax({
            url: apiURL,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(formData),
            success: function (response) {
                console.log("Success:", response);
                alert("Registration successful!");
                window.location.href = "./student_list.html"; // Redirect to student list page
            },
            error: function (xhr, status, error) {
                console.error("Status:", status);
                console.error("Error:", error);
                alert("An error occurred: " + error); // Show error message
            }
        });
    }
});

/**
 * Event: Async Operation (Deferred & Promise)
 * Description: Demonstrates using Deferred and Promise objects for handling asynchronous operations.
 * In this case, simulates an operation that resolves after 5 seconds.
 * Parameters: None
 * Returns: None
 * From: Triggered by AsyncOperation() call
 */
function AsyncOperation() {
    let deferred = $.Deferred(); // Create a deferred object
    setTimeout(() => {
        deferred.resolve("Operation complete!"); // Resolve deferred after 5 seconds
    }, 5000);
    return deferred.promise(); // Return the promise
}

// Execute async operation and log the result
AsyncOperation().done((message) => {
    console.log(message); // Log the message after the async operation completes
});


// // Callback Example
// $("button").click(function(){
//     $("p").hide("slow", function(){
//       alert("The paragraph is now hidden");
//     });
// });

/**
 * Event: jQuery Array Manipulation (map(), grep(), extend(), each(), merge())
 * Description: Demonstrates the usage of several jQuery methods for manipulating arrays and objects:
 * map() for transforming array elements, grep() for filtering, extend() for merging objects, each() for iteration, and merge() for combining arrays.
 * Parameters: None
 * Returns: None
 * From: Array manipulation
 */
let array = [1, 2, 3, 4, 5];

// map() - Modify each element in the array (square each number)
let squaredArray = $.map(array, num => num * num);
console.log(squaredArray); // [1, 4, 9, 16, 25]

// grep() - Filter even numbers from the array
let evenNumbers = $.grep(array, num => num % 2 === 0);
console.log(evenNumbers); // [2, 4]

// extend() - Merge two objects, with user settings overriding defaults
let defaultSettings = { theme: "light", fontSize: 14 };
let userSettings = { fontSize: 16 };
let settings = $.extend({}, defaultSettings, userSettings);
console.log(settings); // { theme: "light", fontSize: 16 }

// each() - Iterate over the array and log each index and value
$.each(array, (index, value) => {
    console.log(`Index: ${index}, Value: ${value}`);
});

// merge() - Merge two arrays into one
let anotherArray = [6, 7, 8];
let mergedArray = $.merge(array, anotherArray);
console.log(mergedArray); // [1, 2, 3, 4, 5, 6, 7, 8]

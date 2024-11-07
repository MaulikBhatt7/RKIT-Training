$(function () {
    // Restore form data from sessionStorage
    let name = sessionStorage.getItem('name');
    let email = sessionStorage.getItem('email');
    let dob = sessionStorage.getItem('dob');
    let phone = sessionStorage.getItem('phone');
    let apiURL = "https://632158b682f8687273afe9c3.mockapi.io/StudentDetails"
    let isValid = false;
    if (name) $('#name').val(name);
    if (email) $('#email').val(email);
    if (dob) $('#dob').val(dob);
    if (phone) $('#phone').val(phone);

    // Show form preference based on cookie
    const formPreference = getFormPreferenceFromCookies();
    if (formPreference) {
        alert(`Last time you filled out the form as ${formPreference}`);
    }

    // Add focus and blur event listeners to all input fields
    $('.form-control').on('focus', handleFocus)
                      .on('blur', handleBlur);



    // jQuery Validation Plugin setup

    $('#registrationForm').validate({
        rules: {
            student_name: { required: true },
            email: { required: true, email: true },
            password: { required: true, minlength: 6 },
            confirm_password: { required: true, equalTo: "#password" },
            dob: { required: true, date: true },
            phone_number: { required: true, digits: true, minlength:10, maxlength:10 }
        },
        messages: {
            student_name: "Full Name is required.",
            email: { required: "Email is required.", email: "Please enter a valid email address." },
            password: { required: "Password is required.", minlength: "Password must be at least 6 characters long." },
            confirm_password: { required: "Confirm Password is required.", equalTo: "Passwords do not match." },
            dob: "Date of Birth is required.",
            phone_number: { 
                required: "Phone number is required.", 
                digits: "Please enter a valid phone number.",
                minlength: "Phone number must be exactly 10 digits.",
                maxlength: "Phone number must be exactly 10 digits."
            }
        },
        errorPlacement: function (error, element) {
            isValid=false;
            // Place the error message in the <span> with a corresponding ID
            let errorSpanId = element.attr("id") + "_error"; // e.g., name_error, email_error
            $("#" + errorSpanId).html(error).show();
        },
        success: function(label, element) {
            // Hide the error message when validation passes
            let errorSpanId = $(element).attr("id") + "_error";
            $("#" + errorSpanId).hide();
        },
        submitHandler: function(form){
            isValid=true;
        }
        
    });


    $('#registrationForm').on('submit', function (e) {
        e.preventDefault(); // Prevent traditional form submission
    
        if(isValid){
            // Form data for testing
            const formData = {
                FullName: $('#name').val(),
                Email: $('#email').val(),
                DOB: $('#dob').val(),
                PhoneNo: $('#phone').val(),
                Password: $('#password').val()
            };
            console.log("Submitting form data:", formData);
        
            // Perform AJAX call
            $.ajax({
                url: apiURL,
                type: 'POST',
                dataType: 'json', // Expecting JSON response
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(formData),
                success: function (response) {
                    console.log("Success:", response);
                    alert("Registration successful!");
                    window.location.href = "./student_list.html";
                },
                error: function (xhr, status, error) {
                    console.error("Status:", status);
                    console.error("Error:", error);
                    console.error("Response:", xhr.responseText);
                    alert("An error occurred: " + error);
                }
            });
        }
    });
});





// Save data to sessionStorage
function saveFormDataToSessionStorage() {
    sessionStorage.setItem('name', $('#name').val());
    sessionStorage.setItem('email', $('#email').val());
    sessionStorage.setItem('dob', $('#dob').val());
    sessionStorage.setItem('phone', $('#phone').val());
}

// Save form preference to cookies
function saveFormPreferenceToCookies() {
    let formType = document.activeElement.getAttribute("formaction") === "./faculty.html" ? "Faculty" : "Student";
    document.cookie = `formPreference=${formType}; path=/; max-age=86400`; // Cookie expires in 1 day
}

// Get form preference from cookies
function getFormPreferenceFromCookies() {
    let cookies = document.cookie.split("; ");
    for (let cookie of cookies) {
        let [key, value] = cookie.split("=");
        if (key === 'formPreference') {
            return value;
        }
    }
    return null;
}

// Focus and Blur event handlers
function handleFocus(event) {
    $(event.target).css("background-color", "#f0f8ff");
}

function handleBlur(event) {
    $(event.target).css("background-color", "");
}

/* Using Deferred & Promise Object for async example */
function asyncOperation() {
    let deferred = $.Deferred();
    setTimeout(() => {
        deferred.resolve("Operation complete!");
    }, 5000);
    return deferred.promise();
}

// Execute async operation
asyncOperation().done((message) => {
    console.log(message);
});

/* Using jQuery map(), grep(), extend(), each(), and merge() */
let array = [1, 2, 3, 4, 5];

// map() - Modify elements in an array
let squaredArray = $.map(array, num => num * num);
console.log(squaredArray);

// grep() - Filter elements in an array
let evenNumbers = $.grep(array, num => num % 2 === 0);
console.log(evenNumbers);

// extend() - Extend an object
let defaultSettings = { theme: "light", fontSize: 14 };
let userSettings = { fontSize: 16 };
let settings = $.extend({}, defaultSettings, userSettings);
console.log(settings);

// each() - Iterate over an array
$.each(array, (index, value) => {
    console.log(`Index: ${index}, Value: ${value}`);
});

// merge() - Merge arrays
let anotherArray = [6, 7, 8];
let mergedArray = $.merge(array, anotherArray);
console.log(mergedArray);

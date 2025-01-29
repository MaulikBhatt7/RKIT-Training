// Form validation
function ValidateForm(event) {
    event.preventDefault(); // Prevent form submission for validation

    // Clear previous validation messages
    ClearValidationMessages();

    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm_password').value;
    const dob = document.getElementById('dob').value;
    const phone = document.getElementById('phone').value;

    let isValid = true;

    // Name validation
    if (!name) {
        ShowValidationMessage('name', "Full Name is required.");
        isValid = false;
    }

    // Email validation
    if (!email) {
        ShowValidationMessage('email', "Email is required.");
        isValid = false;
    } else {
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            ShowValidationMessage('email', "Please enter a valid email address.");
            isValid = false;
        }
    }

    // Password validation
    if (!password) {
        ShowValidationMessage('password', "Password is required.");
        isValid = false;
    } else if (password.length < 6) {
        ShowValidationMessage('password', "Password must be at least 6 characters long.");
        isValid = false;
    }

    // Confirm Password validation
    if (password !== confirmPassword) {
        ShowValidationMessage('confirm_password', "Passwords do not match.");
        isValid = false;
    }

    // DOB validation
    if (!dob) {
        ShowValidationMessage('dob', "Date of Birth is required.");
        isValid = false;
    }

    // Phone validation
    if (!phone) {
        ShowValidationMessage('phone', "Phone number is required.");
        isValid = false;
    } else {
        const phonePattern = /^[7-9][0-9]{9}$/;
        if (!phonePattern.test(phone)) {
            ShowValidationMessage('phone', "Please enter a valid phone number.");
            isValid = false;
        }
    }

    // If valid, store data and proceed
    if (isValid) {
        // Save data in sessionStorage
        SaveFormDataToSessionStorage();

        // Save form preference using cookies (Student or Faculty)
        SaveFormPreferenceToCookies();

        const confirmation = confirm("Do you want to submit the form?");
        if (confirmation) {
            if (event.submitter && event.submitter.getAttribute("formaction") === "./faculty.html") {
                window.location.href = "./faculty.html"; // Redirect to faculty page
            }
            else{
                document.getElementById('registrationForm').submit();
            }
            
        }
    }
}

// Session Storage: Save form data to sessionStorage
function SaveFormDataToSessionStorage() {
    sessionStorage.setItem('name', document.getElementById('name').value);
    sessionStorage.setItem('email', document.getElementById('email').value);
    sessionStorage.setItem('dob', document.getElementById('dob').value);
    sessionStorage.setItem('phone', document.getElementById('phone').value);
}

// Local Storage: Save form data to localStorage
function SaveFormDataToLocalStorage() {
    localStorage.setItem('name', document.getElementById('name').value);
    localStorage.setItem('email', document.getElementById('email').value);
    localStorage.setItem('dob', document.getElementById('dob').value);
    localStorage.setItem('phone', document.getElementById('phone').value);
}

// Cookies: Save user preference for form type (Student or Faculty)
function SaveFormPreferenceToCookies() {
    const formType = document.activeElement.getAttribute("formaction") === "./faculty.html" ? "Faculty" : "Student";
    document.cookie = `formPreference=${formType}; path=/; max-age=86400`; // Cookie expires in 1 day
}

// Cookies: Get user form preference from cookies
function GetFormPreferenceFromCookies() {
    const cookies = document.cookie.split("; ");
    for (let cookie of cookies) {
        const [key, value] = cookie.split("=");
        if (key === 'formPreference') {
            return value;
        }
    }
    return null;
}

// On page load, restore form data from sessionStorage and show form preference from session
document.addEventListener("DOMContentLoaded", () => {
    const name = sessionStorage.getItem('name');
    const email = sessionStorage.getItem('email');
    const dob = sessionStorage.getItem('dob');
    const phone = sessionStorage.getItem('phone');

    if (name) document.getElementById('name').value = name;
    if (email) document.getElementById('email').value = email;
    if (dob) document.getElementById('dob').value = dob;
    if (phone) document.getElementById('phone').value = phone;

    // Show form preference based on cookie
    const formPreference = GetFormPreferenceFromCookies();
    if (formPreference) {
        alert(`Last time you filled out the form as ${formPreference}`);
    }
});

// Validation message functions

function ShowValidationMessage(field, message) {
    const messageSpan = document.getElementById(`${field}_error`);
    messageSpan.textContent = message;
    messageSpan.style.display = 'block';
}

function ClearValidationMessages() {
    const errorSpans = document.querySelectorAll('.error-message');
    errorSpans.forEach(span => {
        span.textContent = '';
        span.style.display = 'none';
    });
}

// Focus and blur event handling
function HandleFocus(event) {
    event.target.style.backgroundColor = "#f0f8ff";
}

function HandleBlur(event) {
    event.target.style.backgroundColor = "";
}

// Attach event listeners
document.addEventListener("DOMContentLoaded", () => {
    const inputs = document.querySelectorAll('.form-control');
    inputs.forEach(input => {
        input.addEventListener('focus', HandleFocus);
        input.addEventListener('blur', HandleBlur);
    });
});

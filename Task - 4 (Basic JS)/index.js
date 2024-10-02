function validateForm(event) {
    event.preventDefault(); // Prevent form submission for validation

    // Clear previous validation messages
    clearValidationMessages();

    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirm_password').value;
    const dob = document.getElementById('dob').value;
    const phone = document.getElementById('phone').value;

    let isValid = true;

    // Manual validation
    if (!name) {
        showValidationMessage('name', "Full Name is required.");
        isValid = false;
    }

    if (!email) {
        showValidationMessage('email', "Email is required.");
        isValid = false;
    } else {
        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            showValidationMessage('email', "Please enter a valid email address.");
            isValid = false;
        }
    }

    if (!password) {
        showValidationMessage('password', "Password is required.");
        isValid = false;
    } else if (password.length < 6) {
        showValidationMessage('password', "Password must be at least 6 characters long.");
        isValid = false;
    }

    if (password !== confirmPassword) {
        showValidationMessage('confirm_password', "Passwords do not match. Please try again.");
        isValid = false;
    }

    if (!dob) {
        showValidationMessage('dob', "Date of Birth is required.");
        isValid = false;
    }

    if(!phone){
        showValidationMessage('phone',"Phone no. is required.")
    }
    else{
        const phonePattern = /^[7-9][0-9]{9}$/;
        if (!phonePattern.test(phone)) {
            showValidationMessage('phone', "Please enter a valid phone number (10 digits, starting with 7-9).");
            isValid = false;
        }
    }

    // Confirm submission if all fields are valid
    if (isValid) {
        const confirmation = confirm("Do you want to submit the form?");
        if (confirmation) {
            document.getElementById('registrationForm').submit();
        }
    }
}

function showValidationMessage(field, message) {
    const messageSpan = document.getElementById(`${field}_error`);
    messageSpan.textContent = message;
    messageSpan.style.display = 'block';
}

function clearValidationMessages() {
    const errorSpans = document.querySelectorAll('.error-message');
    errorSpans.forEach(span => {
        span.textContent = '';
        span.style.display = 'none';
    });
}

function handleFocus(event) {
    event.target.style.backgroundColor = "#f0f8ff";
}

function handleBlur(event) {
    event.target.style.backgroundColor = "";
}

document.addEventListener("DOMContentLoaded", () => {
    const inputs = document.querySelectorAll('.form-control');
    inputs.forEach(input => {
        input.addEventListener('focus', handleFocus);
        input.addEventListener('blur', handleBlur);
    });
});

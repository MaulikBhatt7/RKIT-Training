$(function () {
    // Function to calculate age based on birth date
    function calculateAge(birthDate) {
        var today = new Date();
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        return age;
    }

    // Full Name (TextBox)
    $("#name").dxTextBox({
        placeholder: "Enter Full Name",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Full Name is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Email (TextBox)
    $("#email").dxTextBox({
        placeholder: "Enter Email",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Email is required"
        }, {
            type: "email",
            message: "Please enter a valid email address"
        }],
        validationGroup: "onboardingForm"
    });

    // Mobile Number (TextBox with Mask)
    $("#mobile").dxTextBox({
        mask: '+(\\9X) 00000 00000',
        maskRules: {
            X: /[1-9]/,
        },
        placeholder: "Enter Mobile Number",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Mobile Number is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Date of Birth (DateBox)
    $("#dob").dxDateBox({
        value: null,
        pickerType: "rollers",
        onValueChanged: function (e) {
            var dob = e.value;
            if (dob) {
                var age = calculateAge(new Date(dob));
                $("#age").dxNumberBox("instance").option("value", age);
            }
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Date of Birth is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Age (NumberBox)
    $("#age").dxNumberBox({
        value: "",
        readOnly: true,
    }).dxValidator({
        validationRules: [{
            type: "custom",
            validationCallback: function (e) {
                return e.value >= 21;
            },
            message: "Employee must be at least 21 years old"
        }],
        validationGroup: "onboardingForm"
    });

    // Gender (Radio Group)
    $("#gender").dxRadioGroup({
        items: ["Male", "Female", "Other"],
        value: "Male",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Gender is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Job Title (DropDown Box)
    var jobTitles = ["Full Stack Developer", "Flutter Developer", "Project Manager", "Web Designer"];
    $("#job-title").dxDropDownBox({
        value: jobTitles[0],
        dataSource: jobTitles,
        contentTemplate: function (e) {
            var $list = $("<div>").dxList({
                dataSource: e.component.option("dataSource"),
                selectionMode: "single",
                selectedItemKeys: [e.component.option("value")],
                onSelectionChanged: function (args) {
                    e.component.option("value", args.addedItems[0]);
                    e.component.close();
                }
            });
            return $list;
        }
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Job Title is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Department (Select Box)
    var departments = ["IT", "HR", "Finance", "Sales"];
    $("#department").dxSelectBox({
        value: departments[0],
        dataSource: departments,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Department is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Password (TextBox)
    $("#password").dxTextBox({
        mode: "password",
        placeholder: "Enter Password",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Password is required"
        }, {
            type: "pattern",
            pattern: "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$",
            message: "Password must be at least 8 characters long and include one uppercase letter, one lowercase letter, and one number"
        }],
        validationGroup: "onboardingForm"
    });

    // Confirm Password (TextBox)
    $("#confirm-password").dxTextBox({
        mode: "password",
        placeholder: "Confirm Password",
        value: "",
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Confirm Password is required"
        }, {
            type: "compare",
            comparisonTarget: function () {
                return $("#password").dxTextBox("instance").option("value");
            },
            message: "Passwords do not match"
        }],
        validationGroup: "onboardingForm"
    });

    // Terms & Conditions (CheckBox)
    $("#terms").dxCheckBox({
        value: false,
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "You must agree to the terms and conditions"
        }],
        validationGroup: "onboardingForm"
    });

    // Resume Upload (FileUploader)
    $("#resume").dxFileUploader({
        accept: 'image/*',
        allowCanceling: true,
        allowedFileExtensions: ['.jpg'],
        multiple: false,
        uploadUrl: 'https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload',
        value: ""
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Resume is required"
        }],
        validationGroup: "onboardingForm"
    });

    // Comments / Overview (TextArea)
    $("#comments").dxTextArea({
        placeholder: "Add Comments",
        value: "",
    });

    // Submit Button Event
    $("#submit").dxButton({
        text: "Submit",
        onClick: function () {
            // Validate the form
            var result = DevExpress.validationEngine.validateGroup("onboardingForm");
            if (result.isValid) {
                // Collect form data
                var formData = {
                    name: $("#name").dxTextBox("instance").option("value"),
                    email: $("#email").dxTextBox("instance").option("value"),
                    mobile: $("#mobile").dxTextBox("instance").option("value"),
                    age: $("#age").dxNumberBox("instance").option("value"),
                    dob: $("#dob").dxDateBox("instance").option("value"),
                    gender: $("#gender").dxRadioGroup("instance").option("value"),
                    jobTitle: $("#job-title").dxDropDownBox("instance").option("value"),
                    department: $("#department").dxSelectBox("instance").option("value"),
                    password: $("#password").dxTextBox("instance").option("value"),
                    confirmPassword: $("#confirm-password").dxTextBox("instance").option("value"),
                    terms: $("#terms").dxCheckBox("instance").option("value"),
                    resume: $("#resume").dxFileUploader("instance").option("value"),
                    comments: $("#comments").dxTextArea("instance").option("value")
                };

                // Log form data to console (for debugging or further processing)
                console.log(formData);

                // Notify the user of successful form submission
                DevExpress.ui.notify("Form Submitted Successfully!", "success", 2000);

                // Save form data to session storage
                sessionStorage.setItem("name", formData.name);
                sessionStorage.setItem("email", formData.email);
                sessionStorage.setItem("mobile", "+9" + formData.mobile);
                sessionStorage.setItem("age", formData.age);
                sessionStorage.setItem("dob", formData.dob);
                sessionStorage.setItem("gender", formData.gender);
                sessionStorage.setItem("job-title", formData.jobTitle);
                sessionStorage.setItem("department", formData.department);
                sessionStorage.setItem("password", formData.password);
                sessionStorage.setItem("confirm-password", formData.confirmPassword);
                sessionStorage.setItem("terms", formData.terms);
                sessionStorage.setItem("resume", formData.resume);
                sessionStorage.setItem("comments", formData.comments);

                // Reload the page
                window.location.reload();
            }
        }
    });
});
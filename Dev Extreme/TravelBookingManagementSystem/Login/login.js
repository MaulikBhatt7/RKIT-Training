$(function () {
    $("#loginContainer").dxForm({
        formData: {
            username: "",
            password: ""
        },
        items: [
            {
                dataField: "R01102",
                label: { text: "Username" },
                editorType: "dxTextBox",
                editorOptions: { placeholder: "Enter your username" }
            },
            {
                dataField: "R01103",
                label: { text: "Password" },
                editorType: "dxTextBox",
                editorOptions: {
                    mode: "password",
                    placeholder: "Enter your password"
                }
            },
            {
                itemType: "button",
                horizontalAlignment: "center",
                buttonOptions: {
                    text: "Login",
                    type: "success",
                    useSubmitBehavior: true,
                    onClick: function (e) {
                        login();
                    }
                }
            }
        ]
    });
});

function login() {
    var formData = $("#loginContainer").dxForm("instance").option("formData");
    
    $.ajax({
        url: "https://localhost:44318/api/login",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(formData),
        success: function (response) {
            console.log(response.Data[0].Token);
            localStorage.setItem("token", response.Data[0].Token);
            localStorage.setItem("role", response.Data[0].Role);
            alert("Login successful!");
            window.location.href = "../Dashboard/dashboard.html";
        },
        error: function (res) {
            console.log(res)
            alert("Invalid username or password.");
        }
    });
}

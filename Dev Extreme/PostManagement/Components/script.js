$(function () {
    // Initial TreeView data (will be populated from API)
    let treeData = [];
    // Array to store saved settings
    let savedSettings = [];

    // Function to fetch posts and transform them into TreeView format
    function fetchPosts() {
        $.ajax({
            url: "https://jsonplaceholder.typicode.com/posts",
            method: "GET",
            success: function (posts) {
                treeData = posts.map((post, index) => {
                    const parentId = index * 2 + 1;
                    const childId = parentId + 1;
                    return [
                        { id: parentId, parentId: 0, text: post.title },
                        { id: childId, parentId: parentId, text: post.body }
                    ];
                }).flat();
                $("#sidebar").dxTreeView("option", "items", treeData);
            },
            error: function () {
                DevExpress.ui.notify({
                    message: "Error fetching posts",
                    type: "error",
                    displayTime: 3000
                });
            }
        });
    }

    // 1. Menu
    $("#menu").dxMenu({
        items: [
            { text: "Add Post", icon: "plus" },
            { text: "Add Settings", icon: "preferences" }
        ],
        onItemClick: function (e) {
            if (e.itemData.text === "Add Product") {
                showPopup();
            } else if (e.itemData.text === "View Settings") {
                showPopover("#menu");
            }
        }
    });

    // 2. TreeView
    const treeView = $("#sidebar").dxTreeView({
        items: treeData,
        dataStructure: "plain",
        keyExpr: "id",
        parentIdExpr: "parentId",
        displayExpr: "text",
        width: 300,
        onItemClick: function (e) {
            showPopover("#sidebar .dx-treeview-item-" + e.itemData.id);
        }
    }).dxTreeView("instance");

    // Fetch posts on page load
    fetchPosts();

    // 3. Popup with Form (For adding new posts)
    const popup = $("#add-post-popup").dxPopup({
        title: "Add New Post",
        width: 400,
        height: 300,
        visible: false,
        showCloseButton: true,
        fullScreen: true,
        contentTemplate: function (contentElement) {
            contentElement.append(
                '<div class="form-container">' +
                '<div id="form"></div>' +
                '</div>'
            );
            $("#form").dxForm({
                formData: { title: "", body: "" },
                items: [
                    {
                        dataField: "title",
                        label: { text: "Title" },
                        validationRules: [
                            { type: "required", message: "Title is required" }
                        ]
                    },
                    {
                        dataField: "body",
                        label: { text: "Body" },
                        editorType: "dxTextArea",
                        validationRules: [
                            { type: "required", message: "Body is required" }
                        ]
                    },
                    {
                        itemType: "button",
                        buttonOptions: {
                            text: "Save",
                            onClick: function (e) {
                                let form = $("#form").dxForm("instance");
                                if (form.validate().isValid) {
                                    savePost();
                                }
                            }
                        }
                    }
                ]
            });
        }
    }).dxPopup("instance");

    // 4. Popover with Form (For settings)
    const popover = $("#add-setting-popover").dxPopover({
        target: "#menu",
        width: 350,
        showTitle: true,
        title: "Quick Settings",
        visible: false,
        contentTemplate: function (contentElement) {
            contentElement.append(
                '<div class="form-container">' +
                '<div id="popover-form"></div>' +
                '</div>'
            );
            $("#popover-form").dxForm({
                formData: { option: "" },
                items: [
                    {
                        dataField: "option",
                        label: { text: "Option" },
                        validationRules: [
                            { type: "required", message: "Option is required" }
                        ]
                    },
                    {
                        itemType: "button",
                        buttonOptions: {
                            text: "Save",
                            onClick: function (e) {
                                let form = $("#popover-form").dxForm("instance");
                                if (form.validate().isValid) {
                                    saveSettings();
                                }
                            }
                        }
                    }
                ]
            });
        }
    }).dxPopover("instance");

    // 5. Load Panel (Replaces Load Indicator)
    const loadPanel = $("#load-panel").dxLoadPanel({
        shadingColor: "rgba(0,0,0,0.4)",
        visible: false,
        showIndicator: true,
        showPane: true,
        message: "Processing...",
        closeOnOutsideClick: false
    }).dxLoadPanel("instance");

    // Functions
    function showPopup() {
        popup.show();
    }

    function showPopover(target) {
        popover.option("target", target);
        popover.show();
    }

    function savePost() {
        const formData = $("#form").dxForm("instance").option("formData");
        popup.hide();
        loadPanel.option("visible", true); // Show LoadPanel

        $.ajax({
            url: "https://jsonplaceholder.typicode.com/posts",
            method: "POST",
            data: JSON.stringify({ title: formData.title, body: formData.body }),
            contentType: "application/json",
            success: function (response) {
                loadPanel.option("visible", false); // Hide LoadPanel

                const newParentId = treeData.length + 1;
                const newChildId = newParentId + 1;
                treeData.push(
                    { id: newParentId, parentId: 0, text: formData.title },
                    { id: newChildId, parentId: newParentId, text: formData.body }
                );
                treeView.option("items", treeData);

                DevExpress.ui.notify({
                    message: "Post added successfully!",
                    type: "success",
                    displayTime: 3000
                });
            },
            error: function () {
                loadPanel.option("visible", false); // Hide LoadPanel
                DevExpress.ui.notify({
                    message: "Error saving post",
                    type: "error",
                    displayTime: 3000
                });
            }
        });
    }

    function saveSettings() {
        const formData = $("#popover-form").dxForm("instance").option("formData");
        loadPanel.option("visible", true); // Show LoadPanel

        setTimeout(() => {
            loadPanel.option("visible", false); // Hide LoadPanel
            popover.hide();

            // Add the new setting to the savedSettings array
            savedSettings.push(formData.option);
            updateSettingsList();

            DevExpress.ui.notify({
                message: "Settings saved successfully!",
                type: "success",
                displayTime: 3000
            });
        }, 1000);
    }

    // Function to update the settings list
    function updateSettingsList() {
        const $settingsList = $("#settings-list");
        $settingsList.empty(); // Clear existing items
        savedSettings.forEach((setting, index) => {
            $settingsList.append(`<li>Setting ${index + 1}: ${setting}</li>`);
        });
    }
}); 
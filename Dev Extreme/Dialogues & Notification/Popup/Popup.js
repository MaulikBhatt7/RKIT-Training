$(function () {
    // Button to Show Normal Popup
    $("#showPopupButton").dxButton({
        text: "Show Popup",
        width: 300,
        type: "default",
        onClick: function () {
            popup.show();
        }
    });

    // Button to Show Popup with ScrollView
    $("#showPopupWithScrollViewButton").dxButton({
        text: "Show Popup with ScrollView",
        width: 300,
        type: "default",
        onClick: function () {
            popupWithScrollView.show();
        }
    });

    // Normal Popup Instance
    let popup = $("#popupContainer").dxPopup({
        title: "DevExtreme Popup Demo",
        width: 400,
        height: 250,
        visible: false,
        closeOnOutsideClick: true,
        showCloseButton: true,
        dragEnabled: false,
        resizeEnabled: true,
        shading: true,
        shadingColor: "rgba(255, 255, 0, 0.8)",
        fullScreen: false,
        showTitle: true,
        animation: {
            show: { type: "fade", duration: 500 },
            hide: { type: "fade", duration: 300 }
        },
        toolbarItems: [
            {
                toolbar: "bottom",
                location: "after",
                widget: "dxButton",
                options: {
                    text: "Close",
                    onClick: function () {
                        popup.hide();
                    }
                }
            }
        ],
        onShowing: function () {
            console.log("Popup is about to show");
        },
        onShown: function () {
            console.log("Popup is shown");
        },
        onHiding: function () {
            console.log("Popup is about to hide");
        },
        onHidden: function () {
            console.log("Popup is hidden");
        }
    }).dxPopup("instance");


    // Content for ScrollView
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
        title: "Popup with ScrollView",
        width: 360,
        height: 320,
        visible: false,
        closeOnOutsideClick: true,
        showCloseButton: true,
        dragEnabled: true,
        resizeEnabled: true,
        toolbarItems: [
            {
                widget: "dxButton",
                toolbar: "bottom",
                location: "center",
                options: {
                    text: "Close",
                    type: "default",
                    stylingMode: "contained",
                    width: 300,
                    onClick: function () {
                        popupWithScrollView.hide();
                    }
                }
            }
        ],
        contentTemplate: function () {
            let $scrollView = $("<div/>");
            $scrollView.append($("<div/>").html(scrollViewContent));

            $scrollView.dxScrollView({
                width: "100%",
                height: "100%"
            });

            return $scrollView;
        }
    }).dxPopup("instance");
});

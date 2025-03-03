$(function () {
    let apiUrl = "https://localhost:44318/"; // API base URL
    let editModes = ["row", "batch", "cell", "form", "popup"];
    let selectedMode = "row";

    let token = localStorage.getItem("token");
    let userRole = getUserRoleFromToken(token);

    if (!token) {
        alert("Unauthorized access. Please log in.");
        window.location.href = "../Login/login.html";
    }

    function createDataGrid(containerId, apiEndpoint, columns) {
        let allowEditing = userRole === "admin";

        $(containerId).dxDataGrid({
            dataSource: new DevExpress.data.CustomStore({
                key: columns[0].dataField,
                load: () =>
                    $.ajax({
                    url: apiEndpoint,
                    method: "GET",
                    headers: { Authorization: `Bearer ${token}` },
                    dataType: "json"
                    }).then((data) => {
                        console.log(data.Data)
                        return data.Data;
                }).fail(handleAjaxError),

                insert: (values) => allowEditing ? $.ajax({
                    url: apiEndpoint,
                    method: "POST",
                    headers: { Authorization: `Bearer ${token}`, "Content-Type": "application/json" },
                    data: JSON.stringify(values)
                }).fail(handleAjaxError) : null,

                update: (key, values) => allowEditing ? $.ajax({
                    url: `${apiEndpoint}/${key}`,
                    method: "PUT",
                    headers: { Authorization: `Bearer ${token}`, "Content-Type": "application/json" },
                    data: JSON.stringify(values)
                }).fail(handleAjaxError) : null,

                remove: (key) => allowEditing ? $.ajax({
                    url: `${apiEndpoint}/${key}`,
                    method: "DELETE",
                    headers: { Authorization: `Bearer ${token}` }
                }).fail(handleAjaxError) : null
            }),
            keyExpr: columns[0].dataField,
            repaintChangesOnly: true,
            columns: columns,
            editing: {
                mode: selectedMode,
                allowUpdating: allowEditing,
                allowAdding: allowEditing,
                allowDeleting: allowEditing,
                useIcons: true
            },
            paging: { pageSize: 10 },
            filterPanel: { visible: true }
        });
    }

    function getUserRoleFromToken(token) {
        if (!token) return "user";
        try {
            let payload = JSON.parse(atob(token.split(".")[1]));
            return payload.role || "user";
        } catch (e) {
            console.error("Invalid token format");
            return "user";
        }
    }

    function handleAjaxError(xhr) {
        if (xhr.status === 401) {
            alert("Session expired. Please log in again.");
            localStorage.removeItem("token");
            window.location.href = "../Login/login.html";
        } else {
            alert("Error: " + xhr.responseText);
        }
    }

    $("#logoutButton").click(function () {
        localStorage.removeItem("token");
        alert("Logged out successfully.");
        window.location.href = "../Login/login.html";
    });

    let grids = {
        "Flights": {
            api: `${apiUrl}/get-all-flights`,
            columns: [
                { dataField: "T01F01", caption: "Flight ID", allowEditing: false },
                { dataField: "T01F02", caption: "Flight Number" },
                { dataField: "T01F03", caption: "Departure City" },
                { dataField: "T01F04", caption: "Arrival City" },
                { dataField: "T01F05", caption: "Departure Time", dataType: "datetime" },
                { dataField: "T01F06", caption: "Arrival Time", dataType: "datetime" },
                { dataField: "T01F07", caption: "Price", dataType: "number", format: "currency" },
                { dataField: "T01F08", caption: "Airline" }
            ]
        },
        "Hotels": {
            api: `${apiUrl}/get-all-hotels`,
            columns: [
                { dataField: "L01F01", caption: "Hotel ID", allowEditing: false },
                { dataField: "L01F02", caption: "Hotel Name" },
                { dataField: "L01F03", caption: "City" },
                { dataField: "L01F04", caption: "Price per Night", dataType: "number", format: "currency" },
                { dataField: "L01F05", caption: "Rating", dataType: "number" },
                { dataField: "L01F06", caption: "Available Rooms", dataType: "number" }
            ]
        },
        "Bookings": {
            api: `${apiUrl}/get-all-bookings`,
            columns: [
                { dataField: "K01F01", caption: "Booking ID", allowEditing: false },
                { dataField: "K01F02", caption: "Customer Name" },
                { dataField: "K01F03", caption: "Email" },
                { dataField: "K01F04", caption: "Booking Date", dataType: "datetime" },
                { dataField: "K01F05", caption: "Type" },
                { dataField: "K01F06", caption: "Reference ID", dataType: "number" }
            ]
        },
        "Users": {
            api: `${apiUrl}/get-all-users`,
            columns: [
                { dataField: "R01F01", caption: "User ID", allowEditing: false },
                { dataField: "R01F02", caption: "Username" },
                { dataField: "R01F04", caption: "Email" },
                { dataField: "R01F05", caption: "Role" }
            ]
        }
    };

    $("#tabPanelContainer").dxTabPanel({
        items: Object.keys(grids).map(title => ({ title, template: () => $("<div>").append($("<div>").attr("id", `${title.toLowerCase()}Grid`)) })),
        animationEnabled: true,
        selectedIndex: 0,
        onSelectionChanged: function (e) {
            let title = e.addedItems[0].title;
            createDataGrid(`#${title.toLowerCase()}Grid`, grids[title].api, grids[title].columns);
        }
    });

    if (userRole === "admin") {
        $("#editModeSelector").dxDropDownBox({
            value: selectedMode,
            placeholder: "Select Editing Mode",
            contentTemplate: function (e) {
                let list = $("<div>").dxList({
                    dataSource: editModes,
                    selectionMode: "single",
                    selectedItem: selectedMode,
                    onItemClick: function (event) {
                        selectedMode = event.itemData;
                        e.component.option("value", selectedMode);
                        createDataGrid("#flightsGrid", grids["Flights"].api, grids["Flights"].columns);
                        e.component.close();
                    }
                });
                return list;
            }
        });
    }
    createDataGrid("#flightsGrid", grids["Flights"].api, grids["Flights"].columns);
});
$(function () {
    let apiUrl = "https://localhost:44318/"; // API base URL
    let editModes = ["row", "batch", "cell", "form", "popup"];
    let selectedMode = "form";

    let token = localStorage.getItem("token");
    let userRole = localStorage.getItem("role");

    let fieldMappings = {
        "L01F01": "L01101",
        "L01F02": "L01102",
        "L01F03": "L01103",
        "L01F04": "L01104",
        "L01F05": "L01105",
        "L01F06": "L01106",
        "T01F01": "T01101",
        "T01F02": "T01102",
        "T01F03": "T01103",
        "T01F04": "T01104",
        "T01F05": "T01105",
        "T01F06": "T01106",
        "T01F07": "T01107",
        "T01F08": "T01108",
        "K01F01": "K01101",
        "K01F02": "K01102",
        "K01F03": "K01103",
        "K01F04": "K01104",
        "K01F05": "K01105",
        "K01F06": "K01106",
        "R01F01": "R01101",
        "R01F03": "R01103",
        "R01F02": "R01102",
        "R01F04": "R01104",
        "R01F05": "R01105"
    };

    if (!token) {
        alert("Unauthorized access. Please log in.");
        window.location.href = "../Login/login.html";
    }

    function createDataGrid(containerId, tableKey, columns) {
        let allowEditing = userRole === "Admin";

        $(containerId).dxDataGrid({
            dataSource: new DevExpress.data.CustomStore({
                key: columns[0].dataField,
                load: () => 
                    (containerId !== "#bookingsGrid" || userRole === "Admin") ? $.ajax({
                        url: `${apiUrl}get-all-${tableKey}s`,
                        method: "GET",
                        headers: { Authorization: `Bearer ${token}` },
                        dataType: "json"
                    }).then((data) => data.Data).fail(handleAjaxError) : null,

                insert: (values) => {
                    console.log()
                    allowEditing ? $.ajax({
                        url: `${apiUrl}add-${tableKey}`,
                        method: "POST",
                        headers: { Authorization: `Bearer ${token}`, "Content-Type": "application/json" },
                        data: JSON.stringify(mapRequestData(values))
                    }).fail(handleAjaxError) : null
                },

                update: (key, values) => {
                    if (allowEditing) {
                        // Load the existing data for the key
                        $.ajax({
                            url: `${apiUrl}get-${tableKey}-by-id`,
                            method: "GET",
                            headers: { Authorization: `Bearer ${token}` },
                            data: { id: key},
                            dataType: "json"
                        }).then((existingData) => {
                            // Merge existing data with the new values
                            console.log(existingData)
                            let updatedData = { ...existingData.Data[0], ...values };
                            console.log(mapRequestData(updatedData))
                            // Update the data
                            $.ajax({
                                url: `${apiUrl}update-${tableKey}`,
                                method: "PUT",
                                headers: { Authorization: `Bearer ${token}`, "Content-Type": "application/json" },
                                data: JSON.stringify(mapRequestData(updatedData))
                            }).fail(handleAjaxError);
                        }).fail(handleAjaxError);
                    }
                },

                remove: (key) => allowEditing ? $.ajax({
                    url: `${apiUrl}delete-${tableKey}`,
                    method: "DELETE",
                    headers: { Authorization: `Bearer ${token}` },
                    data: {id: key}
                }).fail(handleAjaxError) : null
            }),
            keyExpr: columns[0].dataField,
            columns: columns,
            editing: {
                mode: 'form',
                allowUpdating: allowEditing,
                allowAdding: allowEditing,
                allowDeleting: allowEditing,
                useIcons: true,
                // form: {
                //     items: columns.concat(userRole === "Admin" && tableKey === "user" ? [{
                //         dataField: "R01F03",
                //         caption: "Password",
                //         editorType: "dxTextBox",
                //         editorOptions: {
                //             mode: "password"
                //         }
                //     }] : [])
                // }
            },
            paging: { pageSize: 10 },
            filterPanel: { visible: true }
        });
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
            key: "flight",
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
            key: "hotel",
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
            key: "booking",
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
            key: "user",
            columns: [
                { dataField: "R01F01", caption: "User ID", allowEditing: false },
                { dataField: "R01F02", caption: "Username" },
                { dataField: "R01F04", caption: "Email" },
                { dataField: "R01F03", caption: "Password", visible: false},
                { dataField: "R01F05", caption: "Role", allowEditing: false }
            ]
        }
    };

    $("#tabPanelContainer").dxTabPanel({
        items: Object.keys(grids).map(title => ({
            title,
            template: () => $("<div>").append($("<div>").attr("id", `${grids[title].key}Grid`))
        })),
        animationEnabled: true,
        selectedIndex: 0,
        onSelectionChanged: function (e) {
            let title = e.addedItems[0].title;
            createDataGrid(`#${grids[title].key}Grid`, grids[title].key, grids[title].columns);
        }
    });

    if (userRole === "Admin") {
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
                        createDataGrid("#flightsGrid", grids["Flights"].key, grids["Flights"].columns);
                        e.component.close();
                    }
                });
                return list;
            }
        });
    }

    function mapRequestData(data) {
        let mappedData = {};
        Object.keys(data).forEach(key => {
            let mappedKey = fieldMappings[key] || key; // Use mapped key if exists, else keep original
            mappedData[mappedKey] = data[key];
        });
        return mappedData;
    }

    createDataGrid("#flightsGrid", grids["Flights"].key, grids["Flights"].columns);
});
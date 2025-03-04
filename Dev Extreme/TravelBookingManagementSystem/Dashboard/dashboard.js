$(function () {
    let apiUrl = "https://localhost:44318/"; // API base URL

    let token = localStorage.getItem("token");
    let userRole = localStorage.getItem("role");

    
    // Title Box Text
    $("#title").append(`<h2>${userRole} Dashboard</h2>`);


    // logout button
     $(function () {
        $("#logoutButton").dxButton({
            text: "Logout",
            type: "danger",
            icon: "runner",
            onClick: function () {
                localStorage.removeItem("token");
                alert("Logged out successfully.");
                window.location.href = "../Login/login.html";
            }
        });
    });

    // Field mapping object
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


    // Grid Creation function
    
    function createDataGrid(containerId, tableKey, columns) {
        let allowEditing = userRole === "Admin";
        console.log(columns)
        $(containerId).dxDataGrid({
            allowColumnResizing: true,
            dataSource: new DevExpress.data.CustomStore({
                key: columns[0].dataField,
                load: () => 
                    (containerId != "#bookingGrid" || userRole == "Admin") ? $.ajax({
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
                        url: `${apiUrl}delete-${tableKey}?id=${key}`, // Send id as a query parameter
                        method: "DELETE",
                        headers: { Authorization: `Bearer ${token}` }
                    }).fail(handleAjaxError) : null
                }),
            columns: columns,
            editing: {
                mode: 'form',
                allowUpdating: allowEditing,
                allowAdding: allowEditing,
                allowDeleting: allowEditing,
                useIcons: true,
            },
            paging: {
                enabled: true,
                pageIndex: 0,
                pageSize: 5
            },
            pager: {
                allowedPageSizes: [2,5,10],
                infoText: "Page No. {0} of {1} (Total {2} items)",
                displayMode: "adaptive", // compact, // full
                showInfo:true,
                showNavigationButtons: true,
                showPageSizeSelector:true,
                visible:true
            },

            groupPanel: {
                // Allow dragging of columns to the group panel
                allowColumnDragging: true,
                
                // Text to display when the group panel is empty
                emptyPanelText: "Drag Column Here To Group",
                
                // Make the group panel visible
                visible: true,
            },
                
            // Configure the filter panel settings
            filterPanel: {
                // Disable the filter builder
                filterEnabled: true,

                // Show the filter panel
                visible: true,

                text: {
                    // Custom text for filter creation
                    createFilter: "Create your filter"
                }
            },

            // Configure the filter row settings
            filterRow: {
                // Display the filter row
                visible: true,

                // Apply the filter only when the user clicks the apply button
                applyFilter: 'onClick',

                // Custom text for the apply filter button
                applyFilterText: 'Apply Filter',

                // Custom text for the end value in the 'between' filter operation
                betweenEndText: 'To',

                // Custom text for the start value in the 'between' filter operation
                betweenStartText: 'From',

                // Show the operation chooser in the filter row
                showOperationChooser: true,
            },

            sorting: {
                // Enable multiple column sorting
                mode: "multiple",

                // Show sort indexes when multiple sorting is applied
                showSortIndexes: true,
            },

            
            selection: {
                // Enable multiple row selection
                mode: "multiple",

                // Set the selection mode for the "Select All" checkbox
                selectAllMode: "page",

                // Set when checkboxes should be visible
                showCheckBoxesMode: "always",

                // Allow selecting all rows
                allowSelectAll: true,
            },

            headerFilter: {
                // Enables or disables search in the header filter
                allowSearch: true,

                // Defines the delay before searching (in milliseconds)
                searchTimeout: 1000,

                // Shows or hides the header filter
                visible: true,

                // Defines the width of the header filter
                width: 500
            },

             // Display borders around the entire grid
            showBorders: true,

            // Show vertical lines between columns
            showColumnLines: true,

            // Show horizontal lines between rows
            showRowLines: true,

            // Enable alternating row colors for better readability
            rowAlternationEnabled: true, 

            summary: {
                // Define total summary items
                totalItems: [
                    {
                        // Display the count of records
                        column: columns[0].dataField,
                        summaryType: "count",
                        displayFormat: "Total Records: {0}"
                    },
                ]
            },

            export: {
                enabled: true,
                allowExportSelectedData: true,
            },

            onExporting(e) {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet(tableKey);
        
                DevExpress.excelExporter.exportDataGrid({
                  component: e.component,
                  worksheet,
                  autoFilterEnabled: true,
                }).then(() => {
                  workbook.xlsx.writeBuffer().then((buffer) => {
                    saveAs(new Blob([buffer], { type: 'application/octet-stream' }), `${tableKey}.xlsx`);
                  });
                });
            },

            onToolbarPreparing: function(e) {
            let dataGrid = e.component;
                e.toolbarOptions.items.unshift(
                    {
                        location: "after",
                        widget: "dxButton",
                        options: {
                            text: "Clear Filters",
                            icon: "clear",
                            onClick: function () {
                                dataGrid.clearFilter(); // Clears all applied header filters
                            }
                        }
                    }
                );
            },

            // Enable Column Hiding
            columnHidingEnabled: true,

            // // Enable State Storing in LocalStorage
            // stateStoring: {
            //     enabled: true,
            //     type: 'localStorage',
            //     storageKey: 'MyLocalStorage',
            // },

            scrolling: {
                    // Defines the scrolling mode:
                    mode: "infinite",

                    // Defines how rows are rendered:
                    rowRenderingMode: "virtual",

                    // Determines if users can scroll by dragging the content:
                    scrollByContent: true,

                    // Allows scrolling using the scrollbar thumb:
                    scrollByThumb: true,

                    // Specifies whether to use native scrolling:
                    useNative: false,

                    // Controls when the scrollbar is displayed:
                    showScrollbar: "onScroll"
            },
            
            height: 500


        });
    }

    // Error handling function
    function handleAjaxError(xhr) {
        if (xhr.status === 401) {
            alert("Session expired. Please log in again.");
            localStorage.removeItem("token");
            window.location.href = "../Login/login.html";
        } else {
            alert("Error: " + xhr.responseText);
        }
    }



    let grids = {
        "Flights": {
            key: "flight",
            columns: [
            { 
                dataField: "T01F01", 
                caption: "Flight ID", 
                allowEditing: false,
                validationRules: [
                    { type: "range", min: 0, max: 2147483647, message: "Flight ID must be 0 or a positive integer." }
                ]
            },
            { 
                dataField: "T01F02", 
                caption: "Flight Number",
                validationRules: [
                    { type: "required", message: "Flight number is required." },
                    { type: "stringLength", max: 20, message: "Flight number cannot exceed 20 characters." }
                ]
            },
            { 
                dataField: "T01F03", 
                caption: "Departure City",
                validationRules: [
                    { type: "required", message: "Departure city is required." },
                    { type: "stringLength", max: 100, message: "Departure city cannot exceed 100 characters." }
                ]
            },
            { 
                dataField: "T01F04", 
                caption: "Arrival City",
                validationRules: [
                    { type: "required", message: "Arrival city is required." },
                    { type: "stringLength", max: 100, message: "Arrival city cannot exceed 100 characters." }
                ]
            },
            { 
                dataField: "T01F05", 
                caption: "Departure Time", 
                dataType: "datetime",
                validationRules: [
                    { type: "required", message: "Departure time is required." }
                ]
            },
            { 
                dataField: "T01F06", 
                caption: "Arrival Time", 
                dataType: "datetime",
                validationRules: [
                    { type: "required", message: "Arrival time is required." }
                ]
            },
            { 
                dataField: "T01F07", 
                caption: "Price", 
                dataType: "number", 
                format: "currency",
                validationRules: [
                    { type: "range", min: 0.01, max: 999999999, message: "Price must be greater than 0." }
                ]
            },
            { 
                dataField: "T01F08", 
                caption: "Airline",
                validationRules: [
                    { type: "required", message: "Airline name is required." },
                    { type: "stringLength", max: 100, message: "Airline name cannot exceed 100 characters." }
                ]
            }
        ]

        },
        "Hotels": {
            key: "hotel",
            columns: [
            { 
                dataField: "L01F01", 
                caption: "Hotel ID", 
                allowEditing: false,
                validationRules: [
                    { type: "range", min: 0, max: 2147483647, message: "Hotel ID must be 0 or a positive integer." }
                ]
            },
            { 
                dataField: "L01F02", 
                caption: "Hotel Name",
                validationRules: [
                    { type: "required", message: "Hotel name is required." },
                    { type: "stringLength", max: 100, message: "Hotel name cannot exceed 100 characters." }
                ]
            },
            { 
                dataField: "L01F03", 
                caption: "City",
                validationRules: [
                    { type: "required", message: "City of the hotel is required." },
                    { type: "stringLength", max: 100, message: "City name cannot exceed 100 characters." }
                ]
            },
            { 
                dataField: "L01F04", 
                caption: "Price per Night", 
                dataType: "number", 
                format: "currency",
                validationRules: [
                    { type: "range", min: 0.01, max: 999999999, message: "Price per night must be greater than 0." }
                ]
            },
            { 
                dataField: "L01F05", 
                caption: "Rating", 
                dataType: "number",
                validationRules: [
                    { type: "range", min: 1, max: 5, message: "Hotel rating must be between 1 and 5." }
                ]
            },
            { 
                dataField: "L01F06", 
                caption: "Available Rooms", 
                dataType: "number",
                validationRules: [
                    { type: "range", min: 0, max: 2147483647, message: "Number of available rooms must be a non-negative integer." }
                ]
            }
        ]

        },
        "Bookings": {
            key: "booking",
            columns: [
                { 
                    dataField: "K01F01", 
                    caption: "Booking ID", 
                    allowEditing: false,
                    validationRules: [
                        { type: "range", min: 0, max: 2147483647, message: "Booking ID must be 0 or a positive integer." }
                    ]
                },
                { 
                    dataField: "K01F02", 
                    caption: "Customer Name",
                    validationRules: [
                        { type: "required", message: "Customer name is required." },
                        { type: "stringLength", max: 100, message: "Customer name cannot exceed 100 characters." }
                    ]
                },
                { 
                    dataField: "K01F03", 
                    caption: "Email",
                    validationRules: [
                        { type: "required", message: "Customer email is required." },
                        { type: "email", message: "Invalid email format." }
                    ]
                },
                { 
                    dataField: "K01F04", 
                    caption: "Booking Date", 
                    dataType: "datetime",
                    validationRules: [
                        { type: "required", message: "Booking date is required." }
                    ]
                },
                { 
                    dataField: "K01F05", 
                    caption: "Type",
                    validationRules: [
                        { type: "required", message: "Booking type is required." },
                        { type: "stringLength", max: 50, message: "Booking type cannot exceed 50 characters." }
                    ]
                },
                { 
                    dataField: "K01F06", 
                    caption: "Reference ID", 
                    dataType: "number",
                    validationRules: [
                        { type: "range", min: 1, max: 2147483647, message: "Reference ID must be a positive integer." }
                    ]
                }
            ]

        },
        "Users": {
            key: "user",
            columns: [
                { 
                    dataField: "R01F01", 
                    caption: "User ID", 
                    allowEditing: false,
                    validationRules: [
                        { type: "range", min: 0, max: 2147483647, message: "User ID must be 0 or a positive integer." }
                    ]
                },
                { 
                    dataField: "R01F02", 
                    caption: "Username",
                    validationRules: [
                        { type: "required", message: "Username is required." },
                        { type: "stringLength", max: 50, message: "Username cannot exceed 50 characters." }
                    ]
                },
                { 
                    dataField: "R01F04", 
                    caption: "Email",
                    validationRules: [
                        { type: "required", message: "Email is required." },
                        { type: "email", message: "Invalid email format." },
                        { type: "stringLength", max: 100, message: "Email cannot exceed 100 characters." }
                    ]
                },
                { 
                    dataField: "R01F03", 
                    caption: "Password", 
                    visible: false,
                    // allowEditing: false,
                    validationRules: [
                        { type: "required", message: "Password is required." },
                        { type: "stringLength", max: 100, message: "Password hash cannot exceed 100 characters." }
                    ],
                },
                {
                    dataField: "R01F05",
                    caption: "Role",
                    allowEditing: true,
                    lookup: {
                        dataSource: new DevExpress.data.ArrayStore({
                            data: [
                                { name: "Admin" },
                                { name: "User" }
                            ],
                            key: "name" // Using the role name as the key
                        }),
                        valueExpr: "name", // The actual value stored
                        displayExpr: "name" // The value displayed in the dropdown
                    },
                    validationRules: [
                        { type: "required", message: "Role is required." }
                    ]
                }
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

    // Ensure the first grid is initialized
    let firstTab = $("#tabPanelContainer").dxTabPanel("instance").option("items")[0];
    if (firstTab) {
        createDataGrid(`#${grids[firstTab.title].key}Grid`, grids[firstTab.title].key, grids[firstTab.title].columns);
    }

    function mapRequestData(data) {
        let mappedData = {};
        Object.keys(data).forEach(key => {
            let mappedKey = fieldMappings[key] || key; // Use mapped key if exists, else keep original
            mappedData[mappedKey] = data[key];
        });
        return mappedData;
    }  
});
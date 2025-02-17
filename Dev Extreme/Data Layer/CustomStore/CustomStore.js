$(function () {
    const mockApiUrl = "url";

    // Initialize CustomStore
    var customStore = new DevExpress.data.CustomStore({
        key: "id", 
        // Load data with all load options
        load: function (loadOptions) {
            console.log("Load Options:", loadOptions);
            let params = {};

            // Handling Sorting
            if (loadOptions.sort) {
                params._sort = loadOptions.sort[0].selector;
                params._order = loadOptions.sort[0].desc ? "desc" : "asc";
            }

            // Handling Filtering
            if (loadOptions.filter) {
                params._filter = JSON.stringify(loadOptions.filter);
            }

            // Handling Pagination
            if (loadOptions.skip !== undefined) {
                params._start = loadOptions.skip;
            }
            if (loadOptions.take !== undefined) {
                params._limit = loadOptions.take;
            }

            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                data: params,
                dataType: "json"
            });
        },
        loadMode: 'raw',

        // Fetch a single item by key
        byKey: function (key) {
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "GET",
                dataType: "json"
            });
        },

        // Insert a new record
        insert: function (values) {
            console.log("Inserting:", values);
            return $.ajax({
                url: mockApiUrl,
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        // Update an existing record
        update: function (key, values) {
            console.log("Updating:", key, values);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "PUT",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        // Remove a record
        remove: function (key) {
            console.log("Removing:", key);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "DELETE"
            });
        },

        // Get total count (useful for pagination)
        totalCount: function (loadOptions) {
            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                dataType: "json"
            }).then(data => data.length);
        },

        // Custom handling of error messages
        errorHandler: function (error) {
            console.error("CustomStore Error:", error);
            alert("An error occurred while processing the request.");
        },
        useDefaultSearch: true
    });

    // Function to fetch and render the data
    function fetchData() {
        customStore.load({
            filter: ["salary", ">", "90000"],
            skip: 2,
            take: 3,
            sort: [{ selector: "salary", desc: true }],
        }).done(function (data) {
            renderTable(data);
        }).fail(function (error) {
            console.error("Load Error:", error);
        });
    }

    // Function to render the table
    function renderTable(data) {
        var tableBody = $("#dataTable tbody");
        tableBody.empty(); // Clear existing rows
        data.forEach(function (item) {
            var row = $("<tr>")
                .append($("<td>").text(item.name))
                .append($("<td>").text(item.salary || "N/A"))
                .append($("<td>").html(`
                    <button class="editButton" data-id="${item.id}">Edit</button>
                    <button class="deleteButton" data-id="${item.id}">Delete</button>
                `));
            tableBody.append(row);
        });
    }

    // Show form for adding new data
    $("#addButton").click(function () {
        $("#formContainer").show();
        $("#saveButton").data("action", "add"); // Add action for save
        $("#name").val("");
        $("#salary").val("");
    });

    // Handle save button click (both Add and Update)
    $("#saveButton").click(function () {
        var name = $("#name").val();
        var salary = $("#salary").val();
        var action = $(this).data("action");

        if (name && salary) {
            var data = { name: name, salary: parseInt(salary) };

            if (action === "add") {
                // Add new record
                customStore.insert(data).done(function () {
                    fetchData();
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error adding record");
                });
            } else if (action === "update") {
                var id = $(this).data("id");
                customStore.update(id, data).done(function () {
                    fetchData();
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error updating record");
                });
            }
        }
        
    });

    // Handle cancel button click
    $("#cancelButton").click(function () {
        $("#formContainer").hide();
    });

    // Edit record
    $(document).on("click", ".editButton", function () {
        var id = $(this).data("id");
        customStore.byKey(id).done(function (data) {
            $("#name").val(data.name);
            $("#salary").val(data.salary);
            $("#formContainer").show();
            $("#saveButton").data("action", "update").data("id", id);
        }).fail(function () {
            alert("Error fetching record");
        });
    });

    // Delete record
    $(document).on("click", ".deleteButton", function () {
        var id = $(this).data("id");
        customStore.remove(id).done(function () {
            fetchData();
        }).fail(function () {
            alert("Error deleting record");
        });
    });

    // Load initial data
    fetchData();
});

$(function () {
    var mockApiUrl = "https://67b2fe86bc0165def8cf777b.mockapi.io/employee/employees";

    /**
     * DevExtreme CustomStore for handling CRUD operations
     * Provides sorting, filtering, pagination, and error handling.
     */
    var customStore = new DevExpress.data.CustomStore({
        key: "id",

        /**
         * Function: Load
         * Description: Fetches data with sorting, filtering, and pagination.
         * Parameters: loadOptions (sorting, filtering, pagination details)
         * Returns: AJAX Promise
         */
        load: function (loadOptions) {
            console.log("Load Options:", loadOptions);
            let params = {};

            //if (loadOptions.sort) {
            //    params._sort = loadOptions.sort[0].selector;
            //    params._order = loadOptions.sort[0].desc ? "desc" : "asc";
            //}

            //if (loadOptions.filter) {
            //    params._filter = JSON.stringify(loadOptions.filter);
            //}

            //if (loadOptions.skip !== undefined) {
            //    params._start = loadOptions.skip;
            //}
            //if (loadOptions.take !== undefined) {
            //    params._limit = loadOptions.take;
            //}

            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                //data: params,
                dataType: "json"
            });
        },
        loadMode: 'raw',

        /**
         * Function: ByKey
         * Description: Fetches a single record by key.
         * Parameters: key (ID of the record)
         * Returns: AJAX Promise
         */
        byKey: function (key) {
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "GET",
                dataType: "json"
            });
        },

        /**
         * Function: Insert
         * Description: Adds a new record to the database.
         * Parameters: values (data object containing new record fields)
         * Returns: AJAX Promise
         */
        insert: function (values) {
            console.log("Inserting:", values);
            return $.ajax({
                url: mockApiUrl,
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        /**
         * Function: Update
         * Description: Updates an existing record in the database.
         * Parameters: key (ID of the record), values (updated data)
         * Returns: AJAX Promise
         */
        update: function (key, values) {
            console.log("Updating:", key, values);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "PUT",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        /**
         * Function: Remove
         * Description: Deletes a record from the database.
         * Parameters: key (ID of the record to delete)
         * Returns: AJAX Promise
         */
        remove: function (key) {
            console.log("Removing:", key);
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "DELETE"
            });
        },

        /**
         * Function: TotalCount
         * Description: Gets the total number of records for pagination.
         * Parameters: loadOptions (Optional filters or conditions)
         * Returns: AJAX Promise resolving to count
         */
        totalCount: function (loadOptions) {
            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                dataType: "json"
            }).then(data => data.length);
        },

        /**
         * Function: ErrorHandler
         * Description: Handles AJAX errors gracefully.
         * Parameters: error (error object from AJAX)
         * Returns: None
         */
        errorHandler: function (error) {
            console.error("CustomStore Error:", error);
            alert("An error occurred while processing the request.");
        },
        useDefaultSearch: true
    });

    /**
     * Function: FetchData
     * Description: Fetches and renders filtered, sorted, and paginated data.
     * Parameters: None
     * Returns: None
     */
    function FetchData() {
        customStore.load({
            //filter: ["salary", ">", "90000"],
            //skip: 2,
            take: 10,
            //sort: [{ selector: "salary", desc: true }]
        }).done(function (data) {
            console.log(data)
            RenderTable(data);
        }).fail(function (error) {
            console.error("Load Error:", error);
        });
    }

    /**
     * Function: RenderTable
     * Description: Dynamically generates and displays the table with data.
     * Parameters: data (Array of objects from API)
     * Returns: None
     */
    function RenderTable(data) {
        var tableBody = $("#dataTable tbody");
        tableBody.empty();
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

    /**
     * Event: Click - Add Button
     * Description: Displays form for adding a new record.
     * Parameters: None
     * Returns: None
     */
    $("#addButton").click(function () {
        $("#formContainer").show();
        $("#saveButton").data("action", "add");
        $("#name").val("");
        $("#salary").val("");
    });

    /**
     * Event: Click - Save Button
     * Description: Handles form submission for adding or updating records.
     * Parameters: None
     * Returns: None
     */
    $("#saveButton").click(function () {
        var name = $("#name").val();
        var salary = $("#salary").val();
        var action = $(this).data("action");

        if (name && salary) {
            var data = { name: name, salary: parseInt(salary) };

            if (action === "add") {
                customStore.insert(data).done(function () {
                    FetchData();
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error adding record");
                });
            } else if (action === "update") {
                var id = $(this).data("id");
                customStore.update(id, data).done(function () {
                    FetchData();
                    $("#formContainer").hide();
                }).fail(function () {
                    alert("Error updating record");
                });
            }
        }
    });

    /**
     * Event: Click - Cancel Button
     * Description: Hides the form without making any changes.
     * Parameters: None
     * Returns: None
     */
    $("#cancelButton").click(function () {
        $("#formContainer").hide();
    });

    /**
     * Event: Click - Edit Button
     * Description: Loads selected record into the form for editing.
     * Parameters: None
     * Returns: None
     */
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

    /**
     * Event: Click - Delete Button
     * Description: Deletes the selected record.
     * Parameters: None
     * Returns: None
     */
    $(document).on("click", ".deleteButton", function () {
        var id = $(this).data("id");
        customStore.remove(id).done(function () {
            FetchData();
        }).fail(function () {
            alert("Error deleting record");
        });
    });

    // Initial data load
    FetchData();
});

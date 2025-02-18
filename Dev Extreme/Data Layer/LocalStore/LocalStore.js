$(function () {
    var data = [
        { "ID": 1, "Name": "Ram", "Age": 20 },
        { "ID": 2, "Name": "Shyam", "Age": 21 },
        { "ID": 3, "Name": "Krishna", "Age": 20 },
        { "ID": 4, "Name": "Shiv", "Age": 23 }
    ];

    // Create LocalStore DataSource with all available options
    var dataSource = new DevExpress.data.LocalStore({
        name: "dataStore",  // Name of the store in LocalStorage
        key: "ID",          // Key for the data
        data: data,         // Initial data to store
        errorHandler: function (error) {
            console.log("Error:", error);
        },
        //flushInterval: 5000,  // Flush data to localStorage every 5 seconds
        immediate: true,      // Immediately apply changes
        onInserted: function (e) {
            console.log("New record inserted:", e);
        },
        onInserting: function (e) {
            console.log("Before inserting data:", e);
        },
        onLoaded: function (e) {
            console.log("Data loaded:", e);
        },
        onLoading: function (e) {
            console.log("Before loading data:", e);
        },
        onModified: function (e) {
            console.log("Data modified:", e);
        },
        onModifying: function (e) {
            console.log("Before modifying data:", e);
        },
        onPush: function (e) {
            console.log("Data pushed to LocalStorage:", e);
        },
        onRemoved: function (e) {
            console.log("Record removed with ID:", e.key);
        },
        onRemoving: function (e) {
            console.log("Before removing record with ID:", e.key);
        },
        onUpdated: function (e) {
            console.log("Record updated:", e);
        },
        onUpdating: function (e) {
            console.log("Before updating record:", e);
        }
    });

    // Load data
    dataSource.load().then((data) => {
        console.log("Data loaded from LocalStorage:", data);
    });

    // Insert new data
    dataSource.insert({"ID":6,  "Name": "Amit", "Age": 25 }).then((newData) => {
        console.log("New data inserted:", newData);
    });

    // Update existing data
    dataSource.update(2, { "Age": 22 }).then((updatedData) => {
        console.log("Data updated:", updatedData);
    });

    // Remove data
    dataSource.remove(3).then((result) => {
        console.log("Data removed:", result);
    });

    // Get total count of records
    dataSource.totalCount().then((count) => {
        console.log("Total records:", count);
    });

    // Get data by key
    dataSource.byKey(1).then((record) => {
        console.log("Data by key (ID=1):", record);
    });

    // Query data with a filter
    dataSource.load({
        filter: ["Age", ">", 20]
    }).then((filteredData) => {
        console.log("Filtered data (Age > 20):", filteredData);
    });

    // Query data with sorting
    dataSource.load({
        sort: [{ field: "Age", desc: true }]
    }).then((sortedData) => {
        console.log("Sorted data (Age desc):", sortedData);
    });

    // Using the count method
    dataSource.totalCount().then((count) => {
        console.log("Total records:", count);
    });

    dataSource.load({
        select: ["Name"]
    }).then((selectedData) => {
        console.log("Selected fields (Name only):", selectedData);
    });

    // Handling Events (attach dynamically)
    dataSource.on("loaded", function (e) {
        console.log("Custom event: Data loaded with count:", e.length);
    });

    dataSource.on("inserted", function (e) {
        console.log("Custom event: New data inserted with ID:", e.ID);
    });

    dataSource.on("updated", function (e) {
        console.log("Custom event: Data updated with ID:", e.ID);
    });

    dataSource.on("removed", function (e) {
        console.log("Custom event: Data removed with ID:", e.key);
    });

    // Example using clear() method to reset localStorage
    dataSource.clear();

    // Example of pushing data changes to the store
    var changes = [{ type: "insert", key: 5, data: { Name: "Sita", Age: 24 } }];
    dataSource.push(changes)


});

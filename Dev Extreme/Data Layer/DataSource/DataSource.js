$(function () {
    // Sample Data
    var data = [
        { "ID": 1, "Name": "Ram", "Age": 20 },
        { "ID": 2, "Name": "Shyam", "Age": 21 },
        { "ID": 3, "Name": "Krishna", "Age": 20 },
        { "ID": 4, "Name": "Shiv", "Age": 23 },
        { "ID": 5, "Name": "Mohan", "Age": 22 },
        { "ID": 6, "Name": "Sohan", "Age": 24 },
        { "ID": 7, "Name": "Ravi", "Age": 21 },
        { "ID": 8, "Name": "Amit", "Age": 23 },
        { "ID": 9, "Name": "Vijay", "Age": 22 },
        { "ID": 10, "Name": "Anil", "Age": 20 },
        { "ID": 11, "Name": "Sunil", "Age": 25 },
        { "ID": 12, "Name": "Ramesh", "Age": 24 },
        { "ID": 13, "Name": "Suresh", "Age": 22 },
        { "ID": 14, "Name": "Mahesh", "Age": 21 },
        { "ID": 15, "Name": "Naresh", "Age": 23 },
        { "ID": 16, "Name": "Dinesh", "Age": 25 },
        { "ID": 17, "Name": "Ganesh", "Age": 22 },
        { "ID": 18, "Name": "Harish", "Age": 24 },
        { "ID": 19, "Name": "Prakash", "Age": 20 },
        { "ID": 20, "Name": "Rajesh", "Age": 21 },
        { "ID": 21, "Name": "Lokesh", "Age": 23 },
        { "ID": 22, "Name": "Manish", "Age": 22 },
        { "ID": 23, "Name": "Rohit", "Age": 25 },
        { "ID": 24, "Name": "Deepak", "Age": 20 },
        { "ID": 25, "Name": "Vikas", "Age": 23 },
        { "ID": 26, "Name": "Yogesh", "Age": 22 },
        { "ID": 27, "Name": "Vivek", "Age": 24 },
        { "ID": 28, "Name": "Nitin", "Age": 21 },
        { "ID": 29, "Name": "Sachin", "Age": 23 },
        { "ID": 30, "Name": "Pankaj", "Age": 22 },
        { "ID": 31, "Name": "Tarun", "Age": 24 },
        { "ID": 32, "Name": "Arun", "Age": 20 },
        { "ID": 33, "Name": "Kamal", "Age": 23 },
        { "ID": 34, "Name": "Ravindra", "Age": 22 },
        { "ID": 35, "Name": "Gopal", "Age": 24 },
        { "ID": 36, "Name": "Balram", "Age": 21 },
        { "ID": 37, "Name": "Omkar", "Age": 23 },
        { "ID": 38, "Name": "Lalit", "Age": 22 },
        { "ID": 39, "Name": "Dev", "Age": 25 },
        { "ID": 40, "Name": "Bhavesh", "Age": 20 },
        { "ID": 41, "Name": "Chirag", "Age": 23 },
        { "ID": 42, "Name": "Ketan", "Age": 22 },
        { "ID": 43, "Name": "Hemant", "Age": 24 },
        { "ID": 44, "Name": "Pranav", "Age": 21 },
        { "ID": 45, "Name": "Shankar", "Age": 23 },
        { "ID": 46, "Name": "Sagar", "Age": 22 },
        { "ID": 47, "Name": "Jatin", "Age": 24 },
        { "ID": 48, "Name": "Rishi", "Age": 20 },
        { "ID": 49, "Name": "Tejas", "Age": 23 },
        { "ID": 50, "Name": "Varun", "Age": 22 }
    ];

    // Initialize ArrayStore
    var arrayStore = new DevExpress.data.ArrayStore({
        key: "ID",
        data: data
    });

    // Create DataSource
    var dataSource = new DevExpress.data.DataSource({

        // Specify the store to use
        store: arrayStore,

        // Enable or disable pagination
        paginate: false,

        // Number of records per page
        pageSize: 10,

        // Whether to require the total count of records
        requireTotalCount: true,

        // Apply filtering to the data
        filter: ["Age", ">", 15],

        // Sort the data by "Name" in ascending order
        sort: [{ selector: "Name", desc: false }],

        // Group the data by "Age"
        group: ["Age"],

        // Define the search expression (column)
        searchExpr: "Name",

        // Set the search operation type
        searchOperation: "contains",

        // Set the default search value
        searchValue: "",

        // Enable reshaping when data is pushed
        reshapeOnPush: true,

        // Process data after fetching
        postProcess: function (data) {
            console.log(data);
            return data.map(item => ({ ...item, Name: item.Name }));
        },

        // Event triggered when data changes
        onChanged: function () { console.log("Data changed"); },

        // Event triggered on load error
        onLoadError: function (error) { console.error("Load error:", error); },

        // Event triggered when loading state changes
        onLoadingChanged: function (isLoading) { console.log("Loading:", isLoading); },

        // Set timeout for aggregation operations
        pushAggregationTimeout: 300
    });

    // Initialize DevExtreme Grid
    $("#gridContainer").dxDataGrid({
        dataSource: dataSource,
        columns: ["ID", "Name", "Age"],

        // Enable group panel
        groupPanel: { visible: true },

        // Enable search panel
        searchPanel: { visible: true },

        // Enable filter row
        filterRow: { visible: true },

        // Event triggered when grid is initialized
        onInitialized: function (e) {
            var ds = e.component.getDataSource();

            console.log("Filter:", ds.filter());
            console.log("Group:", ds.group());
            console.log("Is Last Page:", ds.isLastPage());
            console.log("Is Loaded:", ds.isLoaded());
            console.log("Is Loading:", ds.isLoading());
            console.log("Items:", ds.items());
            console.log("Key:", ds.key());
            console.log("Load Options:", ds.loadOptions());
            console.log("Page Index:", ds.pageIndex());
            console.log("Page Size:", ds.pageSize());
            console.log("Paginate:", ds.paginate());
            console.log("Require Total Count:", ds.requireTotalCount());
            console.log("Search Expr:", ds.searchExpr());
            console.log("Search Operation:", ds.searchOperation());
            console.log("Search Value:", ds.searchValue());
            console.log("Select:", ds.select());
            console.log("Sort:", ds.sort());
            console.log("Total Count:", ds.totalCount());
        }
    });

    // Example Usage of Methods
    setTimeout(() => {
        console.log("Reloading...");
        dataSource.reload();

        //console.log("Setting new filter...");
        //dataSource.filter(["Age", "<", 26]);
        //dataSource.load();

        console.log("Setting new page size...");
        dataSource.pageSize(5);
        dataSource.load();

        //console.log("Searching for 'Shy'...");
        //dataSource.searchValue("Shy");
        //dataSource.load();
    }, 5000);
});

$(function () {
    var arrayStore = new DevExpress.data.ArrayStore({
        key: "ID",
        data: [
            {
                "ID": 1,
                "Name": "Ram",
                "Age": 20
            },
            {
                "ID": 2,
                "Name": "Shyam",
                "Age": 21
            },
            {
                "ID": 3,
                "Name": "Krishna",
                "Age": 20
            },
            {
                "ID": 4,
                "Name": "Shiv",
                "Age": 23
            }
        ],
        onLoading: function (loadOptions) {
            console.log("Loading data with options:", loadOptions);
        },
        onLoaded: function (result, loadOptions) {
            console.log("Data loaded:", result, "with options:", loadOptions);
        },
        onInserting: function (values) {
            console.log("Inserting item:", values);
        },
        onInserted: function (values, key) {
            console.log("Item inserted:", values, "with key:", key);
        },
        onUpdating: function (key, values) {
            console.log("Updating item with key:", key, "to values:", values);
        },
        onUpdated: function (key, values) {
            console.log("Item updated with key:", key, "to values:", values);
        },
        onRemoving: function (key) {
            console.log("Removing item with key:", key);
        },
        onRemoved: function (key) {
            console.log("Item removed with key:", key);
        },
        onModifying: function (changes) {
            console.log("Modifying changes:", changes);
        },
        onModified: function (changes) {
            console.log("Changes modified:", changes);
        },
        onPush: function (changes) {
            console.log("Pushing changes:", changes);
        }
    });

    // Load data
    arrayStore.load().done(function (data) {
        console.log("Loaded data:", data);
    });

    // Insert a new item
    arrayStore.insert({ id: 5, name: "Shivay", age: 28 }).done(function () {
        console.log("Item inserted");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after insertion:", data);
        });
    });

    // Update an item
    arrayStore.update(3, { age: 36 }).done(function () {
        console.log("Item updated");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after update:", data);
        });
    });

    // Remove an item
    arrayStore.remove(2).done(function () {
        console.log("Item removed");
        arrayStore.load().done(function (data) {
            console.log("Loaded data after removal:", data);
        });
    });

    // Get item by key
    arrayStore.byKey(1).done(function (item) {
        console.log("Item with key 1:", item);
    });
});
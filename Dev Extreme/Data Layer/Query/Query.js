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

// Create a query
var query = DevExpress.data.query(data);

// aggregate(seed, step, finalize)
query.aggregate(
    0, 
    function(accumulator, item) { return accumulator + item.Age; }, 
    function(result) { return result / data.length; }
).done(function(aggregateResult) {
    console.log("Aggregate (Average Age):", aggregateResult);
});

// aggregate(step)
query.aggregate(function(accumulator, item) { return accumulator + 1; })
.done(function(aggregateCount) {
    console.log("Aggregate (Count):", aggregateCount);
});

// avg()
query.avg("Age").done(function(avgAge) {
    console.log("Average Age:", avgAge);
});

// avg(getter)
query.avg(function(item) { return item.Age; }).done(function(avgAgeGetter) {
    console.log("Average Age (Getter):", avgAgeGetter);
});

// count()
query.count().done(function(count) {
    console.log("Count:", count);
});

// enumerate()
query.enumerate().done(function(enumeratedData) {
    console.log("Enumerated Data:", enumeratedData);
});

// filter(criteria)
var filteredData = query.filter(["Age", "=", 20]).toArray();
console.log("Filtered Data (Age = 20):", filteredData);

// filter(predicate)
var filteredDataPredicate = query.filter(function(item) { return item.Age > 20; }).toArray();
console.log("Filtered Data (Age > 20):", filteredDataPredicate);

// groupBy(getter)
var groupedData = query.groupBy("Age").toArray();
console.log("Grouped Data by Age:", groupedData);

// max()
query.max("Age").done(function(maxAge) {
    console.log("Max Age:", maxAge);
});

// max(getter)
query.max(function(item) { return item.Age; }).done(function(maxAgeGetter) {
    console.log("Max Age (Getter):", maxAgeGetter);
});

// min()
query.min("Age").done(function(minAge) {
    console.log("Min Age:", minAge);
});

// min(getter)
query.min(function(item) { return item.Age; }).done(function(minAgeGetter) {
    console.log("Min Age (Getter):", minAgeGetter);
});

// select(getter)
var selectedNames = query.select("Name").toArray();
console.log("Selected Names:", selectedNames);

// slice(skip, take)
var slicedData = query.slice(10, 5).toArray();
console.log("Sliced Data (skip 10, take 5):", slicedData);

// sortBy(getter)
var sortedData = query.sortBy("Name").toArray();
console.log("Sorted Data by Name:", sortedData);

// sortBy(getter, desc)
var sortedDataDesc = query.sortBy("Name", true).toArray();
console.log("Sorted Data by Name (Descending):", sortedDataDesc);

// sum()
query.sum("Age").done(function(sumAge) {
    console.log("Sum of Ages:", sumAge);
});

// sum(getter)
query.sum(function(item) { return item.Age; }).done(function(sumAgeGetter) {
    console.log("Sum of Ages (Getter):", sumAgeGetter);
});

// thenBy(getter)
var sortedThenByData = query.sortBy("Age").thenBy("Name").toArray();
console.log("Sorted Data by Age then Name:", sortedThenByData);

// thenBy(getter, desc)
var sortedThenByDescData = query.sortBy("Age").thenBy("Name", true).toArray();
console.log("Sorted Data by Age then Name (Descending):", sortedThenByDescData);

// toArray()
var dataArray = query.toArray();
console.log("Data Array:", dataArray);

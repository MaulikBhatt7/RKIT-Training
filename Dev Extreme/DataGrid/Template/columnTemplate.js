$(() => {
    // Sample data with random images
    const data = [
        { ID: 1, Name: "Name-1", Age: 30, Image: "https://picsum.photos/50?random=1" },
        { ID: 2, Name: "Name-2", Age: 20, Image: "https://picsum.photos/50?random=2" },
        { ID: 3, Name: "Name-3", Age: 25, Image: "https://picsum.photos/50?random=3" }
    ];

    // Initialize DevExtreme DataGrid
    $("#dataGrid").dxDataGrid({
        dataSource: data, // Set data source
        showBorders: true, // Show grid borders
        columnAutoWidth: true, // Automatically adjust column widths

        // Define columns with custom templates
        columns: [
            { 
                dataField: "ID", 
                caption: "ID", 
                width: 50, // Set column width
                alignment: "center", // Align column content to center
                
                // Center align header text using headerCellTemplate
                headerCellTemplate: function(container) {
                    container.addClass("dx-text-center").text("ID");
                }
            },
            { 
                dataField: "Image",
                caption: "Profile",
                alignment: "center", // Align profile images to center
                
                // Custom template to render images in the grid
                cellTemplate: function(container, options) {
                    $("<img>")
                        .attr("src", options.value) // Set image source
                        .attr("alt", "Profile") // Set alt text for accessibility
                        .css({ 
                            width: "50px", 
                            height: "50px", 
                            "border-radius": "50%" // Make image circular
                        })
                        .appendTo(container); // Append image to cell container
                }
            },
            { 
                dataField: "Name", 
                caption: "Name",
                alignment: "center", // Align names to center
                
                // Center align header text using headerCellTemplate
                headerCellTemplate: function(container) {
                    container.addClass("dx-text-center").text("Name");
                },

                // Custom template to make names bold
                cellTemplate: function(container, options) {
                    $("<span>")
                        .text(options.value) // Display name
                        .css("font-weight", "bold") // Apply bold styling
                        .appendTo(container);
                }
            },
            { 
                dataField: "Age", 
                caption: "Age",
                alignment: "center", // Align ages to center
                
                // Custom template to change text color based on Age value
                cellTemplate: function(container, options) {
                    $("<span>")
                        .text(options.value) // Display age value
                        .css("color", options.value > 22 ? "red" : "green") // Apply red/green color
                        .appendTo(container);
                }
            }
        ],
    });
});

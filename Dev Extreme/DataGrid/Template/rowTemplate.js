$(() => {
    // Initialize DevExtreme DataGrid with a custom row template and centered headers
    $("#dataGrid").dxDataGrid({
        dataSource: data, // Set the data source for the grid
        showBorders: true, // Show grid borders
        columnAutoWidth: true, // Automatically adjust column widths

        // Define columns with centered header captions
        columns: [
            { 
                dataField: "ID", 
                caption: "ID", 
                
                // Custom header cell template to center align the text
                headerCellTemplate: function(container) {
                    container.addClass("dx-text-center").text("ID");
                }
            },
            { 
                dataField: "Name", 
                caption: "Name",

                // Custom header cell template to center align the text
                headerCellTemplate: function(container) {
                    container.addClass("dx-text-center").text("Name");
                }
            },
            { 
                dataField: "Age", 
                caption: "Age",
                // Custom header cell template to center align the text
                headerCellTemplate: function(container) {
                    container.addClass("dx-text-center").text("Age");
                }
            }
        ],

        // Customize row rendering (centering content and applying a gradient background)
        rowTemplate: function(container, item) {
            var data = item.data; // Get row data

            // Create custom row markup with a gradient background and centered text
            var markup = `
                <tr class="dx-row" 
                    style="background: linear-gradient(to right, #12c2e9, #c471ed, #f64f59);"> 
                    
                    <!-- Center-aligned and bold ID column -->
                    <td style="text-align: center; font-weight: bold;">${data.ID}</td>

                    <!-- Center-aligned and bold Name column -->
                    <td style="text-align: center; font-weight: bold;">${data.Name}</td>

                    <!-- Center-aligned and bold Age column with conditional text color -->
                    <td style="text-align: center; font-weight: bold; 
                               color: ${data.Age > 22 ? 'gold' : 'purple'};">
                        ${data.Age}
                    </td>
                </tr>
            `;

            // Append the custom row markup to the container
            container.append(markup);
        }
    });
});

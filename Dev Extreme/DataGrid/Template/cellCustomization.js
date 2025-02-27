$(() => {
    $("#dataGrid").dxDataGrid({
        dataSource: data2, 
        showBorders: true,
        columnAutoWidth: true,

        columns: [
            { 
                dataField: "ID", 
                caption: "ID"
            },
            { 
                dataField: "FirstName", 
                caption: "First Name"
            },
            { 
                dataField: "LastName", 
                caption: "Last Name"
            },
            { 
                dataField: "Age", 
                caption: "Age" 
            }
        ],

        onCellPrepared: function(e) {
            if (e.rowType === "data") {
                // Highlight ID if it contains HTML tags
                if (e.column.dataField === "ID" && /<\/?[a-z][\s\S]*>/i.test(e.value)) {
                    e.cellElement.css({ "background-color": "red", "color": "white", "font-weight": "bold" });
                }

                // Age > 22 → Gold text
                if (e.column.dataField === "Age" && e.value > 22) {
                    e.cellElement.css({ "color": "gold", "font-weight": "bold" });
                }

                // Age < 21 → Blue background
                if (e.column.dataField === "Age" && e.value < 21) {
                    e.cellElement.css({ "background-color": "blue", "color": "white" });
                }

                // First Name contains "a" → Italic text
                if (e.column.dataField === "FirstName" && e.value.toLowerCase().includes("a")) {
                    e.cellElement.css({ "font-style": "italic" });
                }

                // Last Name starts with "S" → Green background
                if (e.column.dataField === "LastName" && e.value.startsWith("S")) {
                    e.cellElement.css({ "background-color": "green", "color": "white" });
                }

                // If ID is even → Bold text
                if (e.column.dataField === "ID" && Number(e.value) % 2 === 0) {
                    e.cellElement.css({ "font-weight": "bold" });
                }
            }
        }
    });
});

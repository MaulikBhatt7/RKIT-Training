$(function () {
    // Define the branches data
    var branches = [
        { id: 1, name: "Computer Science" },
        { id: 2, name: "Electrical Engineering" }
    ];

    // Define the sub-branches data
    var subBranches = [
        { id: 1, name: "Machine Learning", branchId: 1 },
        { id: 2, name: "Web Development", branchId: 1 },
        { id: 3, name: "Embedded Systems", branchId: 2 },
        { id: 4, name: "Power Systems", branchId: 2 }
    ];

    // Define the subjects data
    var subjects = [
        { id: 1, name: "Neural Networks", subBranchId: 1 },
        { id: 2, name: "Deep Learning", subBranchId: 1 },
        { id: 3, name: "Frontend Development", subBranchId: 2 },
        { id: 4, name: "Backend Development", subBranchId: 2 },
        { id: 5, name: "Microcontrollers", subBranchId: 3 },
        { id: 6, name: "Signal Processing", subBranchId: 3 },
        { id: 7, name: "Renewable Energy", subBranchId: 4 },
        { id: 8, name: "High Voltage", subBranchId: 4 }
    ];

    // Define the initial grid data
    var gridData = [
        { id: 1, branchId: 1, subBranchId: 1, subjectId: 1 },
        { id: 2, branchId: 2, subBranchId: 3, subjectId: 5 }
    ];

    // Initialize the DataGrid
    $("#dataGrid").dxDataGrid({
        dataSource: gridData, // Set the data source for the grid
        keyExpr: "id", // Define the key expression for the grid
        columns: [
            {
                dataField: "branchId",
                caption: "Branch",
                lookup: {
                    dataSource: branches, // Set the branches as the lookup data source
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var branch = branches.find(b => b.id === rowData.branchId);
                    return branch ? branch.name : "";
                },
                setCellValue: function (rowData, value) {
                    rowData.branchId = value; // Set the branchId value
                    rowData.subBranchId = null; // Reset Sub-Branch when Branch changes
                    rowData.subjectId = null; // Reset Subject when Branch changes
                }
            },
            {
                dataField: "subBranchId",
                caption: "Sub-Branch",
                lookup: {
                    dataSource: function (options) {
                        if (!options.data || !options.data.branchId) {
                            return []; // Return empty array if no branch is selected
                        }
                        return {
                            store: subBranches, // Filter sub-branches based on selected branch
                            filter: ["branchId", "=", options.data.branchId]
                        };
                    },
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var subBranch = subBranches.find(sb => sb.id === rowData.subBranchId);
                    return subBranch ? subBranch.name : "";
                },
                setCellValue: function (rowData, value) {
                    rowData.subBranchId = value; // Set the subBranchId value
                    rowData.subjectId = null; // Reset Subject when Sub-Branch changes
                }
            },
            {
                dataField: "subjectId",
                caption: "Subject",
                lookup: {
                    dataSource: function (options) {
                        if (!options.data || !options.data.subBranchId) {
                            return []; // Return empty array if no sub-branch is selected
                        }
                        return {
                            store: subjects, // Filter subjects based on selected sub-branch
                            filter: ["subBranchId", "=", options.data.subBranchId]
                        };
                    },
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var subject = subjects.find(s => s.id === rowData.subjectId);
                    return subject ? subject.name : "";
                }
            }
        ],
        editing: {
            mode: "row", // Set the editing mode to row
            allowAdding: true, // Allow adding new rows
            allowUpdating: true, // Allow updating existing rows
            allowDeleting: true // Allow deleting rows
        },
        onRowInserted: function (e) {
            $("#dataGrid").dxDataGrid("instance").refresh(); // Refresh the grid after a row is inserted
        },
        onRowUpdated: function (e) {
            $("#dataGrid").dxDataGrid("instance").refresh(); // Refresh the grid after a row is updated
        }
    });
});
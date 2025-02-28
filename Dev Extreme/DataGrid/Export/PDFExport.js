$(() => {
    const { jsPDF } = window.jspdf; // Ensure jsPDF is accessed correctly

    $("#dataGrid").dxDataGrid({
        dataSource: tmkocSales,
        keyExpr: "OrderID",
        columns: [
            { dataField: "OrderID", caption: "Order ID", dataType: "number" },
            { dataField: "Customer", caption: "Customer Name", dataType: "string" },
            { dataField: "OrderDate", caption: "Order Date", dataType: "date" }
        ],
        showBorders: true,
        export: {
            enabled: true,
            allowExportSelectedData: true,
        },
        onExporting(e) {
            const doc = new jsPDF(); // Now it should be defined

            DevExpress.pdfExporter.exportDataGrid({
                jsPDFDocument: doc,
                component: e.component,
                autoTableOptions: {
                    styles: { fontSize: 8 },
                    columnStyles: { 0: { cellWidth: 20 }, 1: { cellWidth: 50 }, 2: { cellWidth: 40 } },
                    margin: { top: 10 }
                }
            }).then(() => {
                doc.save("Orders.pdf");
            });
        }
    });
});

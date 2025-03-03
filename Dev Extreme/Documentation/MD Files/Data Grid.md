# DataGrid Documentation

## Table of Contents

1. [Data Binding](#data-binding)
2. [Simple Array](#simple-array)
3. [Ajax Request](#ajax-request)
4. [Paging and Scrolling](#paging-and-scrolling)
   - [Record Paging](#record-paging)
   - [Virtual Scrolling](#virtual-scrolling)
   - [Infinite Scrolling](#infinite-scrolling)
5. [Editing](#editing)
   - [Row Editing & Editing Events](#row-editing--editing-events)
   - [Batch Editing](#batch-editing)
   - [Cell Editing](#cell-editing)
   - [Form Editing](#form-editing)
   - [Popup Editing](#popup-editing)
6. [Data Validation](#data-validation)
7. [Cascading Lookups](#cascading-lookups)
8. [Grouping](#grouping)
   - [Record Grouping](#record-grouping)
9. [Filtering](#filtering)
   - [Filter Panel](#filter-panel)
10. [Sorting](#sorting)
    - [Multiple Sorting](#multiple-sorting)
11. [Selection](#selection)
    - [Row Selection](#row-selection)
    - [Multiple Record Selection Modes](#multiple-record-selection-modes)
12. [Columns](#columns)
    - [Column Customization](#column-customization)
    - [Columns based on a Data Source](#columns-based-on-a-data-source)
    - [Multi-Row Headers](#multi-row-headers)
    - [Column Resizing](#column-resizing)
    - [Command Column Customization](#command-column-customization)
    - [State Persistence](#state-persistence)
13. [Appearance](#appearance)
    - [Template](#template)
    - [Column Template](#column-template)
    - [Row Template](#row-template)
    - [Cell Customization](#cell-customization)
    - [Toolbar Customization](#toolbar-customization)
14. [Data Summaries](#data-summaries)
    - [Grid Summaries](#grid-summaries)
    - [Group Summaries](#group-summaries)
    - [Custom Summaries](#custom-summaries)
15. [Master-Detail](#master-detail)
    - [Master-Detail View](#master-detail-view)
16. [Export](#export)
17. [Adaptability](#adaptability)
    - [Grid Adaptability Overview](#grid-adaptability-overview)
    - [Grid Columns Hiding Priority](#grid-columns-hiding-priority)

## Data Binding

### Options

- `dataSource`
- `keyExpr`
- `remoteOperations`
  - `filtering`
  - `grouping`
  - `paging`
  - `sorting`

### Methods

- `refresh()`
- `reload()`

### Events

- `onDataErrorOccurred`
- `onInitNewRow`
- `onRowInserted`

## Simple Array

### Options

- `dataSource`

### Methods

- `refresh()`
- `addRow()`

### Events

- `onRowInserted`
- `onRowUpdated`

## Ajax Request

### Options

- `dataSource`
- `loadPanel`
  - `enabled`
  - `height`
  - `indicatorSrc`
  - `shading`
  - `shadingColor`
  - `showIndicator`
  - `showPane`
  - `text`
  - `width`

### Methods

- `refresh()`

### Events

- `onDataErrorOccurred`
- `onRowInserted`

## Paging and Scrolling

### Record Paging

### Options

- `paging`
  - `enabled`
  - `pageIndex`
  - `pageSize`

### Methods

- `pageIndex(value)`
- `pageSize(value)`

### Events

- `onPageChanged`
- `onPageSizeChanged`

### Virtual Scrolling

### Options

- `scrolling`
  - `mode: 'virtual'`
  - `preloadEnabled`
  - `rowRenderingMode`
  - `useNative`

### Methods

- `refresh()`

### Events

- `onScroll`

### Infinite Scrolling

### Options

- `scrolling`
  - `mode: 'infinite'`
  - `preloadEnabled`
  - `rowRenderingMode`
  - `useNative`

### Methods

- `refresh()`

### Events

- `onScroll`

## Editing

### Row Editing & Editing Events

### Options

- `editing`
  - `mode: 'row'`
  - `allowAdding`
  - `allowUpdating`
  - `allowDeleting`
  - `texts`
    - `addRow`
    - `cancelAllChanges`
    - `cancelRowChanges`
    - `confirmDeleteMessage`
    - `deleteRow`
    - `editRow`
    - `saveAllChanges`
    - `saveRowChanges`
    - `undeleteRow`

### Methods

- `editRow(rowIndex)`
- `saveEditData()`

### Events

- `onEditingStart`
- `onRowUpdating`

### Batch Editing

### Options

- `editing`
  - `mode: 'batch'`
  - `allowAdding`
  - `allowUpdating`
  - `allowDeleting`
  - `texts`
    - `addRow`
    - `cancelAllChanges`
    - `cancelRowChanges`
    - `confirmDeleteMessage`
    - `deleteRow`
    - `editRow`
    - `saveAllChanges`
    - `saveRowChanges`
    - `undeleteRow`

### Methods

- `saveEditData()`

### Events

- `onSaving`

### Cell Editing

### Options

- `editing`
  - `mode: 'cell'`
  - `allowAdding`
  - `allowUpdating`
  - `allowDeleting`
  - `texts`
    - `addRow`
    - `cancelAllChanges`
    - `cancelRowChanges`
    - `confirmDeleteMessage`
    - `deleteRow`
    - `editRow`
    - `saveAllChanges`
    - `saveRowChanges`
    - `undeleteRow`

### Methods

- `editCell(rowIndex, columnIndex)`

### Events

- `onCellClick`

### Form Editing

### Options

- `editing`
  - `mode: 'form'`
  - `allowAdding`
  - `allowUpdating`
  - `allowDeleting`
  - `form`
    - `colCount`
    - `items`
  - `popup`
    - `title`
    - `showTitle`
    - `width`
    - `height`
    - `position`
  - `texts`
    - `addRow`
    - `cancelAllChanges`
    - `cancelRowChanges`
    - `confirmDeleteMessage`
    - `deleteRow`
    - `editRow`
    - `saveAllChanges`
    - `saveRowChanges`
    - `undeleteRow`

### Methods

- `editRow(rowIndex)`

### Events

- `onEditingStart`

### Popup Editing

### Options

- `editing`
  - `mode: 'popup'`
  - `allowAdding`
  - `allowUpdating`
  - `allowDeleting`
  - `form`
    - `colCount`
    - `items`
  - `popup`
    - `title`
    - `showTitle`
    - `width`
    - `height`
    - `position`
  - `texts`
    - `addRow`
    - `cancelAllChanges`
    - `cancelRowChanges`
    - `confirmDeleteMessage`
    - `deleteRow`
    - `editRow`
    - `saveAllChanges`
    - `saveRowChanges`
    - `undeleteRow`

### Methods

- `editRow(rowIndex)`

### Events

- `onEditorPreparing`

## Data Validation

### Options

- `validationRules`
  - `type`
  - `message`
  - `trim`
  - `max`
  - `min`
  - `pattern`
  - `revalidate`
  - `reevaluate`
  - `ignoreEmptyValue`

### Methods

- `validate()`

### Events

- `onRowValidating`

## Cascading Lookups

### Options

- `lookup`
  - `dataSource`
  - `valueExpr`
  - `displayExpr`
  - `allowClearing`

### Methods

- `reload()`

### Events

- `onEditorPreparing`

## Grouping

### Record Grouping

### Options

- `grouping`
  - `autoExpandAll`
  - `allowCollapsing`
  - `contextMenuEnabled`
  - `expandMode`
- `groupPanel`
  - `visible`
  - `emptyPanelText`
  - `allowColumnDragging`

### Methods

- `expandAll()`
- `collapseAll()`

### Events

- `onGroupExpanded`
- `onGroupCollapsed`

## Filtering

### Options

- `filterRow`
  - `visible`
  - `applyFilter`
  - `applyFilterText`
  - `betweenEndText`
  - `betweenStartText`
  - `operationDescriptions`
    - `between`
    - `contains`
    - `endsWith`
    - `equal`
    - `greaterThan`
    - `greaterThanOrEqual`
    - `lessThan`
    - `lessThanOrEqual`
    - `notContains`
    - `notEqual`
    - `startsWith`
  - `resetOperationText`
  - `showAllText`
  - `showOperationChooser`
- `filterPanel`
  - `visible`
  - `filterEnabled`
  - `texts`
    - `clearFilter`
    - `createFilter`
    - `filterEnabledHint`

### Methods

- `clearFilter()`

### Events

- `onEditorPreparing`
- `onEditorPrepared`

### Filter Panel

### Options

- `filterPanel`
  - `visible`
  - `filterEnabled`
  - `texts`
    - `clearFilter`
    - `createFilter`
    - `filterEnabledHint`
- `filterBuilder`
  - `allowHierarchicalFields`
  - `customOperations`
  - `fields`
  - `groupOperationDescriptions`
  - `maxGroupLevel`
  - `valueSortOrder`

### Methods

- `clearFilter()`

### Events

- `onFilterPanelInitialized`

## Sorting

### Options

- `sorting`
  - `mode`
  - `ascendingText`
  - `clearText`
  - `descendingText`
  - `showSortIndexes`
- `sortByGroupSummaryInfo`
  - `groupColumn`
  - `sortOrder`
  - `summaryItem`

### Methods

- `sort()`

### Events

- `onSortByChanged`
- `onSorted`

### Multiple Sorting

### Options

- `sorting`
  - `mode: 'multiple'`
  - `ascendingText`
  - `clearText`
  - `descendingText`
  - `showSortIndexes`

### Methods

- `sort()`

### Events

- `onSortByChanged`

## Selection

### Row Selection

### Options

- `selection`
  - `mode: 'single'`
  - `allowSelectAll`
  - `selectAllMode`
  - `showCheckBoxesMode`

### Methods

- `selectRow(rowIndex)`
- `deselectRow(rowIndex)`

### Events

- `onSelectionChanged`

### Multiple Record Selection Modes

### Options

- `selection`
  - `mode: 'multiple'`
  - `allowSelectAll`
  - `selectAllMode`
  - `showCheckBoxesMode`

### Methods

- `selectRows(keys)`
- `deselectRows(keys)`

### Events

- `onSelectionChanged`

## Columns

### Column Customization

### Options

- `columns`
  - `dataField`
  - `caption`
  - `alignment`
  - `width`
  - `minWidth`
  - `maxWidth`
  - `visible`
  - `visibleIndex`
  - `allowSorting`
  - `allowFiltering`
  - `allowGrouping`
  - `allowHiding`

### Methods

- `addColumn(columnOptions)`
- `deleteColumn(id)`

### Events

- `onColumnHiding`
- `onColumnVisible`

### Columns based on a Data Source

### Options

- `dataSource`
- `columns`
  - `dataField`
  - `caption`
  - `dataType`
  - `format`

### Methods

- `refresh()`

### Events

- `onColumnsChanged`

### Multi-Row Headers

### Options

- `columns`
  - `columns`
    - `caption`
    - `columns`
      - `dataField`

### Methods

- `refresh()`

### Events

- `onHeaderCellPrepared`

### Column Resizing

### Options

- `allowColumnResizing`
- `columnResizingMode`
- `columnMinWidth`
- `columnMaxWidth`

### Methods

- `resizeColumn(id, width)`

### Events

- `onColumnResizing`
- `onColumnResized`

### Command Column Customization

### Options

- `commandColumn`
  - `type`
  - `text`
  - `width`
  - `visible`
  - `alignment`

### Methods

- `addCommandColumn(commandColumnOptions)`
- `deleteCommandColumn(id)`

### Events

- `onCommandColumnClick`

### State Persistence

### Options

- `stateStoring`
  - `enabled`
  - `type`
  - `storageKey`

### Methods

- `state(state)`

### Events

- `onStateStoring`

## Appearance

### Template

### Options

- `template`
  - `name`
  - `content`

### Methods

- `setTemplate(name, content)`

### Events

- `onTemplate`

### Column Template

### Options

- `columns`
  - `cellTemplate`

### Methods

- `setCellTemplate(columnIndex, template)`

### Events

- `onCellTemplatePrepared`

### Row Template

### Options

- `rowTemplate`

### Methods

- `setRowTemplate(template)`

### Events

- `onRowTemplatePrepared`

### Cell Customization

### Options

- `cellCustomization`
  - `background`
  - `border`
  - `font`
  - `alignment`

### Methods

- `customizeCell(cellIndex, customizationOptions)`

### Events

- `onCellCustomization`

### Toolbar Customization

### Options

- `toolbar`
  - `items`

### Methods

- `customizeToolbar(items)`

### Events

- `onToolbarCustomization`

## Data Summaries

### Grid Summaries

### Options

- `summary`
  - `totalItems`
    - `column`
    - `summaryType`
    - `displayFormat`

### Methods

- `refresh()`

### Events

- `onSummaryCalculated`

### Group Summaries

### Options

- `summary`
  - `groupItems`
    - `column`
    - `summaryType`
    - `displayFormat`

### Methods

- `refresh()`

### Events

- `onGroupSummaryCalculated`

### Custom Summaries

### Options

- `summary`
  - `calculateCustomSummary`

### Methods

- `refresh()`

### Events

- `onCustomSummaryCalculated`

## Master-Detail

### Master-Detail View

### Options

- `masterDetail`
  - `enabled`
  - `template`

### Methods

- `expandDetailRow(key)`
- `collapseDetailRow(key)`

### Events

- `onMasterDetailExpanded`
- `onMasterDetailCollapsed`

## Export

### Options

- `export`

### Methods

- `onExporting(e)`

## Adaptability

### Grid Adaptability Overview

### Options

- `columnHidingEnabled`

### Grid Columns Hiding Priority

### Options

- `hidingPriority`

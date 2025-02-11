# Editors Overview

This documentation provides an overview of various types of editors used in web development. It includes information about the most commonly used methods, options, and events for each editor type.

## Check Box

### Options
- `checked`: Boolean - Specifies whether the checkbox is checked.
- `disabled`: Boolean - Specifies whether the checkbox is disabled.
- `value`: Any - Specifies the value associated with the checkbox.
- `label`: String - Specifies the label text for the checkbox.
- `name`: String - Specifies the name attribute of the checkbox.

### Methods
- `check()`: Checks the checkbox.
- `uncheck()`: Unchecks the checkbox.
- `toggle()`: Toggles the checkbox state.
- `isChecked()`: Returns whether the checkbox is checked.
- `enable()`: Enables the checkbox.

### Events
- `change`: Fired when the state of the checkbox changes.
- `focus`: Fired when the checkbox gains focus.
- `blur`: Fired when the checkbox loses focus.
- `click`: Fired when the checkbox is clicked.
- `dblclick`: Fired when the checkbox is double-clicked.

## Date Box

### Options
- `value`: Date - Specifies the date value.
- `disabled`: Boolean - Specifies whether the date box is disabled.
- `min`: Date - Specifies the minimum date.
- `max`: Date - Specifies the maximum date.
- `format`: String - Specifies the date format.

### Methods
- `open()`: Opens the date picker.
- `close()`: Closes the date picker.
- `clear()`: Clears the date value.
- `getValue()`: Returns the current date value.
- `setValue(date)`: Sets the date value.

### Events
- `change`: Fired when the date value changes.
- `focus`: Fired when the date box gains focus.
- `blur`: Fired when the date box loses focus.
- `open`: Fired when the date picker is opened.
- `close`: Fired when the date picker is closed.

## Drop Down Box

### Options
- `items`: Array - Specifies the list of items in the drop-down.
- `value`: Any - Specifies the selected value.
- `disabled`: Boolean - Specifies whether the drop-down box is disabled.
- `placeholder`: String - Specifies the placeholder text.
- `multiple`: Boolean - Specifies whether multiple selections are allowed.

### Methods
- `open()`: Opens the drop-down list.
- `close()`: Closes the drop-down list.
- `select(value)`: Selects the given value.
- `clear()`: Clears the selection.
- `getSelected()`: Returns the selected value(s).

### Events
- `change`: Fired when the selected value changes.
- `focus`: Fired when the drop-down box gains focus.
- `blur`: Fired when the drop-down box loses focus.
- `open`: Fired when the drop-down list is opened.
- `close`: Fired when the drop-down list is closed.

## Number Box

### Options
- `value`: Number - Specifies the numeric value.
- `disabled`: Boolean - Specifies whether the number box is disabled.
- `min`: Number - Specifies the minimum value.
- `max`: Number - Specifies the maximum value.
- `step`: Number - Specifies the step increment.

### Methods
- `increment()`: Increases the value by the step amount.
- `decrement()`: Decreases the value by the step amount.
- `clear()`: Clears the value.
- `getValue()`: Returns the current value.
- `setValue(value)`: Sets the numeric value.

### Events
- `change`: Fired when the numeric value changes.
- `focus`: Fired when the number box gains focus.
- `blur`: Fired when the number box loses focus.
- `input`: Fired when the value is being input.
- `keydown`: Fired when a key is pressed down.

## Select Box

### Options
- `items`: Array - Specifies the list of items in the select box.
- `value`: Any - Specifies the selected value.
- `disabled`: Boolean - Specifies whether the select box is disabled.
- `placeholder`: String - Specifies the placeholder text.
- `multiple`: Boolean - Specifies whether multiple selections are allowed.

### Methods
- `open()`: Opens the select box.
- `close()`: Closes the select box.
- `select(value)`: Selects the given value.
- `clear()`: Clears the selection.
- `getSelected()`: Returns the selected value(s).

### Events
- `change`: Fired when the selected value changes.
- `focus`: Fired when the select box gains focus.
- `blur`: Fired when the select box loses focus.
- `open`: Fired when the select box is opened.
- `close`: Fired when the select box is closed.

## Text Area

### Options
- `value`: String - Specifies the text value.
- `disabled`: Boolean - Specifies whether the text area is disabled.
- `placeholder`: String - Specifies the placeholder text.
- `maxlength`: Number - Specifies the maximum number of characters.
- `rows`: Number - Specifies the number of rows.

### Methods
- `clear()`: Clears the text value.
- `focus()`: Focuses the text area.
- `blur()`: Blurs the text area.
- `getValue()`: Returns the current text value.
- `setValue(value)`: Sets the text value.

### Events
- `change`: Fired when the text value changes.
- `focus`: Fired when the text area gains focus.
- `blur`: Fired when the text area loses focus.
- `input`: Fired when the value is being input.
- `keydown`: Fired when a key is pressed down.

## Text Box

### Options
- `value`: String - Specifies the text value.
- `disabled`: Boolean - Specifies whether the text box is disabled.
- `placeholder`: String - Specifies the placeholder text.
- `maxlength`: Number - Specifies the maximum number of characters.
- `type`: String - Specifies the type of the text box (e.g., text, password, email).

### Methods
- `clear()`: Clears the text value.
- `focus()`: Focuses the text box.
- `blur()`: Blurs the text box.
- `getValue()`: Returns the current text value.
- `setValue(value)`: Sets the text value.

### Events
- `change`: Fired when the text value changes.
- `focus`: Fired when the text box gains focus.
- `blur`: Fired when the text box loses focus.
- `input`: Fired when the value is being input.
- `keydown`: Fired when a key is pressed down.

## Button

### Options
- `text`: String - Specifies the button text.
- `disabled`: Boolean - Specifies whether the button is disabled.
- `type`: String - Specifies the button type (e.g., button, submit, reset).
- `icon`: String - Specifies the icon for the button.
- `tooltip`: String - Specifies the tooltip text.

### Methods
- `click()`: Triggers a click event on the button.
- `enable()`: Enables the button.
- `disable()`: Disables the button.
- `setText(text)`: Sets the button text.
- `setIcon(icon)`: Sets the button icon.

### Events
- `click`: Fired when the button is clicked.
- `focus`: Fired when the button gains focus.
- `blur`: Fired when the button loses focus.
- `mousedown`: Fired when a mouse button is pressed on the button.
- `mouseup`: Fired when a mouse button is released on the button.

## FileUploader

### Options
- `multiple`: Boolean - Specifies whether multiple files can be uploaded.
- `accept`: String - Specifies the accepted file types.
- `maxSize`: Number - Specifies the maximum file size.
- `disabled`: Boolean - Specifies whether the file uploader is disabled.
- `uploadUrl`: String - Specifies the URL to upload files.

### Methods
- `upload()`: Uploads the selected files.
- `clear()`: Clears the selected files.
- `getFiles()`: Returns the selected files.
- `setUploadUrl(url)`: Sets the upload URL.
- `abort()`: Aborts the file upload.

### Events
- `change`: Fired when the selected files change.
- `uploadStart`: Fired when the file upload starts.
- `uploadProgress`: Fired when the file upload is in progress.
- `uploadSuccess`: Fired when the file upload is successful.
- `uploadError`: Fired when there is an error in the file upload.

## Validation

### Options
- `rules`: Object - Specifies the validation rules.
- `messages`: Object - Specifies custom validation messages.
- `disabled`: Boolean - Specifies whether validation is disabled.
- `focusInvalid`: Boolean - Specifies whether to focus the invalid field.
- `onSubmit`: Boolean - Specifies whether to validate on form submit.

### Methods
- `validate()`: Validates the form.
- `reset()`: Resets the validation state.
- `addRule(field, rule)`: Adds a validation rule.
- `removeRule(field)`: Removes a validation rule.
- `showErrors(errors)`: Shows the validation errors.

### Events
- `valid`: Fired when the form is valid.
- `invalid`: Fired when the form is invalid.
- `validate`: Fired when the form is being validated.
- `reset`: Fired when the validation state is reset.
- `error`: Fired when there is a validation error.

## Radio Group

### Options
- `items`: Array - Specifies the list of radio items.
- `value`: Any - Specifies the selected value.
- `disabled`: Boolean - Specifies whether the radio group is disabled.
- `name`: String - Specifies the name attribute of the radio group.
- `layout`: String - Specifies the layout of the radio buttons (e.g., vertical, horizontal).

### Methods
- `select(value)`: Selects the given value.
- `clear()`: Clears the selection.
- `getSelected()`: Returns the selected value.
- `enable()`: Enables the radio group.
- `disable()`: Disables the radio group.

### Events
- `change`: Fired when the selected value changes.
- `focus`: Fired when the radio group gains focus.
- `blur`: Fired when the radio group loses focus.
- `click`: Fired when a radio button is clicked.
- `dblclick`: Fired when a radio button is double-clicked.

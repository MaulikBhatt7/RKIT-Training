$(() => {
    $("#fileUploader").dxFileUploader({

        // Accepted file types
        accept: 'image/*',

        // Allows canceling uploads
        allowCanceling: true,

        // Allowed file extensions (commented out)
        allowedFileExtensions: ['.jpg'], 

        // Size of each upload chunk in bytes
        chunkSize: 10000000,

        // Element to use as drop zone
        dropZone: "#drop-box",

        // Element to trigger the file uploader dialog
        dialogTrigger: "#drop-box",

        // Allows multiple file selection
        multiple: true,

        // Message for invalid file extension
        invalidFileExtensionMessage: "[Error]: File extension is not proper",

        // Message for exceeding max file size
        invalidMaxFileSizeMessage: "[Error]: File size is too large",

        // Message for falling below min file size
        invalidMinFileSizeMessage: "[Error]: File size is too small",

        // Message for aborted upload
        uploadAbortedMessage: "[Error]: Upload stopped",

        // Message indicating readiness to upload
        readyToUploadMessage: "Now you can upload the files",

        // Label text for the uploader
        labelText: "Select Image Here",

        // Message for successful upload
        uploadedMessage: "Data reached successfully",

        // Message for failed upload
        uploadFailedMessage: "Data not reached",

        // Text displayed on the upload button
        uploadButtonText: "Send to server",

        // Text displayed on the file selection button
        selectButtonText: "Choose file",

        // Maximum file size in bytes
        maxFileSize: 50000000, // 10mb

        // Minimum file size in bytes
        minFileSize: 10000, // 10kb

        // Whether to show the list of selected files
        showFileList: true,

        // Event handler for before sending the request
        onBeforeSend: (e) => {
            console.log("Before Send");
        },

        // Event handler for when entering the drop zone
        onDropZoneEnter: () => {
            $("#drop-box").css("background", "green")
        },

        // Event handler for when leaving the drop zone
        onDropZoneLeave: () => {
            $("#drop-box").css("background", "red");
            setTimeout(() => {
                $("#drop-box").css("background", "white");
            }, 5000);
        },

        // Event handler for upload progress
        onProgress: (e) => {
            console.log("Progress Bytes: " + e.bytesLoaded);
        },

        // Event handler for when upload is completed
        onUploaded: (e) => {
            var { file } = e;
            var dropZoneText = document.getElementById('dropzone-text');
            var fileReader = new FileReader();

            fileReader.onload = function () {
                var dropZoneImage = document.getElementById('dropzone-image');
                dropZoneImage.src = fileReader.result;
                dropZoneImage.hidden = false;
                console.log(dropZoneImage)
            };
            fileReader.readAsDataURL(file);
            dropZoneText.style.display = 'none';
            console.log(`File Uploaded Successfully`);
            console.log(e);
        },

        // Event handler for when upload is aborted
        onUploadAborted: () => {
            console.log("Upload Aborted");
        },

        // Event handler for when upload encounters an error
        onUploadError: () => {
            console.log("Upload Error");
        },

        // Event handler for when upload starts
        onUploadStarted: () => {
            console.log("Upload Started");
        },

        // Initial progress value
        progress: 10,

        // Whether to show the list of selected files (duplicate property)
        showFileList: true,

        // URL to send the upload request
        uploadUrl: 'https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload',

        // Mode of the upload process
        uploadMode: 'useButtons',
    });
});
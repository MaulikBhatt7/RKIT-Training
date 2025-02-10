$(() => {
    $("#fileUploader").dxFileUploader({
        selectButtonText: 'Select video',
        accept: 'video/*',
        allowCanceling: true,
        chunkSize: 10000000,
        dropZone: "#drop-box",
        multiple: true,
        invalidFileExtensionMessage: "[Error]: File extension is not proper",
        invalidMaxFileSizeMessage: "[Error]: File size is too large",
        invalidMinFileSizeMessage: "[Error]: File size is too small",
        uploadAbortedMessage: "[Error]: Upload stopped",
        readyToUploadMessage: "Now you can upload the files",// work with button upload
        labelText: "This is label text",
        uploadedMessage: "Data reached successfully",
        uploadFailedMessage: "Data not reached",
        uploadButtonText: "Send to server",
        selectButtonText: "Choose file",
        maxFileSize: 50000000, // 10mb
        minFileSize: 10000, // 10kb
        showFileList: true,

        onDropZoneEnter: () => {
            $("#drop-box").css("background", "green")
        },
        onDropZoneLeave: () => {
            $("#drop-box").css("background", "red")
            setTimeout(() => {
                $("#drop-zone").css("background", "rgb(34, 34, 34)")
            }, 1000)
        },
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
        uploadUrl: 'https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/ChunkUpload',
        //uploadMode: 'useButtons',
    });
});
$(function () {
  var apiURL = "http://localhost:5095/api/CLBlog";

  $("#BlogTableContainer").jtable({
    title: "Blog List",
    paging: true,
    pageSize: 5,
    sorting: true,
    defaultSorting: "g01F02 DESC",
    selecting: true,
    multiselect: true,
    selectingCheckboxes: true,
    selectOnRowClick: true,
    animationsEnabled: true,
    columnResizable: true,
    columnSelectable: true,
    gotoPageArea: false,

    toolbar: {
      items: [
        {
          icon: "https://img.icons8.com/ios-glyphs/30/add--v1.png",
          text: "Add Blog",
          click: function () {
            $("#customAddForm").show();
          },
          cssClass: "jtable-toolbar-item-addRecord",
        },
      ],
    },
    actions: {
      listAction: function (postData, jtParams) {
        console.log(jtParams);
        return $.Deferred(function ($dfd) {
          $.ajax({
            url: apiURL + "/get-all-blogs",
            type: "GET",
            dataType: "json",
            data: {
              pageSize: jtParams.jtPageSize,
              pageNumber: jtParams.jtStartIndex / jtParams.jtPageSize + 1,
              sorting: jtParams.jtSorting,
            },
            success: function (data) {
              console.log(data);
              $dfd.resolve({
                Result: "OK",
                Records: data.data,
                TotalRecordCount: data.length,
              });
            },
            error: function () {
              $dfd.reject();
            },
          });
        });
      },
      createAction: function (postData) {
        const data = $.deparam(postData); // Convert form-encoded string to object
        objData = {};
        objData.g01101 = 0;
        objData.g01102 = data.g01F02;
        objData.g01103 = data.g01F03;
        var deferred = $.Deferred();

        $.ajax({
          url: apiURL + "/add-blog",
          type: "POST",
          contentType: "application/json",
          data: JSON.stringify(objData),
          dataType: "json",
          success: function (response) {
            console.log(response);
            deferred.resolve({
              Result: "OK",
              Record: objData,
            });
            console.log(jtable);
            $("#BlogTableContainer").jtable("reload");
          },
        });

        return deferred;
      },
      updateAction: function (postData) {
        var data = $.deparam(postData);
        objData = {};
        objData.g01101 = data.g01F01;
        objData.g01102 = data.g01F02;
        objData.g01103 = data.g01F03;
        console.log(data);
        var deferred = $.Deferred();
        $.ajax({
          url: `${apiURL}/update-blog`,
          type: "PUT",
          contentType: "application/json",
          data: JSON.stringify(objData),
          dataType: "json",
          success: function (response) {
            deferred.resolve({
              Result: "OK",
              Record: objData,
            });
            $("#BlogTableContainer").jtable("reload");
          },
        });
        return deferred;
      },
      deleteAction: function (data) {
        console.log(data);
        var deferred = $.Deferred();
        $.ajax({
          url: `${apiURL}/delete-blog/${data.g01F01}`,
          type: "DELETE",
          contentType: "application/json",
          dataType: "json",
          success: function (response) {
            deferred.resolve({
              Result: "OK",
              Record: data,
            });
            $("#BlogTableContainer").jtable("reload");
          },
        });
        return deferred;
      },
    },
    fields: {
      g01F01: {
        key: true,
        title: "ID",
        width: "10%",
        create: false,
        edit: false,
        list: false,
      },
      g01F02: {
        title: "Blog Title",
        type: "text",
        width: "40%",
        inputClass: "validate[required]",
      },
      g01F03: {
        title: "Blog Description",
        type: "text",
        width: "40%",
        // inputClass: "validate[required]",
        display: function (data) {
          return $('<input type="text" />')
            .addClass("validate[required]")
            .attr("name", "g01F03")
            .attr(
              "data-errormessage-value-missing",
              "Please enter a blog description"
            );
        },
      },
      Custom_Edit: {
        title: "Custom Edit",
        width: "30%",
        create: false,
        edit: false,
        sorting: false,
        display: function (data) {
          return '<div class="custom-edit"></div>';
        },
      },
    },
    recordsLoaded: function (event, data) {
      // Add custom edit button to each row
      data.records.forEach(function (record) {
        var $row = $("#BlogTableContainer").find(
          'tr[data-record-key="' + record.g01F01 + '"]'
        );
        $row
          .find(".custom-edit")
          .append(
            '<button class="custom-edit-btn" data-id="' +
              record.g01F01 +
              '">Edit</button>'
          );
      });

      // Attach click event to custom edit buttons
      $(".custom-edit-btn").on("click", function () {
        var blogId = $(this).data("id");
        // Fetch blog details by ID
        $.ajax({
          url: apiURL + "/get-blog-by-id/" + blogId,
          type: "GET",
          dataType: "json",
          success: function (data) {
            console.log(data);
            // Populate the form with blog data
            $("#customAddForm").data("editMode", true); // Set mode to edit
            $("#customAddForm").data("blogId", blogId); // Store blog ID
            $("#customAddForm").find('[name="title"]').val(data.data[0].g01F02);
            $("#customAddForm")
              .find('[name="content"]')
              .val(data.data[0].g01F03);
            $("#customAddForm").show();
            console.log($("#customAddForm").data("editMode"));
          },
          error: function () {
            alert("Failed to fetch blog details.");
          },
        });
      });
    },
    recordsLoaded: function (event, data) {
      // Add custom edit button to each row
      data.records.forEach(function (record) {
        var $row = $("#BlogTableContainer").find(
          'tr[data-record-key="' + record.g01F01 + '"]'
        );
        $row
          .find(".custom-edit")
          .append(
            '<button class="custom-edit-btn" data-id="' +
              record.g01F01 +
              '">Edit</button>'
          );
      });

      // Attach click event to custom edit buttons
      $(".custom-edit-btn").on("click", function () {
        var blogId = $(this).data("id");
        // Fetch blog details by ID
        $.ajax({
          url: apiURL + "/get-blog-by-id/" + blogId,
          type: "GET",
          dataType: "json",
          success: function (data) {
            console.log(data);
            // Populate the form with blog data
            $("#customAddForm").data("editMode", true); // Set mode to edit
            $("#customAddForm").data("blogId", blogId); // Store blog ID
            $("#customAddForm").find('[name="title"]').val(data.data[0].g01F02);
            $("#customAddForm")
              .find('[name="content"]')
              .val(data.data[0].g01F03);
            $("#customAddForm").show();
            console.log($("#customAddForm").data("editMode"));
          },
          error: function () {
            alert("Failed to fetch blog details.");
          },
        });
      });
    },
    recordAdded: function (event, data) {
      console.log(event);
    },
    formClosed: function () {
      // $(data.form).validationEngine("hide");
      // $(data.form).validationEngine("detach");
      console.log("Form closed");
    },
    formCreated: function (event, data) {
      $(data.form).validationEngine();
      $(data.form).validationEngine("attach", {
        promptPosition: "inline", // Show message under field
      });
      console.log("Form created:", data);
    },
    formSubmitting: function (event, data) {
      console.log("Form submitting:", data);
      return $(data.form).validationEngine("validate");
    },
  });

  // Load the data when ready
  $("#BlogTableContainer").jtable("load");

  $("#blogForm").on("submit", function (e) {
    e.preventDefault();
    var formData = $.deparam($(this).serialize());
    var data = {
      g01101: 0,
      g01102: formData.title,
      g01103: formData.content,
    };

    var isEditMode = $("#customAddForm").data("editMode");

    if (isEditMode) {
      // Update blog
      var blogId = $("#customAddForm").data("blogId");
      data.g01101 = blogId;
      $.ajax({
        url: apiURL + "/update-blog",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (response) {
          console.log("Updated successfully:", response);
          $("#customAddForm").hide();
          $("#BlogTableContainer").jtable("reload");
        },
        error: function (xhr, status, error) {
          console.error("Update failed:", error);
        },
      });
    } else {
      // Create blog
      data.g01101 = 0;
      $.ajax({
        url: apiURL + "/add-blog",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (response) {
          console.log("Created successfully:", response);
          $("#customAddForm").hide();
          $("#BlogTableContainer").jtable("reload");
        },
        error: function (xhr, status, error) {
          console.error("Creation failed:", error);
        },
      });
    }
  });

  var jtable = $("#BlogTableContainer").jtable("instance");
  console.log(jtable);
});

/*
    ==============================
    jQuery Validation Rules List
    ==============================

    Basic Validation
    ------------------------------
    - required               → Field must not be empty
    - optional               → Field is optional (can be used with custom rules)

    Custom Format Validation
    ------------------------------
    - custom[email]          → Validates email format
    - custom[phone]          → Validates phone number
    - custom[onlyLetter]     → Only alphabetic characters allowed
    - custom[onlyNumber]     → Only numeric digits allowed
    - custom[integer]        → Integer numbers only (no decimal)
    - custom[date]           → Valid date (e.g. mm/dd/yyyy or dd/mm/yyyy)
    - custom[ipv4]           → Valid IPv4 address
    - custom[url]            → Valid web URL
    - custom[creditCard]     → Valid credit card number

    Length & Numeric Rules
    ------------------------------
    - minSize[N]             → Minimum N characters (e.g. minSize[5])
    - maxSize[N]             → Maximum N characters (e.g. maxSize[10])
    - min[N]                 → Minimum numeric value (e.g. min[1])
    - max[N]                 → Maximum numeric value (e.g. max[100])

    Field Comparison
    ------------------------------
    - equals[fieldID]        → Must match the value of another field (e.g. confirm password)

    Checkbox/Radio Rules
    ------------------------------
    - groupRequired          → At least one option from the group must be selected

    AJAX Validation
    ------------------------------
    - ajax[ajaxName]         → AJAX-based validation (e.g. check if username already exists)
                            → Requires corresponding AJAX rule config in JS

    Notes
    ------------------------------
    - You can chain multiple rules: e.g.
    class="validate[required,custom[email],maxSize[50]]"

*/

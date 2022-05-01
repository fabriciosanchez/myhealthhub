// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(function () {

    // Global
    hideElement("fsStudies"); //hides fieldset studies by default
    hideElement("fsFormsTable"); //hides fieldset dynamic table forms
    hideElement("btnStartOver"); //hides button Start Over by default
    hideElement("slVisits"); //hides select Visits
    hideElement("slForms"); //hides select Forms
    hideElement("btnListForms"); //hides button list forms
    loadSelectStudies(); //loads studies for current user

    // User lookup fieldset behavior
    $("#btnSearchUser").click(function() {
        $("#btnSearchUser").html("Searching...");
        $.ajax({
            type: "POST",
            url: "/Patient/GetPatientByInternalId",
            data: { 
                "patientInternalId": $("#txtPatientInternalId").val()
             },
            success: function(response) {
                if(response.internalId === "undefined" || response.internalId === undefined)
                {
                    showElement("errorResponseLabel");
                    $("#errorResponseLabel").text(response.error);
                    $("#txtPatientInternalId").val('');
                    $("#btnSearchUser").html('<i class="fa-solid fa-magnifying-glass"></i> Search');
                }
                else
                {
                    hideElement("errorResponseLabel");
                    $("#txtPatientInternalId").append(response.internalId);
                    $("#txtPatientInternalId").prop("readonly", true);
                    $("#btnSearchUser").html("Found.");
                    $("#btnSearchUser").prop("disabled", true);
                    showElement("btnStartOver");
                    showElement("fsStudies"); 
                }
            },
            failure: function(response) {
                $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
            },
            error: function(response) {
                $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
            }
        });
    });

    // Behavior button start over
    $("#btnStartOver").click(function() {
        refreshPage();
    });

    // Behavior for Studies and Forms Per Physician
    $("#slStudies").on("change", function() {
        loadSelectVisits();
        showElement("slVisits");
    })

    $("#slVisits").on("change", function() {
        showElement("btnListForms");
    })

    $("#btnListForms").click(function () {
        loadFormsTable();
        showElement("fsFormsTable");
    })

    // Helper functions
    function showElement(elementId)
    {
        $(`#${elementId}`).show();
    }

    function hideElement(elementId)
    {
        $(`#${elementId}`).hide();
    }

    function refreshPage()
    {
        location.reload();
    }

    function resetSelect(elementId)
    {
        $(`#${elementId}`).prop('selectedIndex', 0);
    }

    function loadSelectStudies() {
        $.ajax({
            type: "GET",
            url: "/Study/GetStudiesForCurrentPhysician",
            data: { 
                "physicianEmail": $("#txtUserEmail").val()
             },
            success: function(response) {
                for(i = 0; i < response.length; i++) {
                    $("#slStudies").append(`<option value='${response[i].id}'>${response[i].name}</option>`)
                }
            },
            failure: function(response) {
                $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
            },
            error: function(response) {
                $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
            }
        });
    }
    
        function loadSelectVisits() {
            $.ajax({
                type: "GET",
                url: "/Visit/GetVisitsPerSelectedStudy",
                data: {
                    "studyId": $("#slStudies option:selected").val()
                },
                success: function(response) {
                    let selectOtions = '<option selected>-- VISIT TYPES --</option>';
                    for(i = 0; i < response.length; i++) {
                        selectOtions += `<option value='${response[i].id}'>${response[i].name}</option>`;
                    }
                    $("#slVisits").html(selectOtions);
                },
                failure: function(response) {
                    $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
                },
                error: function(response) {
                    $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
                }
            });
        }

        function loadFormsTable() {
            $.ajax({
                type: "GET",
                url: "/FormLabel/GetFormLabelsPerSelectedVisit",
                data: {
                    "visitId": $("#slVisits option:selected").val()
                },
                success: function(response) {
                    let studiesSelection = $("#slStudies option:selected").val();
                    let visitsSelection = $("#slVisits option:selected").val();
                    let tableDynamicContent = "";
                    let formDescription = "";
                    let status = "";
                    let urlForm = "";
                    
                    if(studiesSelection != "-- STUDIES --" && visitsSelection != "-- VISIT TYPES --")
                    {
                        for(i = 0; i < response.length; i++) {
                            if(response[i].description === "") {
                                description = "Description unavailable.";
                            }
                            else {
                                description = response[i].description;
                            }

                            if(response[i].statusFilling === false) {
                                status = `<span class="badge bg-danger">Not filled</span>`;
                            }
                            else {
                                status = `<span class="badge bg-success">Filled</span>`;
                            }

                            if(response[i].formUrlRoute === "") {
                                urlForm = "#";
                            }
                            else {
                                urlForm = `${response[i].formUrlRoute}/?pid=${$("#txtPatientInternalId").val()}&phe=${$("#txtUserEmail").val()}&vid=${$("#slVisits option:selected").val()}&flid=${response[i].id}`;
                            }

                            tableDynamicContent += "<tr>";
                            tableDynamicContent += "<td>";
                            tableDynamicContent += `${response[i].name}`;
                            tableDynamicContent += "</td>"
                            tableDynamicContent += "<td>";
                            tableDynamicContent += `${description}`;
                            tableDynamicContent += "</td>";
                            tableDynamicContent += "<td>";
                            tableDynamicContent += `${status}`;
                            tableDynamicContent += "</td>";
                            tableDynamicContent += "<td>";
                            tableDynamicContent += `<a href="${urlForm}" class="btn btn-success btn-sm"><i class="fa-solid fa-file-import"></i> Fill</a>`;
                            tableDynamicContent += "</td>";
                            tableDynamicContent += "</tr>";
                        }
                        $('#tbFormsList tbody').html(tableDynamicContent);
                    }
                },
                failure: function(response) {
                    $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
                },
                error: function(response) {
                    $("#errorResponseLabel").text("Error performing HTTP call. Try again later.");
                }
            });
        }

        ///////////////////////////
        //JQuery Validator forms //
        ///////////////////////////

        // Baseline form
        $("#frmBaseline").validate({
            errorClass: "error-response",
            rules: {
                SiteName: "required",
                DateTimeBaseline: "required",
                SiteId: "required",
                SubjectId: "required",
                Sex: "required",
                AgeConsent: {
                    required: true,
                    number: true
                },
                Ethinicity: "required",
                Weight: "required",
                Height: "required"
            },
            messages: {
                SiteName: "Please, specify the site name.",
                DateTimeBaseline: "Please, inform baseline's date",
                SiteId: "Please, specify site ID",
                SubjectId: "Please, inform the subject ID",
                Sex: "Please, inform sex at birth",
                AgeConsent: {
                    required: "You must inform the age",
                    number: "Age must be a number"
                },
                Ethinicity: "Please, inform ethinicity",
                Weight: "Weight must be informed",
                Height: "Height must be informed"
            }
        });
});

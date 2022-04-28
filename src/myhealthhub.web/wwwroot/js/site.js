// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(function () {

    // Global
    hideElement("fsStudies"); //hides fieldset studies by default
    hideElement("btnStartOver"); //hides button Start Over by default
    hideElement("slVisits"); //hides select Visits
    hideElement("slForms"); //hides select Forms
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
});

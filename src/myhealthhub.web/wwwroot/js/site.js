// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(function () {

    // Global
    hideElement("fsStudies"); //hides fieldset studies by default
    hideElement("btnStartOver"); //hides button Start Over by default
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

    // Behavior for Studies Per Physician
    

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

    function loadSelectStudies() {
        $.ajax({
            type: "GET",
            url: "/Study/GetStudiesForCurrentPhysician",
            data: { 
                "physicianEmail": $("#txtUserEmail").val()
             },
            success: function(response) {
                alert(response);
            }
        });
        
    }
});

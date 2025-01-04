

$(document).ready(function () {

    var responsiveHelper_dt_DocumentWiseAction = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };


    $("#ddlDocuments").change(function () {

        loadGrid(this.value);
    });

    $("#btnAssign").click(function () {

        var documentId = $('#ddlDocuments :selected').val();

        if (documentId == null || documentId == "") {
            toastr.warning("Please select a value from dropdown");
        }
        else {
            loadPopup(documentId);
        }
    });

});





function GetDocumentWiseActions(documentId) {
    $.ajax({
        url: WebServiceUrl + 'api/_Security/GetDocumentWiseActions?documentId=' + documentId,
        method: "GET",
        success: function (result, status, xhr) {
            result = resolveReferences(result);
            $('.js-selection').each(function (index, element) {
                var id_inGrid = $(element).attr('data-id');
                for (var i = 0; i < result.length; i++) {

                    var id_inDb = result[i].ActionId;
                    if (id_inDb == id_inGrid) {
                        $(element).prop('checked', true);
                        break;
                    }

                }
            });
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("ERROR", error);
        }
    });

}



$("#btnSave").click(function () {

    var documentId = $('#ddlDocuments :selected').val();
    var actionIds = [];
    $('.js-selection').each(function (index) {
        if ($(this).is(":checked")) {
            actionIds[index] = $(this).attr("data-id");
        }
    });

    var dataToSend = JSON.stringify({
        "DocumentId": documentId,
        "ActionIds": actionIds
    });

    $.ajax({
        type: "POST",
        url: WebServiceUrl + 'api/_Security/UpdateDocumentWiseActions', // URL
        data: dataToSend,
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {

            $('#documentWiseActionEntryPopup').modal('hide');
            var documentId = $('#ddlDocuments :selected').val();
            loadGrid(documentId);
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });
});

$('#documentWiseActionEntryPopup').on('hidden.bs.modal', function () {

    ClearGridSelection();
});

function ClearGridSelection() {
    $('.js-selection').each(function (index) {
        $(this).prop('checked', false);
    });
}





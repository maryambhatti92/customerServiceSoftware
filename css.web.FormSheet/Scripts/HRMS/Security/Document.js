
var dt_Document;

$(document).ready(function () {

    /* BASIC ;*/
    var responsiveHelper_dt_Document = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };

    $("#ddlModules").change(function () {

        loadGrid(this.value);
    });

    /* END BASIC */

});




$("#btnSave").click(function () {

    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();

    var Url = WebServiceUrl;
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        Url = Url + 'api/_Security/UpdateDocument/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        Url = Url + 'api/_Security/CreateDocument'
    }


    var Document = {
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
        "DocumentType": $("#ddlDocumentType :selected").val(),
        "IsActive": $('#chkIsActive').is(":checked"),
        "ModuleId": $('#ddlModulesPopup :selected').val(),
    };

    $.ajax({
        type: requestType,
        url: Url, // URL
        data: JSON.stringify(Document),
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {

            //var today = new Date();
            //var date = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
            //var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            //var dateTime = date + ' ' + time;

            //dt_Types.row.add([
            //                    result.TypesId,
            //                    result.Name,
            //                    result.IsActive,
            //                    dateTime
            //                    ]).draw(false);
            //dt_Types.rows().draw('page');

            $('#documentEntryPopup').modal('hide');
            toastr.success("Record saved successfully!", "Success Message");

            var moduleId = $('#ddlModules :selected').val();
            loadGrid(moduleId);
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
        }
    });
});



$('#documentEntryPopup').on('hidden.bs.modal', function () {

    ClearUI();
});

function ClearUI() {
    $('#txtName').val('');
    $('#txtDescription').val('');
    $('#ddlDocumentType').val('');
    $('#txtModule').val('');
    $('#chkIsActive').removeAttr('checked');
    $('#hdnRecordId').val('');
}



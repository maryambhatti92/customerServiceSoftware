
var dt_Role;

$(document).ready(function () {

    /* BASIC ;*/
    var responsiveHelper_dt_Role = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };


    /* END BASIC */

});




$("#btnSave").click(function () {

    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();

    var Url = WebServiceUrl;
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        Url = Url + 'api/_Security/UpdateRole/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        Url = Url + 'api/_Security/CreateRole'
    }


    var Role = {
        "Name": $("#txtRoleName").val(),
        "IsActive": $('#chkIsActive').is(":checked"),
    };

    $.ajax({
        type: requestType,
        url: Url, // URL
        data: JSON.stringify(Role),
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

            $('#roleEntryPopup').modal('hide');
            toastr.success("Record saved successfully!", "Success Message");
            loadGrid();
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
        }
    });
});

$('#dt_Role').on('click', '.js-edit', function () {

    var editButton = $(this);
    var id = editButton.attr('data-id')
    $('#hdnRecordId').val(id);

    $.ajax({
        url: WebServiceUrl + 'api/_Security/GetSingleRole/' + id,
        method: "GET",
        success: function (result, status, xhr) {

            $('#txtRoleName').val(result.Name);
            result.IsActive ? $('#chkIsActive').prop('checked', 'checked')
                : $('#chkIsActive').removeProp('checked');

        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });


});

$('#dt_Role').on('click', '.js-delete', function () {

    var deleteButton = $(this);
    bootbox.confirm('Are you sure you want to deleted this record?', function (result) {
        if (result) {
            var id = deleteButton.attr('data-id')
            $.ajax({
                url: WebServiceUrl + 'api/_Security/DeleteRole/' + id,
                method: "DELETE",
                success: function (result, status, xhr) {
                    deleteButton.parents('tr').remove();
                },
                error: function (xhr, status, error) {
                    console.error("ERROR: " + error);
                    bootbox.alert("ERROR: " + error);
                }
            });
        }
    });

});

$('#roleEntryPopup').on('hidden.bs.modal', function () {

    ClearUI();
});

function ClearUI() {
    $('#txtRoleName').val('');
    $('#chkIsActive').removeAttr('checked');
    $('#hdnRecordId').val('');
}



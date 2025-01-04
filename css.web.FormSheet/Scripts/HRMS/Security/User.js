
var dt_User;

$(document).ready(function () {

    /* BASIC ;*/
    var responsiveHelper_dt_User = undefined;
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
    debugger;
    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();

    var Url = WebServiceUrl;
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        Url = Url + 'api/_Security/UpdateUser/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        Url = Url + 'api/_Security/CreateUser'
    }
    var password, email;
    password = $("#txtPassword").val();
    email = $("#txtEmail").val();
    if ($("#txtPassword").val() == "")
    {
        email = null;
    }

    if ($("#txtEmail").val() == "") {
        password = null;
    }
    var User = {
        //"Name": $("#txtName").val(),
        "Email": email,
        "Password": password,
       // "Description": $("#txtDescription").val(),
        "EmployeeID": $("#ddlEmployeeId option:selected").val(), // $("#txtEmployeeId").val(),
        "IsHRMSUser": $('#chkIsPointOfSaleUser').is(":checked"),
        "IsActive": $('#chkIsActive').is(":checked"),
        "EPI": $('#hdnEPI').val(),
    };

    $.ajax({
        type: requestType,
        url: Url, // URL
        data: JSON.stringify(User),
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

            $('#userEntryPopup').modal('hide');
            toastr.success("Record saved successfully!", "Success Message");
            loadGrid();
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
        }
    });
});

$('#dt_User').on('click', '.js-edit', function () {

    debugger;
    var editButton = $(this);
    var id = editButton.attr('data-id')
    $('#hdnRecordId').val(id);

    $.ajax({
        url: WebServiceUrl + 'api/_Security/GetSingleUser/' + id,
        method: "GET",
        success: function (result, status, xhr) {

          //  $('#txtName').val(result.Name);
            $('#txtEmail').val(result.Email);
            $('#txtPassword').val(result.Password);
          //  $('#txtDescription').val(result.Description);
            $('#ddlEmployeeId').val(result.EmployeeID);
            $('#hdnEPI').val(result.EPI);
            result.IsHRMSUser ? $('#chkIsPointOfSaleUser').prop('checked', 'checked')
                                     : $('#chkIsPointOfSaleUser').removeProp('checked');
            result.IsActive ? $('#chkIsActive').prop('checked', 'checked')
                            : $('#chkIsActive').removeProp('checked');

        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });


});

$('#dt_User').on('click', '.js-delete', function () {

    var deleteButton = $(this);
    bootbox.confirm('Are you sure you want to deleted this record?', function (result) {
        if (result) {
            var id = deleteButton.attr('data-id')
            $.ajax({
                url: WebServiceUrl + 'api/_Security/DeleteUser/' + id,
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

$('#userEntryPopup').on('hidden.bs.modal', function () {

    ClearUI();
});

function ClearUI() {
    $('#txtName').val('');
    $('#txtEmail').val('');
    $('#txtPassword').val('');
    $('#txtDescription').val('');
    $('#ddlEmployeeId').val('');
    $('#chkIsPointOfSaleUser').removeAttr('checked');
    $('#chkIsActive').removeAttr('checked');
    $('#hdnRecordId').val('');
}



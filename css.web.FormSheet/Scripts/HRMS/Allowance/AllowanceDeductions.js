
var dt_AllowanceDeductions;

$(document).ready(function () {

    /* BASIC ;*/
    var responsiveHelper_dt_AllowanceDeductions = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };

    $("#ddlCategory").change(function () {

        if (this.value === '1') {
            $('#ddlEmployerCalculatedBy').attr('disabled', 'disabled');
            $('#txtEmployerValue').attr('disabled', 'disabled');
        }
        else
        {
            $('#ddlEmployerCalculatedBy').removeAttr('disabled');
            $('#txtEmployerValue').removeAttr('disabled');
        }
    });
    /* END BASIC */

});




$("#btnSave").click(function () {

    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();

    var Url = WebServiceUrl;
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        Url = Url + 'api/_Allowance/UpdateAllowanceDeduction/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        Url = Url + 'api/_Allowance/CreateAllowanceDeduction'
    }



    var TypeProperty = null;
    debugger;
    if ($('#ddlCategory :selected').val() === '1') {
        TypeProperty = {
            "Description": $("#txtDescription").val(),
            "Category": $('#ddlCategory :selected').val(),
            "CalculatedBy": $('#ddlCalculatedBy :selected').val(),
            "Value": $('#txtValue').val(),
            "IsActive": $('#chkIsActive').is(":checked"),
            
        };
    }
    else {
        TypeProperty = {
            "Description": $("#txtDescription").val(),
            "Category": $('#ddlCategory :selected').val(),
            "CalculatedBy": $('#ddlCalculatedBy :selected').val(),
            "Value": $('#txtValue').val(),
            "EmployerShareValue": $('#txtEmployerValue').val(),
            "EmployerShareCalculatedBy": $('#ddlEmployerCalculatedBy :selected').val(),
            "IsActive": $('#chkIsActive').is(":checked"),
            
        };
    }

    $.ajax({
        type: requestType,
        url: Url, // URL
        data: JSON.stringify(TypeProperty),
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {

            //var today = new Date();
            //var date = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
            //var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
            //var dateTime = date + ' ' + time;

            //dt_Allowance.row.add([
            //                    result.TypesId,
            //                    result.Name,
            //                    result.IsActive,
            //                    dateTime
            //                    ]).draw(false);
            //dt_Allowance.rows().draw('page');

            $('#allowanceDeductionsEntryPopup').modal('hide');
            toastr.success("Record saved successfully!", "Success Message");
            loadGrid();
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
        }
    });
});

$('#dt_AllowanceDeductions').on('click', '.js-edit', function () {

    var editButton = $(this);
    var id = editButton.attr('data-id')
    $('#hdnRecordId').val(id);

    $.ajax({
        url: WebServiceUrl + 'api/_Allowance/GetSingleAllowanceDeduction/' + id,
        method: "GET",
        success: function (result, status, xhr) {

            $('#txtDescription').val(result.Description);
            $('#ddlCategory').val(result.Category);
            $('#ddlCalculatedBy').val(result.CalculatedBy);
            $('#txtValue').val(result.Value);
            if (result.Category === '1')
            {
                $('#ddlEmployerCalculatedBy').val('');
                $('#txtEmployerValue').val('');
            }
            else
            {
                $('#ddlEmployerCalculatedBy').val(result.EmployerShareCalculatedBy);
                $('#txtEmployerValue').val(result.EmployerShareValue);
            }
            
            result.IsActive ? $('#chkIsActive').prop('checked', 'checked')
                            : $('#chkIsActive').removeProp('checked');

        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
        }
    });


});

$('#dt_AllowanceDeductions').on('click', '.js-delete', function () {

    var deleteButton = $(this);
    bootbox.confirm('Are you sure you want to deleted this record?', function (result) {
        if (result) {
            var id = deleteButton.attr('data-id')
            $.ajax({
                url: WebServiceUrl + 'api/_Allowance/DeleteAllowanceDeduction/' + id,
                method: "DELETE",
                success: function (result, status, xhr) {
                    toastr.success("Record deleted successfully!", "Success Message");
                    loadGrid();
                },
                error: function (xhr, status, error) {
                    debugger;
                    console.error("ERROR: " + error);
                    toastr.error("Oops! Something went wrong... " + "\nERROR: " + error, "Error Message");
                }
            });
        }
    });

});

$('#allowanceDeductionsEntryPopup').on('hidden.bs.modal', function () {

    ClearUI();
});

function ClearUI() {
    $('#txtDescription').val('');
    $('#ddlCategory').val('');
    $('#ddlCalculatedBy').val('');
    $('#txtValue').val('');
    $('#ddlEmployerCalculatedBy').val('');
    $('#txtEmployerValue').val('');
    $('#chkIsActive').removeProp('checked');
}



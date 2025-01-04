

$(document).ready(function () {

    var responsiveHelper_dt_PositionWiseAllowance = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };


    $("#ddlPositions").change(function () {

        loadGrid(this.value);
    });

    $("#btnAdd").click(function () {

        var positionId = $('#ddlPositions :selected').val();

        if (positionId == null || positionId == "") {
            toastr.warning("Please select a value from dropdown");
        }
        else {
            loadPopup(positionId);
        }
    });
    
});





function GetPositionWiseAllowances(positionId)
{
    $.ajax({
        url: WebServiceUrl + 'api/_Allowance/GetPositionWiseAllowances?positionId=' + positionId,
        method: "GET",
        success: function (result, status, xhr) {
            result = resolveReferences(result);
            $('.js-selection').each(function (index, element) {
                var id_inGrid = $(element).attr('data-id');
                for (var i = 0; i < result.length; i++) {

                    var id_inDb = result[i].AllowanceDeductionId;
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

    var positionId = $('#ddlPositions :selected').val();
    var allowanceDeductionIds = [];
    $('.js-selection').each(function (index) {
        if ($(this).is(":checked"))
        {
            allowanceDeductionIds[index] = $(this).attr("data-id");
        }
    });

    var dataToSend = JSON.stringify({
        "PositionId": positionId,
        "AllowanceDeductionIds": allowanceDeductionIds
    });

    $.ajax({
        type: "POST",
        url: WebServiceUrl + 'api/_Allowance/UpdatePositionWiseAllowances', // URL
        data: dataToSend,
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {

            $('#positionWiseAllowanceEntryPopup').modal('hide');
            var positionId = $('#ddlPositions :selected').val();
            loadGrid(positionId);
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });
});

$('#positionWiseAllowanceEntryPopup').on('hidden.bs.modal', function () {

    ClearGridSelection();
});

function ClearGridSelection() {
    $('.js-selection').each(function (index) {
        $(this).prop('checked', false);
    });
}





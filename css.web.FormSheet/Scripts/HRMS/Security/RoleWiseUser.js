

$(document).ready(function () {

    var responsiveHelper_dt_RoleWiseUser = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };


    $("#ddlRoles").change(function () {

        loadGrid(this.value);
    });

    $("#btnAssignRole").click(function () {

        var roleId = $('#ddlRoles :selected').val();

        if (roleId == null || roleId == "") {
            toastr.warning("Please select a value from dropdown");
        }
        else {
            loadPopup(roleId);
        }
    });

});





function GetRoleWiseUsers(roleId) {
    $.ajax({
        url: WebServiceUrl + 'api/_Security/GetRoleWiseUsers?roleId=' + roleId,
        method: "GET",
        success: function (result, status, xhr) {
            result = resolveReferences(result);
            $('.js-selection').each(function (index, element) {
                var id_inGrid = $(element).attr('data-id');
                for (var i = 0; i < result.length; i++) {

                    var id_inDb = result[i].UserId;
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

    var roleId = $('#ddlRoles :selected').val();
    var userIds = [];
    $('.js-selection').each(function (index) {
        if ($(this).is(":checked")) {
            userIds[index] = $(this).attr("data-id");
        }
    });

    var dataToSend = JSON.stringify({
        "RoleId": roleId,
        "UserIds": userIds
    });

    $.ajax({
        type: "POST",
        url: WebServiceUrl + 'api/_Security/UpdateRoleWiseUsers', // URL
        data: dataToSend,
        contentType: "application/json;charset=utf-8",
        success: function (result, status, xhr) {

            $('#roleWiseUserEntryPopup').modal('hide');
            var roleId = $('#ddlRoles :selected').val();
            loadGrid(roleId);
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });
});

$('#roleWiseUserEntryPopup').on('hidden.bs.modal', function () {
    debugger;
    ClearGridSelection();
});

function ClearGridSelection() {
    $('.js-selection').each(function (index) {
        $(this).prop('checked', false);
    });
}





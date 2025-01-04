

var popupGridHeading = "";

$(document).ready(function () {

    var responsiveHelper_dt_TypeValuesPopup = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };


    //$("#ddlPositions").change(function () {

    //    loadGrid(this.value);
    //});

    $("#ddlTypes").change(function () {

        loadGrid(this.value);
        loadAddPopupData(this.value, -1); // -1 means: when popup is opened with Add button then empty textboxes will be shown. Because no row found with id = -1;
        popupGridHeading = this.options[this.selectedIndex].innerHTML;


    });

    $("#btnAdd").click(function () {

        var typesId = $('#ddlTypes :selected').val();

        if (typesId == null || typesId == "") {
            toastr.warning("Please select a value from dropdown");
        }
        else {
            openAddPopup();
        }
    });
       
    
});


function openAddPopup() {

    $("#addPopupHeading").html(popupGridHeading);
    $("#gridHeading").html(popupGridHeading);
    $('#typeValuesAddPopup').modal('show');
}





//function GetTypeProperties(typesId) {
//    $.ajax({
//        url: WebServiceUrl + 'api/_Types/GetTypeProperties?typesId=' + typesId,
//        method: "GET",
//        success: function (result, status, xhr) {

//            result = resolveReferences(result);

//            $('.js-selection').each(function (index, element) {
//                var id_inGrid = $(element).attr('data-id');
//                for (var i = 0; i < result.length; i++) {

//                    var id_inDb = result[i].AllowanceDeductionId;
//                    if (id_inDb == id_inGrid) {
//                        $(element).prop('checked', true);
//                        break;
//                    }

//                }
//            });
//        },
//        error: function (xhr, status, error) {
//            console.error("ERROR: " + error);
//            toastr.error("ERROR", error);
//        }
//    });

//}



function Save()
{

    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();

    var Url = WebServiceUrl;
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        Url = Url + 'api/_Types/UpdateTypeProperty/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        Url = Url + 'api/_Types/CreateTypeProperty'
    }



    var typesId = $('#ddlTypes :selected').val();
    var typePropertyIds = [];
    var typeValues = [];
    var hasSomeValue = false;
    $('.js-typeValues').each(function (index) {

        // At least one text box should contain a value.
        if (!hasSomeValue)
        {
            if ($(this).val() !== null && $(this).val() !== '') {
                hasSomeValue = true; // will execute only once (thanks to outer if (!hasSomeValue))
            }
        }
        
        typePropertyIds[index] = $(this).attr("data-id");
        typeValues[index] = $(this).val(); // get textbox value
    });


    if (!hasSomeValue) {

        toastr.error("Atleast one property should contain a value.", "Error Message");
        return false;
        
    }
    else
    {
        var dataToSend = JSON.stringify({
            "TypesId": typesId,
            "TypePropertyIds": typePropertyIds,
            "TypeValues": typeValues
        });

        $.ajax({
            type: "POST",
            url: WebServiceUrl + 'api/_Types/CreateTypeValues', // URL
            data: dataToSend,
            contentType: "application/json;charset=utf-8",
            success: function (result, status, xhr) {


                $('#typeValuesAddPopup').modal('hide');
                toastr.success("Record saved successfully!", "Success Message");
                loadGrid(typesId);
            },
            error: function (xhr, status, error) {
                console.error("ERROR: " + error);
                bootbox.alert("ERROR: " + error);
            }
        });
    }
    
}




function ClearGrid() {
    $('.js-typeValues').each(function (index) {
        $(this).val('');
    });
}
function ClearEditGrid() {
    $('.js-editTypeValues').each(function (index) {
        $(this).val('');
    });
    $('#hdnRecordId').val('');
}




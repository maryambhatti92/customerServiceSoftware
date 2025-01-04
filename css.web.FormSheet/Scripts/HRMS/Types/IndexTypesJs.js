/* // DOM Position key index //

    l - Length changing (dropdown)
    f - Filtering input (search)
    t - The Table! (datatable)
    i - Information (records)
    p - Pagination (paging)
    r - pRocessing
    < and > - div elements
    <"#id" and > - div with an id
    <"class" and > - div with a class
    <"#id.class" and > - div with an id and class

    Also see: http://legacy.datatables.net/usage/features
    */



var dt_Types;

$(document).ready(function () {
    pageSetUp();


    var eval = $("#Evalreview-form").validate({

        // Rules for form validation
        rules: {
            Availability: {
                required: true
            },
            Competence: {
                required: true,
            },
            Reaction: {
                required: true,

            },
            Kindness: {
                required: true
            },
            Text: {
                required: true
            }

        },

        // Messages for form validation
        messages: {
            Availability: {
                required: 'Please rate the Avaiability'
            },
            Competence: {
                required: 'Please rate the Competence',
            },
            Reaction: {
                required: 'Please rate the Reaction'
            },
            Kindness: {
                required: 'Please rate the Kindness'
            },
            Text: {
                required: 'Please enter the Text'
            }

        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        }
    })




    //Bootstrap Wizard Validations

    var $validator = $("#wizard-1").validate({

        rules: {
            companyname: {
                required: true,               
            },
            Street: {
                required: true
            },
            Zipcode: {
                required: true
            },
            Country: {
                required: true
            },
            cp1name: {
                required: true
            },
            cp1email: {
                required: true,
                email: "Your email address must be in the format of name@domain.com"
            },
            cp1phone: {
                required: true,
                minlength: 4
            },
            cp2name: {
                required: true
            },
            cp2email: {
                required: true,
                email: "Your email address must be in the format of name@domain.com"
            },
            cp2phone: {
                required: true,
                minlength: 4
            },

            wphone: {
                required: true,
                minlength: 4
            },
            wphone: {
                required: true,
                minlength: 10
            },
            hphone: {
                required: true,
                minlength: 10
            }
        },

        messages: {
            companyname: "Please specify Company Name",
            Street: "Please specify your street",
            Zipcode: "Please specify your Zipcode",
            Country: "Please specify your Country",
            cp1name: "Please specify Person 1 name",
            cp1email: {
                        required: "Please specify Person 1 email",
                        email: "Your email address must be in the format of name@domain.com"
                        },
            cp1phone: "Please specify Person 1 Phone",
            cp2name: "Please specify Person 2 name",
            cp2email: {
                required: "Please specify Person 2 email",
                email: "Your email address must be in the format of name@domain.com"
            },
            cp2phone: "Please specify Person 2 Phone",
            email: {
                required: "We need your email address to contact you",
                email: "Your email address must be in the format of name@domain.com"
            }
        },

        highlight: function (element) {
            $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });

    $('#bootstrap-wizard-1').bootstrapWizard({
        'tabClass': 'form-wizard',
        'onNext': function (tab, navigation, index) {
            var $valid = $("#wizard-1").valid();
            if (!$valid) {
                $validator.focusInvalid();
                return false;
            } else {
                $('#bootstrap-wizard-1').find('.form-wizard').children('li').eq(index - 1).addClass(
                  'complete');
                $('#bootstrap-wizard-1').find('.form-wizard').children('li').eq(index - 1).find('.step')
                .html('<i class="fa fa-check"></i>');
            }
        }
    });



});



$('#Evalreview-form').bind('submit', function () {
    
    var url = window.location.href;
    var Evaluation = {
        "Completion_id": url.substring(url.lastIndexOf('=') + 1),
        "request_id": '',
        "order_number": '',
        "credite_note_number": '',
        "Disposal": '',
        "Evaluation_Request": true,
        "Availability":  $("input[name='Availability']:checked").data('id'),
        "Professional_Competence":  $("input[name='Competence']:checked").data('id'),
        "Reaction_Time":  $("input[name='Reaction']:checked").data('id'),
        "Kindness":  $("input[name='Kindness']:checked").data('id'),
        "Text":  $("#Text").val(),
        "Email_Sent": null,
        "Email_date": null
    };

    $.ajax({
        type: 'Put',
        dataType: "json",
        data: JSON.stringify(Evaluation),
        contentType: "application/json;charset=utf-8",        
        url: WebServiceUrl + "api/_Completion/UpdateCompletionEvaluation/"  ,       
        success: function (result, status, xhr) {

            //$('#txtTypeName').val(result.Name);
            //result.IsActive ? $('#chkIsActive').prop('checked', 'checked')
            //    : $('#chkIsActive').removeProp('checked');
           
            if (result == "Successful") {
                alert(result);
            }
            return false;
          //  $('form').unbind('submit').submit();
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
         //   bootbox.alert("ERROR: " + error);
        } 
    });

    //Prevent default form submit
    return false;

});



$('#dt_Types').on('click', '.js-delete', function () {

    var deleteButton = $(this);

    bootbox.confirm('Are you sure you want to deleted this record?', function (result) {

        if (result) {
            var id = deleteButton.attr('data-types-id')
            $.ajax({
                url: WebServiceUrl + 'api/_Types/DeleteType/' + id,
                method: "DELETE",
                success: function (result, status, xhr) {
                    debugger;
                    dt_Types.row(deleteButton.parents('tr')).remove().draw('page');
                },
                error: function (xhr, status, error) {
                    debugger;
                    console.error("ERROR: " + error);
                    bootbox.alert("ERROR: " + error);
                }
            });
        }
    });

});

$('#dt_Types').on('click', '.js-edit', function () {

    var editButton = $(this);
    var id = editButton.attr('data-types-id')
    $('#hdnRecordId').val(id);

    $.ajax({
        url: WebServiceUrl + 'api/_Types/GetSingleType/' + id,
        method: "GET",
        success: function (result, status, xhr) {

            $('#txtTypeName').val(result.Name);
            result.IsActive ? $('#chkIsActive').prop('checked', 'checked')
                : $('#chkIsActive').removeProp('checked');

        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });


});

$("#btnSave").click(function () {

    var recordId = $('#hdnRecordId').val() === '' ? '0' : $('#hdnRecordId').val();
    debugger;

    var requestUrl = '';
    var requestType = '';

    if (recordId !== '0') {
        requestType = 'PUT';
        requestUrl = WebServiceUrl + 'api/_Types/UpdateType/' + $('#hdnRecordId').val()
    }
    else {
        requestType = 'POST'
        requestUrl = WebServiceUrl + 'api/_Types/CreateType'
    }


    var Types = {
        "Name": $("#txtTypeName").val(),
        "IsActive": $('#chkIsActive').is(":checked")
    };

    $.ajax({
        type: requestType,
        url: requestUrl, // URL
        data: JSON.stringify(Types),
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

            $('#AddEditPopup').modal('hide');
        },
        error: function (xhr, status, error) {
            console.error("ERROR: " + error);
            bootbox.alert("ERROR: " + error);
        }
    });


    

});

$('#AddEditPopup').on('hidden.bs.modal', function () {

    ClearUI();
});

function ClearUI() {
    $('#txtTypeName').val('');
    $('#chkIsActive').removeProp('checked');
    $('#hdnIsEdit').val('');
}


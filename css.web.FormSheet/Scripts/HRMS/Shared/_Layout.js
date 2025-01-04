
//var WebServiceUrl = "http://localhost:58989/";
var WebServiceUrl = "https://sequware.site/";


$(document).ready(function () {
    // Toastr
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        //"positionClass": "toast-top-full-width",
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }

});

//days in months
function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}


function HidePath() {
    var filename = document.getElementById('file-id').value;
    document.getElementById('file-path').value = filename;
    return filename;
}

// Format AM PM
function formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var seconds = date.getSeconds();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ':' + seconds + ' ' + ampm;
    return strTime;
}


// Get Query String Parameter
function getQueryStringParam(name, url) {
    if (!url) url = window.location.href;
    if (name == null) return null;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

//last param
function getQueryStringLastParam(url)
{   
    var url_array = url.split('/') // Split the string into an array with / as separator
    var last_segment = url_array[url_array.length - 1];  // Get the last part of the array (-1)
    return last_segment;
}

// dd-mm-yy to mm/dd/yyyy
function toMmDdYy(input) {
    var ptrn = /(\d{4})\-(\d{2})\-(\d{2})/;
    if (!input || !input.match(ptrn)) {
        return null;
    }
    return input.replace(ptrn, '$2/$3/$1');
};

function dateDiffernce(from, to) {
    debugger;
    var date1 = new Date(from);
    var date2 = new Date(to);
    var timeDiff = Math.abs(date2.getTime() - date1.getTime());
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    var years = Math.floor(diffDays / 365);
    var monthCalc =(diffDays - (years * 365)) ;
    var months = monthCalc / 30;
    var days = 0;
    if (months > 1)
    {
        months = Math.floor(months);
        days = monthCalc - (months * 30);
    }
    else {
        months = 0;
        days = monthCalc;
    }
     

    return years +"  Years "+ months + " Months " + days+ " Days" ; //.toFixed(1);
}

function dateDifinDays(start,end)
{
    debugger;
    var day_start = new Date(start);
    var day_end = new Date(end);
    var total_days = (day_end - day_start) / (1000 * 60 * 60 * 24);
    Math.round(total_days);
    return total_days + 1;
}

// Circular Reference
function resolveReferences(json) {
    if (typeof json === 'string')
        json = JSON.parse(json);

    var byid = {}, // all objects by id
        refs = []; // references to objects that could not be resolved
    json = (function recurse(obj, prop, parent) {
        if (typeof obj !== 'object' || !obj) // a primitive value
            return obj;
        if (Object.prototype.toString.call(obj) === '[object Array]') {
            for (var i = 0; i < obj.length; i++)
                // check also if the array element is not a primitive value
                if (typeof obj[i] !== 'object' || !obj[i]) // a primitive value
                    continue;
                else if ("$ref" in obj[i])
                    obj[i] = recurse(obj[i], i, obj);
                else
                    obj[i] = recurse(obj[i], prop, obj);
            return obj;
        }
        if ("$ref" in obj) { // a reference
            var ref = obj.$ref;
            if (ref in byid)
                return byid[ref];
            // else we have to make it lazy:
            refs.push([parent, prop, ref]);
            return;
        } else if ("$id" in obj) {
            var id = obj.$id;
            delete obj.$id;
            if ("$values" in obj) // an array
                obj = obj.$values.map(recurse);
            else // a plain object
                for (var prop in obj)
                    obj[prop] = recurse(obj[prop], prop, obj);
            byid[id] = obj;
        }
        return obj;
    })(json); // run it!

    for (var i = 0; i < refs.length; i++) { // resolve previously unknown references
        var ref = refs[i];
        ref[0][ref[1]] = byid[ref[2]];
        // Notice that this throws if you put in a reference at top-level
    }
    return json;
}




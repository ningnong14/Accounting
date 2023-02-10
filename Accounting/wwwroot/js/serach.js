var resultDataSearch = [];
$(document).ready(() => {

    //ยิง service เพื่อเอาค่า MainAccount มาใส่ dropdown
    GetMainAccount();

    $('.content_table').hide();
    $('.cal').hide();
    $('#button_search').click(function () {
        var serachResult = {
            NameCompany: $('#input_type').val(),
            TagId: $('#code').val(),
            DateTo: $('#input_dateTo').val(),
            DateFrom: $('#input_dateFrom').val()
        };
        if (serachResult.DateTo == "") {
            Swal.fire({
                icon: 'error',
                title: 'Search Fail',
                text: 'Wrong Format Date',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'ตกลง'
            })
            $('#input_dateTo').addClass("focusErrorBox");
            $('#input_dateFrom').addClass("focusErrorBox");
            $('#date_to').addClass("focusErrorMsg");
            $('#date_from').addClass("focusErrorMsg");
        } else {
            SearachData(serachResult);
        }
        console.log("search result", serachResult);
    })
    $('#button_clear').click(function () {
        $('#code').val("");
        $('#input_type').val("");
        $('#input_dateFrom').val("");
        $('#input_dateTo').val("");
        $('#input_dateTo').removeClass("focusErrorBox");
        $('#input_dateFrom').removeClass("focusErrorBox");
        $('#date_to').removeClass("focusErrorMsg");
        $('#date_from').removeClass("focusErrorMsg");
        $('.content_table').hide();
        $('.cal').hide();
    })
    //TODO เหลือยิงเส้น Excel ยังไม่เสร็จ
    $('#button_export').click(function () {
        console.log("Reqdata", resultDataSearch);
        url = baseURL() + `api/Serach/ExportExcel`;
        fetch(url, {
            method: "POST",
            headers: [
                ["Content-Type", "application/json"],
                ["Content-Type", "text/plain"],
                ["Content-Type", "application/json; charset=utf-8"],
                ["Content-Disposition": "attachment; filename=accounting.xlsx;"]
            ],
            xhrFields: {
                responseType: 'blob' // to avoid binary data being mangled on charset conversion
            },
            body: JSON.stringify(resultDataSearch),
            credentials: "include",
        })
            .then(function (response) {
                return response.json() // แปลงข้อมูลที่ได้เป็น json
            })
            .then(function (data) {
                console.log("ResData", data);
                console.log("ResData.data", data.data);
                GenTableResult(data.data);
                CalcreditDebit(data.data);
            })
    })
    //$.ajax({
    //    type: 'POST',
    //    url: baseURL() + `/api/managedatabase/export`,
    //    data: JSON.stringify(objectExport),
    //    contentType: 'application/json; charset=utf-8',
    //    xhrFields: {
    //        responseType: 'blob' // to avoid binary data being mangled on charset conversion
    //    },
    //    success: function (blob, status, xhr) {
    //        // check for a filename
    //        var filename = "";
    //        var disposition = xhr.getResponseHeader('Content-Disposition');
    //        if (disposition && disposition.indexOf('attachment') !== -1) {
    //            var filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
    //            var matches = filenameRegex.exec(disposition);
    //            if (matches != null && matches[1]) filename = matches[1].replace(/['"]/g, '');
    //        }

    //        if (typeof window.navigator.msSaveBlob !== 'undefined') {
    //            // IE workaround for "HTML7007: One or more blob URLs were revoked by closing the blob for which they were created. These URLs will no longer resolve as the data backing the URL has been freed."
    //            window.navigator.msSaveBlob(blob, filename);
    //        } else {
    //            var URL = window.URL || window.webkitURL;
    //            var downloadUrl = URL.createObjectURL(blob);

    //            if (filename) {
    //                // use HTML5 a[download] attribute to specify filename
    //                var a = document.createElement("a");
    //                // safari doesn't support this yet
    //                if (typeof a.download === 'undefined') {
    //                    window.location.href = downloadUrl;
    //                } else {
    //                    a.href = downloadUrl;
    //                    a.download = filename;
    //                    document.body.appendChild(a);
    //                    a.click();
    //                }
    //            } else {
    //                window.location.href = downloadUrl;
    //            }

    //            setTimeout(function () { URL.revokeObjectURL(downloadUrl); }, 100); // cleanup
    //        }
});

function GetMainAccount() {
    url = baseURL() + `api/AddMainAccount/GetAllData`;
    fetch(url, {
        method: "GET",
        headers: [
            ["Content-Type", "application/json"],
            ["Content-Type", "text/plain"]
        ],
        credentials: "include",
    })
        .then(function (response) {
            return response.json() // แปลงข้อมูลที่ได้เป็น json
        })
        .then(function (data) {
            console.log("ResData", data);
            SetValueDropdown(data);
        })
}
function SetValueDropdown(data) {
    for (let i = 0; i < data.length; i++) {
        $('#code').append(`<option value="${data[i].code}">
                                       ${data[i].code + " " + data[i].description}
                                  </option>`);
    }
}

function SearachData(data) {
    reqdata = {
        name: data.NameCompany,
        id: data.TagId,
        dateTimeTo: data.DateTo,
        dateTimeFrom: data.DateFrom
    };
    console.log("Reqdata", reqdata);
    url = baseURL() + `api/Serach/SearchData`;
    fetch(url, {
        method: "POST",
        headers: [
            ["Content-Type", "application/json"],
            ["Content-Type", "text/plain"]
        ],
        body: JSON.stringify(reqdata),
        credentials: "include",
    })
        .then(function (response) {
            return response.json() // แปลงข้อมูลที่ได้เป็น json
        })
        .then(function (data) {
            console.log("ResData", data);
            console.log("ResData.data", data.data);
            GenTableResult(data.data);
            CalcreditDebit(data.data);
        })
}
function GenTableResult(searchData) {
    //TODO แก้ไขข้อมูล Gentable
    var i = 1
        for (var serach of searchData) {
            var html = '<tr>\
                            <td>' + i++ + '</td>\
                            <td>' + serach.tagVoucher + '</td>\
                            <td>' + serach.codeVoucher + '</td>\
                            <td>' + serach.dateTimeTo + '</td>\
                            <td>' + serach.mainAccount + '</td>\
                            <td>' + serach.description + '</td>\
                            <td>' + serach.credit + '</td>\
                            <td>' + serach.debit + '</td>\
                        </tr>';
            $('#table_searchResult').append(html);
        }
    resultDataSearch.push(searchData);
    console.log("resultDataSearch", resultDataSearch);
    $('.content_table').show();
    $('.cal').show();
}
function CalcreditDebit(searchData) {
    var credit = 0;
    var debit = 0;
    var total = 0;

    for (var cal of searchData) {
        credit += cal.credit;
        debit += cal.debit;
    }
    total = credit - debit;
    $('#credit').val(credit);
    $('#debit').val(debit);
    $('#total').val(total);
}
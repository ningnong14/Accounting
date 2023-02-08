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
    })
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
        })
}
function GenTableResult(data) {
    ////table_searchResult

    //var table = document.getElementById("table_MainAccount");
    //var row = table.insertRow();
    //var cell = row.insertCell();
    //cell.innerHTML = mainCount;
    //cell = row.insertCell();
    //cell.innerHTML = data.code;
    //cell = row.insertCell();
    //cell.innerHTML = data.discription;
    ////button input 
    //var btn = document.createElement('input');
    //btn.type = "button";
    //btn.className = "btn edit" + mainCount;
    //btn.value = "edit";
    //btn.id = "edit";
    //cell_button_input = row.insertCell();
    //cell_button_input.appendChild(btn);
    ////button del
    //var btn = document.createElement('input');
    //btn.type = "button";
    //btn.className = "btn del" + mainCount;
    //btn.value = "del";
    //btn.id = "del";
    //cell_button_del = row.insertCell();
    //cell_button_del.appendChild(btn);

    var resultTable = $('#table_MainAccount');
    //SetBody
    var tbody = $('<tbody />');
    resultTable.append(tbody);
    for (var i = 0; i < data.length; i++) {

        var rowData = Object.values(data[i]);
        var tr = $('<tr />');
        tbody.append(tr);
        for (var j = 0; j < headerData.length; j++) {
            var td = $('<td />');
            var div = $('<div>' + rowData[j] + '</div>');
            td.append(div);
            tr.append(td);
        }
    }

}
﻿var count = 1;
let data = [];
let dataDropDown = [];
$(document).ready(() => {
    console.log("Already Create Record");
    $('#addRecord').on("click", function (event) {
        dataMainAccount();
    })

    $('#confirmRecord').on("click", function () {
        console.log("loop", count)
        let Caldebit = 0;
        let Calcredit = 0;
        for (var i = 1; i <= count-1; i++)
        {
            let dataRecord = {
                dateTime: $('#dateTime' + i).val(),
                voucher: $('#voucher' + i).val(),
                mainAccount: $('#mainAccount' + i).val(),
                description: $('#descript' + i).val(),
                debit: $('#debit' + i).val(),
                credit: $('#credit' + i).val(),
            };
            Calcredit += parseInt(dataRecord.credit);
            Caldebit += parseInt(dataRecord.debit);
            data.push(dataRecord);
        }
        console.log("dataRecord", data);
        console.log(Calcredit);
        console.log(Caldebit);
        //เช็ค Debit Credit ต้องเท่ากัน ถึงจะบันทึกบัญชีได้
        checkDebitCredit(Calcredit, Caldebit);
        console.log(checkDebitCredit(Calcredit, Caldebit));
        if (checkDebitCredit(Calcredit, Caldebit)) {
            // บันทึกบัญชี
            saveRecordData(data);
            data = [];
        }
    })

});
//TODO ตกแต่ง input box 
function addRecord(data) {

    //STEP 1.เข้าถึง id ของ table  2.สร้าง row จาก id table  3.สร้าง cell 4.append แทรกเข้าไปในตาราง 
    var table = document.getElementById("recordAccount");
    var row = table.insertRow();

    var dateTime = document.createElement('input');
    dateTime.type = "text";
    dateTime.id = "dateTime" + count;
    dateTime.className = "dateTime";
    var inputDateTime = row.insertCell();
    inputDateTime.appendChild(dateTime);

    var vocher = document.createElement('input');
    vocher.type = "text";
    vocher.id = "voucher" + count;
    vocher.className = "voucher";
    var inputVocher = row.insertCell();
    inputVocher.appendChild(vocher);

    // Ex 5001 ค่าน้ำมัน
    var mainAccount = document.createElement('select')
    mainAccount.name = "codeAcc";
    mainAccount.id = "mainAccount" + count;
    var dropdownMainAcc = row.insertCell();
    dropdownMainAcc.appendChild(mainAccount);

    // Jquery ในการ เพิ่ม option
    for (let i = 0; i < data.length; i++) {
        $('#mainAccount' + count).append(`<option value="${data[i].code}">
                                       ${data[i].code + " " + data[i].description}
                                  </option>`);
    }

    //Ex กรอกข้อความเสริมจะมีหรือไม่มีก็ได้ เช่น ค่าน้ำมันรถของเจ้านาย 8321กข 
    var description = document.createElement('input');
    description.type = "text"
    description.className = "descript";
    description.id = "descript" + count;
    var inputDecription = row.insertCell();
    inputDecription.appendChild(description);

    var debit = document.createElement('input');
    debit.type = "text";
    debit.className = "debit";
    debit.id = "debit" + count;
    var inputdebit = row.insertCell();
    inputdebit.appendChild(debit);

    var credit = document.createElement('input');
    credit.type = "text";
    credit.className = "credit";
    credit.id = "credit" + count++;
    var inputcredit = row.insertCell();
    inputcredit.appendChild(credit);
}

function dataMainAccount() {
    console.log("call dataMainAccount");
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
            console.log(response);
            status = response.status;
            return response.json() // แปลงข้อมูลที่ได้เป็น json
        })
        .then(function (data) {
            console.log("ResData", data);
            localStorage.setItem("Username", data.username);
            dataDropDown.push(data); //saveList data
            addRecord(data);
        })
}
//TODO: เขียนเส้น API insertData 
function saveRecordData(dataRecord) {
    console.log("callSaveData");
    url = baseURL() + `api/RecordAccounting/InsertRecordAccount`;
    fetch(url, {
        method: "POST",
        headers: [
            ["Content-Type", "application/json"],
            ["Content-Type", "text/plain"]
        ],
        credentials: "include",
        body: JSON.stringify(dataRecord),
        })
        .then(function (response) {
            console.log(response);
            return response.json() // แปลงข้อมูลที่ได้เป็น json
        })
        .then(function (data) {
            console.log("ResData", data);
        })
}
function checkDebitCredit(Calcredit, Caldebit) {
    console.log("CheckCreditDebit")
    console.log(Calcredit);
    console.log(Caldebit);
    if (Calcredit != Caldebit) {
        return false;
    }
    return true;
}
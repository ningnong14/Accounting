var count = 1;
let data = [];
let dataDropDown = [];
$(document).ready(() => {
    console.log("Already Create Record");
    $('#addRecord').on("click", function (event) {
        dataMainAccount();
        $('.descript').attr('disabled', true);
        console.log("OK");
    })

    $('#confirmRecord').on("click", function () {
        console.log("loop", count)
        for (var i = 1; i <= count-1; i++)
        {
            let dataRecord = {
                dateTime: $('#dateTime' + i).val(),
                vocher: $('#voucher' + i).val(),
                mainAccount: $('#mainAccount' + i).val(),
                description: $('#descript' + i).val(),
                debit: $('#debit' + i).val(),
                credit: $('#credit' + i).val(),
            };
            data.push(dataRecord);
        }
        console.log("dataRecord",data);
    })

});
//TODO ตกแต่ง input box และเพิ่มข้อมูลเข้า dropdown อาจจะมีปรับMainAccount ให้รวมช่องกับ discription
function addRecord(data) {
    for (let i = 0; i < data.length; i++) {
        console.log("dataLoop",data[i]);
    }

    //1.เข้าถึง id ของ table  2.สร้าง row จาก id table  3.สร้าง cell 4.append แทรกเข้าไปในตาราง 
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

    var mainAccount = document.createElement('select')
    mainAccount.name = "codeAcc";
    mainAccount.id = "mainAccount" + count;
    mainAccount.options = "55555";
    var dropdownMainAcc = row.insertCell();
    dropdownMainAcc.appendChild(mainAccount);

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
function saveRecordData() {
    console.log("callSaveData");
    url = baseURL() + `api/RecordAccounting/insertData`;
    data = {
        code: codeAccount,
        discription: nameAccount
    };
    console.log("code", codeAccount);
    console.log("name", nameAccount);
    fetch(url, {
        method: "POST",
        headers: [
            ["Content-Type", "application/json"],
            ["Content-Type", "text/plain"]
        ],
        credentials: "include",
        body: JSON.stringify({
            code: codeAccount,
            discription: nameAccount
        }),
    })
        .then(function (response) {
            console.log(response);
            status = response.status;
            if (response.ok == false) {
                Swal.fire({
                    icon: 'error',
                    title: 'Add Fail',
                    text: 'Code Duplicate',
                    confirmButtonColor: '#3085d6',
                    confirmButtonText: 'ตกลง'
                }).then((result) => {
                    if (result.isConfirmed) {
                    }
                })
            }
            return response.json() // แปลงข้อมูลที่ได้เป็น json
        })
        .then(function (data) {
            console.log("ResData", data);
            localStorage.setItem("Username", data.username);
            if (status == 200) {
                loadDataTable(data);
                console.log("Success");
            }
        })
}
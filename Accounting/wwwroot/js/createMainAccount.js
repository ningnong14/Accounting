var list = [];
var mainCount = 1;
var status = "";

$(document).ready(() => {
    console.log("already function");
    $('#addMainAccount').on("click", function (event) {
        let codeAccount = "";
        let nameAccount = "";

        Swal.fire({
            title: 'Add Your MainAccount',
            html: `<input type="text" id="code" class="swal2-input" placeholder="Code">
                   <input type="text" id="name" class="swal2-input" placeholder="Name">`,
            confirmButtonText: 'confrim',
            preConfirm: () => {
                codeAccount = Swal.getPopup().querySelector('#code').value
                nameAccount = Swal.getPopup().querySelector('#name').value
            }
        }).then((result) => {
            url = baseURL() + `api/AddMainAccount/GetDataByCode`;
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
                                window.location.href = baseURL() + "/AddMainAccount";
                            }
                        })
                    }
                    return response.json() // แปลงข้อมูลที่ได้เป็น json
                })
                .then(function (data) {
                    console.log("ResData",data);
                    localStorage.setItem("Username", data.username);
                    if (status == 200)
                    {
                        loadDataTable(data);
                        console.log("Success");
                    }
                })
        })
    })

    $('#confirm').on("click", function (event) {
        console.log("confirm------------------------------------------------------");
        console.log("confirm", list);
        console.log("list", list[0].code);
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Your work has been saved',
            showConfirmButton: false,
            timer: 1000
        }).then((result) => {
            var tblength = document.getElementById('table_MainAccount').rows.length;
            console.log("length", tblength);
            for (let i = 0; i < tblength - 1; i++)
            {
                url = baseURL() + `api/AddMainAccount/AddDebitCode`;
                code = list[i].code;
                name = list[i].discription;
                console.log("code", code);
                console.log("name", name);
                fetch(url, {
                    method: "POST",
                    headers: [
                        ["Content-Type", "application/json"],
                        ["Content-Type", "text/plain"]
                    ],
                    credentials: "include",
                    body: JSON.stringify({
                        code: code,
                        discription: name
                    }),
                })
                    .then(function (response) {
                        console.log(response);
                        if (response.ok == false) {
                            loading('show');
                            Swal.fire({
                                icon: 'error',
                                title: 'Add Fail',
                                text: 'Code Duplicate',
                                confirmButtonColor: '#3085d6',
                                confirmButtonText: 'ตกลง'
                            }).then((result) => {
                                if (result.isConfirmed) {
                                    window.location.href = baseURL() + "/AddMainAccount";
                                }
                            })
                        }
                        return response.json() // แปลงข้อมูลที่ได้เป็น json
                    })
                    .then(function (data) {
                        console.log("dataOk", data);
                        localStorage.setItem("Username", data.username);
                        console.log("Success");
                        window.location.href = baseURL() + "/Home";
                    })
            }
        })
    })
});

function loadDataTable(data) {
    list.push(data);
    console.log("ListData", list);

    var table = document.getElementById("table_MainAccount");
    var row = table.insertRow();
    var cell = row.insertCell();
    cell.innerHTML = mainCount;
    cell = row.insertCell();
    cell.innerHTML = data.code;
    cell = row.insertCell();
    cell.innerHTML = data.discription;
    //button input 
    var btn = document.createElement('input');
    btn.type = "button";
    btn.className = "btn edit" + mainCount;
    btn.value = "edit";
    btn.id = "edit";
    cell_button_input = row.insertCell();
    cell_button_input.appendChild(btn);
    //button del
    var btn = document.createElement('input');
    btn.type = "button";
    btn.className = "btn del" + mainCount;
    btn.value = "del";
    btn.id = "del";
    cell_button_del = row.insertCell();
    cell_button_del.appendChild(btn);
}

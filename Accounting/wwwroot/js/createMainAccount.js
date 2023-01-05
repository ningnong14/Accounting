const dataMainAccount = {code:"",name:""};

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
            url = baseURL() + `api/AddMainAccount/AddDebitCode`;
            code = codeAccount;
            name = nameAccount;
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
                    code: code,
                    discription: name
                }),
            })
                .then(function (response) {
                    console.log(response);
                    if (response.ok == false) {
                        /*loading('show');*/
                        Swal.fire({
                            icon: 'error',
                            title: 'Add Fail',
                            text: 'Code Duplicate',
                            confirmButtonColor: '#3085d6',
                            confirmButtonText: 'ตกลง'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                window.location.href = baseURL() + "/AdddebitCode";
                            }
                        })
                    }
                    return response.json() // แปลงข้อมูลที่ได้เป็น json
                })
                .then(function (data) {
                    if (data.code == "200") {
                        dataMainAccount = { code: data.code, name: data.discription };
                        localStorage.setItem("Username", data.username);
                        console.log(baseURL());
                        window.location.href = baseURL() + "/AdddebitCode";
                        //Table 
                        var table = document.getElementById(table_MainAccount);
                        for(var data in dataMainAccount)
                        {
                            var row = table.insertRow();
                            var cell = row.insertCell();
                            cell.innerHTML = data.count();
                            cell = row.insertCell();
                            cell.innerHTML = data.code;
                            cell = row.insertCell();
                            cell.innerHTML = data.discription;
                            cell = row.insertCell();
                            cell.insertHTML = '<td><button type="button">Edit</button></td>';
                            cell = row.insertCell();
                            cell.insertHTML = '<td><button type="button">Del</button></td>';
                        }
                    }
                    console.log("LoginData", data); // แสดงข้อมูล JSON จาก then ข้างบน
                })
        })
    })
});
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
                        localStorage.setItem("Username", data.username);
                        console.log(baseURL());
                        window.location.href = baseURL() + "/AdddebitCode";
                    }
                    console.log("LoginData", data); // แสดงข้อมูล JSON จาก then ข้างบน
                })
        })
    })
});
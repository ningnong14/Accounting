$(document).ready(() => {
    let login = "";
    let password = "";

    Swal.fire({
        title: 'Login Form',
        html: `<input type="text" id="login" class="swal2-input" placeholder="Username">
               <input type="password" id="password" class="swal2-input" placeholder="Password">`,
        confirmButtonText: 'Sign in',
        focusConfirm: false,
        allowOutsideClick: false,
        preConfirm: () => {
            login = Swal.getPopup().querySelector('#login').value
            password = Swal.getPopup().querySelector('#password').value
            if (!login || !password) {
                Swal.showValidationMessage(`Please enter login and password`)
            }
            return { login: "", password: ""}
        }
    }).then((result) => {
        url = baseURL() + `api/Login/ValidateUser`;
        username = login;
        password = password;
        fetch(url, {
            method: "POST",
            headers: [
                ["Content-Type", "application/json"],
                ["Content-Type", "text/plain"]
            ],
            credentials: "include",
            body: JSON.stringify({
                username: username,
                password: password
            }),
        })
            .then(function (response) {
                if (response.ok == false) {
                    /*loading('show');*/
                    Swal.fire({
                        icon: 'error',
                        title: 'Login fail',
                        text: 'Username Password Wrong!',
                        confirmButtonColor: '#3085d6',
                        confirmButtonText: 'ตกลง'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.href = baseURL() + "/login";
                        }
                    })
                }
                return response.json() // แปลงข้อมูลที่ได้เป็น json
            })
            .then(function (data) {
                if (data.code == "200") {
                    localStorage.setItem("Username", data.username);
                    console.log(baseURL());
                    window.location.href = baseURL() + "/home";
                }
                console.log("LoginData", data); // แสดงข้อมูล JSON จาก then ข้างบน
            })
    })
});
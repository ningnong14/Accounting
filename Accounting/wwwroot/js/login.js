$(document).ready(() => {
    $('#buttonSummit').click(function () {
        url = baseURL() + `api/Login/ValidateUser`;
        username = $('#textUserName').val();
        password = $('#textPassword').val();
        console.log(url);
        console.log(username);
        console.log(password);
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
                console.log(response);
                if (response.status == "200") {
                    
                }
                return response.json() // แปลงข้อมูลที่ได้เป็น json
            })
            .then(function (data) {
                console.log(data); // แสดงข้อมูล JSON จาก then ข้างบน
            })
    })
})
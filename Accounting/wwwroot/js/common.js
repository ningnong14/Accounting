function baseURL() {
    var hostname = window.location.hostname;
    console.log("hostname", hostname);
    var baseURL = "";
    if (hostname.indexOf('localhost') > -1) {
        baseURL = "";
    }
    else {
        var orgin = window.localtion.orgin;
        baseURL = origin + $('#baseURL').val();
    }
    console.log("URL",baseURL);
    return baseURL;
}

function loading(status) {
    if (status == 'show') {
        Swal.fire({
            title: 'Loading',
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading()
                const b = Swal.getHtmlContainer().querySelector('b')
                timerInterval = setInterval(() => {
                }, 1000)
            }
        });
    } else {
        clearInterval(timerInterval);
        swal.close();
    }
}
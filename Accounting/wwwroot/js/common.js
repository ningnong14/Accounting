function baseURL() {
    var hostname = window.location.hostname;
    console.log(hostname);
    var baseURL = "";
    if (hostname.indexOf('localhost') > -1) {
        baseURL = "";
    }
    else {
        var orgin = window.localtion.orgin;
        baseURL = origin + $('#baseURL').val();
    }
    console.log(baseURL);
    return baseURL;
}
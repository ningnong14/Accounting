$(document).ready(() => {
    console.log("already function");
    $('#function_1').on("click", function (event) {
        window.location.href = baseURL() + "/serach";
    });
    $('#function_2').on("click", function (event) {
        window.location.href = baseURL() + "/AddMainAccount";
    });
    $('#function_3').on("click", function (event) {
        window.location.href = baseURL() + "/RecordAccounting";
    });
});
$(document).ready(() => {
    $('.content_table').hide();
    $('.cal').hide();
    $('#buttonSearch').click(function () {
        var serachResult = {
            NameCompany: $('#nameCompany').val(),
            TagId: $('#tagId').val(),
            Date: $('#date').val(),
            Description: $('#description').val()
        };
        console.log(serachResult);
    })
    $('#buttonClear').click(function () {
        $('#nameCompany').val("1");
        $('#tagId').val("");
        $('#date').val("");
        $('#description').val("");
    })
});
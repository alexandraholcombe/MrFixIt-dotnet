var test = "it works";

$(document).ready(function () {
    $(".claim-job").click(function () {
        //debugger;
        var currentId = $(this).parent().attr('id');
        console.log(currentId);
        $.ajax({
            type: 'GET',
            dataType: 'html',
            url: $(this).data('request-url'),
            success: function (result) {
                $('.unclaimed').html(result);
            }
        });
    });
});
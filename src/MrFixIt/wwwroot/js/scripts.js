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
                $('#' + currentId + '.unclaimed').html(result);
            }
        });
    });

    //submits claim to db
    $(".confirm-claim").submit(function (e) {
        e.preventDefault();
        var currentId = $(this).parent().parent().attr('id');
        var jobProperties = $('.confirm-claim').serializeArray();
        console.log(jobProperties);
        $.ajax({
            type: "POST",
            dataType: 'json',
            data: $(this).serialize(),
            url: $(this).data('url-action'),
            complete: function (result) {
                var resultMessage = "<p>You have claimed this job.</p>";
                $('#' + currentId + '.result').html(resultMessage);
            }

        })
    })
});
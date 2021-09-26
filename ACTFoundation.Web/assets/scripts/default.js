$(document).ready(function () {

        $("#btnSubscribe").click(function () {
            $.ajax({
                url: "/subscriptions/add?email=" + $("#email").val(),
                type: "POST",
                success: function (response) {
                    $("#email").val('');
                    alert('Uspesno ste se registrovali na ACT Foundation newsletter!');
                },
                error: function (err) {
                    console.log('Failed', err);
                }
            });
    });
})
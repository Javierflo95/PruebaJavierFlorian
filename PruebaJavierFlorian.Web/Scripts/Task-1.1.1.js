$(function () {

    var user = $("#userId").val();
    if (user != null) {
        alert(user);
        $("#user_userName").val(user);
    }
        

    $(".btnEliminar").on("click", function () {
        var _id = $(this).data('id');
        var nombre = $(this).data('nombre');

        var result = confirm("Esta seguro de eliminar la tarea ? " + nombre);

        if (result) {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { id: _id },
                url: GetURL() + "/Task/Delete"
            }).done(function (data) {
                if (!data.Message)
                    location.reload();
                else
                    alert(data.Message);
            }).fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert(textStatus + " : " + errorThrown);
            });
        }


    });

});

function GetURL() {
    var nameProject = '';
    var url;

    url = window.location.host + "/";
    if (url.split(":")[0] != "localhost") {
        nameProject = "Application/";
    }
    url = window.location.protocol + "//" + url + nameProject;
    return url;
}
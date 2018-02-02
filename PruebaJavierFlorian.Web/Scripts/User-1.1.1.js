$(function () {


    $(".btnEliminar").on("click", function () {
        var _userName = $(this).data('id');

        var result = confirm("Esta seguro de eliminar el usuario ? " + _userName);

        if (result) {
            $.ajax({
                cache: false,
                type: "POST",
                dataType: "json",
                data: { userName: _userName },
                url: GetURL() + "/User/Delete"
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
var url = "";
$(document).ready(function () {
    $("#alert-dialog").dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        resizable: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
        },
        buttons: {
            "OK": function () { $(this).dialog("close"); },
            "Cancel": function () { $(this).dialog("close"); }
        }
    });

    $("#detail-dialog").dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        resizable: false,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
            $(this).load(url);
        },
        buttons: {
            "Close": function () { $(this).dialog("close"); }
        }
    });

    $("#create-dialog").dialog({
        title: "Create User",
        autoOpen: false,
        modal: true,
        resizable: false,
        width: 400,
        draggable: true,
        oepn: function (event, ui) {
            $('.ui-dialog-titlebar-close').hide();
            $(this).load(url);
        }
    });

    $("#delete-dialog").dialog({
        title: "Confirm Deletion of User",
        autoOpen: false,
        resizable: false,
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
        },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
                window.location.href = url;
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    if ('@TempData["msg"]' != "") {
        $("#alert-dialog").dialog("open");
    }

    $(".linkCreate").on("click", function (e) {
        //e.preventDefault();
        url = $(this).attr("href");
        $("#create-dialog").dialog("open");

        return false;
    });

    $(".linkDetail").on("click", function (e) {
        url = $(this).attr("href");
        $("#details-dialog").dialog("open");

        return false;
    });

    $(".linkEdit").on("click", function (e) {
        $(".ui-dialog-title").html("Update User");
        url = $(this).attr("href");
        $("#create-dialog").dialog("open");

        return false;
    });

    $(".linkDelete").on("click", function (e) {
        url = $(this).attr("href");
        $("#delete-dialog").dialog("open");

        return false;
    })

    $("#btnCancel").on("click", function (e) {
        $("#create-dialog").dialog("close");
        return false;
    });
});
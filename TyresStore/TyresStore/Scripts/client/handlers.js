﻿var mainModel = null;

function displayTiresLg(tyresHtml) {
    //$(".vehicles-table").addClass("half");
        $(".tyres-table .table-content").html("").hide();
        $(".vehicles-table").animate({
            width: "50%"
        }, 500, function () {
            var htmlContent = tyresHtml;
            if (tyresHtml.length > 0) {
                $(".tyres-table .table-content").append(htmlContent).hide().fadeIn(300);
            } else {
                $(".tyres-table .table-content").append("<span class='no-data-message'>No tyres available for this vehicle</span>");
            }
        });
   
    //mainModel.showLoadingTyres = false;
}

function displayTiresSm(tyresHtml, vehicleID) {
    html = "<tr id=\"tyres_vehicle_" + vehicleID + "\"><td colspan=\"5\"><div class=\"col-md-12 \">";
    html += tyresHtml;
    html += "</div></td></tr>"

    $("#vehicle_" + vehicleID).after(html);
    $("#tyres_vehicle_" + vehicleID).hide().fadeIn("slow")
}

function closeTyres(elem) {
    if (window.innerWidth > 720) {
        $(".tyres-table .table-content").html("").hide();

        $(".vehicles-table").animate({
            width: "100%"
        }, 500, function () {});
    } else {
        var element = elem.closest("tr").id;
        $("#" + element).fadeOut("slow", function () {
            this.remove();
        })
        //console.log(trId);
    }

}

function login(vehicleId = 0) {
    console.log("click login");
    var input_username = $("#login-input-username").val();
    var input_password = $("#login-input-password").val();

    $.ajax({
        url: "Home/DoLogin",
        type: "post",
        data: { username: input_username, password: input_password },
        success: function (response) {
            console.log(response);
            if (response > 0) {
                // show required tyres.
                console.log(vehicleId);
                mainModel.loadTyres(vehicleId);
            } else {
                // if fail show form again with error
                $("#login-span-error").text("Error, try again.");
            }
        }
    });
}

function updateCartCount() {
    $(".cart-button").html("("+basketModel.basketItems.length+")");
}

function displayPage(page = "Index") {
    // remove animation
    $(".container.body-content").fadeOut("slow", function () {
        $(this).empty();
        $.ajax({
            url: "Home/" + page,
            type: "get",
            success: function (html) {
                // append html and show animation
                $(".container.body-content").html(html).fadeIn("slow");
            }
        });
    });

    
}

window.onload = function () {
    mainModel = new MainModel();
}
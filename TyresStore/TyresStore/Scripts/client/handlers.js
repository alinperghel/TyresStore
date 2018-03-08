function displayTires(tyresHtml) {
    // todo : add animation
    $(".tyres-table .table-content").html("").hide();
    //$(".vehicles-table").addClass("half");

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

$('.select-vehicle-button').on('click', function () {
    $(this).parent().parent().after('salut');

});

function closeTyres() {
    $(".tyres-table .table-content").html("").hide();
    $(".vehicles-table").animate({
        width: "100%"
    }, 500, function () {

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
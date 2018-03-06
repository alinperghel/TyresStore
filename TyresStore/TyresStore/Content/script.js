$(document).ready(function (x) {
    $("#shop_now").click(function (e) {
        console.log("shop button clicked");
        e.preventDefault();
        $('html, body').animate({
            scrollTop: $("#shop_goto").offset().top
        }, 1000);
    });
});
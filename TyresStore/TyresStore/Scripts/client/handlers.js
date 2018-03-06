function displayTires(tyresHtml) {
    $(".vehicles-table").addClass("half");

    $(".tyres-table .table-content").html("");
    var htmlContent = tyresHtml;

    if (tyresHtml.length > 0) {
        $(".tyres-table .table-content").append(htmlContent);
    } else {
        $(".tyres-table .table-content").append("<span class='no-data-message'>No tyres available for this vehicle</span>");
    }
    //mainModel.showLoadingTyres = false;
}

window.onload = function () {
    mainModel = new MainModel();
}
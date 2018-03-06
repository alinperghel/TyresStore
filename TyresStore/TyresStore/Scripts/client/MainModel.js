var mainModel = null;
var basketModel = null;

function MainModel() {
    var _self = this;

    this.showLoadingTyres = false;
    //basketModel = new basketModel();
    //basketModel.getItems();

    this.loadTyres = function (vehicleID) {
        $.ajax({
            url: "Home/GetTyres",
            type: "get",
            data: { vehicleId: vehicleID },
            success: function (response) {
                console.log(response);
                displayTires(response);
                
            }
        });
    }

    //this.updateCart = function (tyreID, description = "") {
    //    basketModel.addItem(tyreID, description);
    //}
}
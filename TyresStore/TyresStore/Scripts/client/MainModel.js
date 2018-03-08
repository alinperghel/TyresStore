var mainModel = null;
var basketModel = null;

function MainModel() {
    var _self = this;

    this.showLoadingTyres = false;
    basketModel = new BasketModel();
    basketModel.getItems();

    this.loadTyres = function (vehicleID) {
        //console.log(this);
        $.ajax({
            url: "Home/GetTyres",
            type: "get",
            data: { vehicleId: vehicleID },
            success: function (response) {
                //console.log(response);
                if (window.innerWidth > 720) {
                    displayTiresLg(response);
                } else {
                    displayTiresSm(response, vehicleID);
                }
                
                
            }
        });
    }

    this.updateCart = function (tyreID, brand = "", article="", season="", price="" ) {
        basketModel.addItem(tyreID, brand, article, season, price);
    }
}
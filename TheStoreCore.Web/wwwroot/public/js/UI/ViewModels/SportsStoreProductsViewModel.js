var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var SportsStoreProductsViewModel = (function () {
            function SportsStoreProductsViewModel(dataService) {
                this.dataServices = dataService;
                this.products = ko.observableArray([]);
            }
            SportsStoreProductsViewModel.prototype.getProducts = function () {
                var _this = this;
                this.dataServices.Get().done(function (data) {
                    _this.products.removeAll();
                    _this.products.push(data);
                });
            };
            return SportsStoreProductsViewModel;
        }());
        UI.SportsStoreProductsViewModel = SportsStoreProductsViewModel;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

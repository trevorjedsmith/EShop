var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var data = TheStoreCore.Data;
        var TheStoreProductsController = (function () {
            function TheStoreProductsController() {
                this.dataService = new data.TheStoreCoreDataService($, 'products/getProducts');
            }
            TheStoreProductsController.prototype.PageLoad = function () {
                var viewModel = new TheStoreCore.UI.TheStoreProductsViewModel(this.dataService);
                ko.applyBindings(viewModel);
            };
            return TheStoreProductsController;
        }());
        UI.TheStoreProductsController = TheStoreProductsController;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

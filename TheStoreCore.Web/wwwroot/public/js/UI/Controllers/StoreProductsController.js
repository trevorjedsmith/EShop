var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var data = TheStoreCore.Data;
        var SportsStoreProductsController = (function () {
            function SportsStoreProductsController(containerElementId) {
                this.dataService = new data.TheStoreCoreDataService($, 'products/getProducts');
                this.containerElementId = containerElementId;
                console.log(this.containerElementId);
            }
            SportsStoreProductsController.prototype.PageLoad = function () {
                var container = $('#test');
                console.log(container);
                var viewModel = new TheStoreCore.UI.SportsStoreProductsViewModel(this.dataService);
                ko.applyBindings(viewModel);
            };
            return SportsStoreProductsController;
        }());
        UI.SportsStoreProductsController = SportsStoreProductsController;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

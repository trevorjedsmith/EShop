var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var data = TheStoreCore.Data;
        var TheStoreCartController = (function () {
            function TheStoreCartController() {
                this.dataService = new data.TheStoreCoreDataService($, 'cart/getAllCartItems');
            }
            TheStoreCartController.prototype.PageLoad = function () {
                var viewModel = new TheStoreCore.UI.TheStoreCartViewModel(this.dataService);
                console.log(viewModel);
                ko.applyBindings(viewModel);
            };
            return TheStoreCartController;
        }());
        UI.TheStoreCartController = TheStoreCartController;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

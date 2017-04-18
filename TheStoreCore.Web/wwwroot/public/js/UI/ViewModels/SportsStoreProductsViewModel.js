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
                this.dataServices.ExecuteGet(this.dataServices.baseUri).done(function (retData) {
                    _this.products.removeAll();
                    _this.products.push.apply(_this.products, retData.data.products);
                    _this.totalPages = retData.data.pagingInfo.totalPages;
                    _this.itemsPerPage = retData.data.pagingInfo.itemsPerPage;
                    _this.currentPage = retData.data.pagingInfo.currentPage;
                }).fail(function (error) { console.log(error); });
                console.log(this.products);
                console.log(this.totalPages);
                console.log(this.itemsPerPage);
                console.log(this.currentPage);
            };
            SportsStoreProductsViewModel.prototype.getPages = function () {
                var pages;
                for (var i = 0; i < this.totalPages; i++) {
                    pages[i] = this.dataServices.baseUri + '/page' + i + 1;
                }
                return pages;
            };
            return SportsStoreProductsViewModel;
        }());
        UI.SportsStoreProductsViewModel = SportsStoreProductsViewModel;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

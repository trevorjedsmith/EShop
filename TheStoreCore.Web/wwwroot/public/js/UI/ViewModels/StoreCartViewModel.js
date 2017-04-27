var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var TheStoreCartViewModel = (function () {
            function TheStoreCartViewModel(dataService) {
                var _this = this;
                this.addToCart = function (cartItem) {
                    var ds = new TheStoreCore.Data.TheStoreCoreDataService($, 'cart/addProduct');
                    var params = {
                        productId: cartItem.product.id,
                    };
                    ds.ExecuteGet(ds.baseUri, params).done(function (retData) {
                        _this.applyCartItems(retData);
                    });
                };
                this.applyCartItems = function (returnData) {
                    _this.cartItems.removeAll();
                    _this.cartItems.push.apply(_this.cartItems, returnData.cart.lines);
                    _this.cartTotal(returnData.total);
                };
                this.removeFromCart = function (cartItem) {
                    var ds = new TheStoreCore.Data.TheStoreCoreDataService($, 'cart/removeProduct');
                    ds.ExecuteDelete(ds.baseUri, cartItem.product.id).done(function (retData) {
                        _this.applyCartItems(retData);
                    });
                };
                this.continueShopping = function () {
                };
                this.checkOut = function () {
                };
                this.dataServices = dataService;
                this.cartCount = ko.observable(0);
                this.cartTotal = ko.observable(0);
                this.cartItems = ko.observableArray([]);
                this.onInit();
            }
            TheStoreCartViewModel.prototype.onInit = function () {
                var _this = this;
                this.dataServices.ExecuteGet(this.dataServices.baseUri).done(function (retData) {
                    console.log(retData);
                    _this.applyCartItems(retData);
                }).fail(function (error) { console.log(error); });
            };
            return TheStoreCartViewModel;
        }());
        UI.TheStoreCartViewModel = TheStoreCartViewModel;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

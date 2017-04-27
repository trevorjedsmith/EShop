var TheStoreCore;
(function (TheStoreCore) {
    var UI;
    (function (UI) {
        var TheStoreProductsViewModel = (function () {
            function TheStoreProductsViewModel(dataService) {
                var _this = this;
                this.addToCart = function (product) {
                    var ds = new TheStoreCore.Data.TheStoreCoreDataService($, 'cart/addProduct');
                    var params = {
                        productId: product.id,
                    };
                    ds.ExecuteGet(ds.baseUri, params).done(function (retData) {
                        console.log(retData);
                        _this.applyCartItems(retData);
                    });
                };
                this.setCategory = function (category) {
                    _this.selectedCategory = category;
                    var params = {
                        category: category
                    };
                    var ds = new TheStoreCore.Data.TheStoreCoreDataService($, 'products/getProducts');
                    ds.ExecuteGet(ds.baseUri, params).done(function (retData) {
                        //populating products
                        _this.applyProducts(retData);
                    });
                };
                this.applyProducts = function (returnData) {
                    _this.products.removeAll();
                    _this.products.push.apply(_this.products, returnData.data.products);
                };
                this.applyCategories = function () {
                    _this.categories.removeAll();
                    _this.categories.push.apply(_this.categories, _this.products().map(function (p) {
                        return p.category;
                    }).filter(function (value, index, self) {
                        return self.indexOf(value) === index;
                    }).sort());
                };
                this.applyCartItems = function (returnData) {
                    _this.cartItems.removeAll();
                    _this.cartItems.push.apply(_this.cartItems, returnData.cart.lines);
                    _this.total(returnData.total);
                    _this.cartCount(returnData.count);
                };
                this.showCart = function () {
                    $('#cart').popover('toggle');
                };
                this.fadeIn = function (element) {
                    setTimeout(function () {
                        $('#cart').popover('show');
                        $(element).slideDown(function () {
                            setTimeout(function () {
                                $('#cart').popover('hide');
                            }, 2000);
                        });
                    }, 100);
                };
                this.dataServices = dataService;
                this.products = ko.observableArray([]);
                this.categories = ko.observableArray([]);
                this.cartCount = ko.observable(0);
                this.cartItems = ko.observableArray([]);
                this.total = ko.observable(0);
                this.onInit();
            }
            TheStoreProductsViewModel.prototype.onInit = function () {
                var _this = this;
                this.dataServices.ExecuteGet(this.dataServices.baseUri).done(function (retData) {
                    //populating products
                    _this.applyProducts(retData);
                    //populating categories
                    _this.applyCategories();
                    $('#cart').popover({
                        html: true,
                        content: function () {
                            return $('#cart-summary').html();
                        },
                        title: 'Cart Details',
                        placement: 'bottom',
                        animation: true,
                        trigger: 'manual'
                    });
                }).fail(function (error) { console.log(error); });
            };
            return TheStoreProductsViewModel;
        }());
        UI.TheStoreProductsViewModel = TheStoreProductsViewModel;
    })(UI = TheStoreCore.UI || (TheStoreCore.UI = {}));
})(TheStoreCore || (TheStoreCore = {}));

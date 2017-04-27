namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class TheStoreProductsViewModel {


        private dataServices: data.TheStoreCoreDataService<entity.Product>;

        private products: KnockoutObservableArray<Entities.Product>;

        private categories: KnockoutObservableArray<string>;

        private selectedCategory: string;

        private cartItems: KnockoutObservableArray<Entities.Cart>;

        private cartCount: KnockoutObservable<number>;

        private cartID: number;

        private total: KnockoutObservable<number>;

        constructor(dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>) {
            this.dataServices = dataService;
            this.products = ko.observableArray([]);
            this.categories = ko.observableArray([]);

            this.cartCount = ko.observable(0);
            this.cartItems = ko.observableArray([]);

            this.total = ko.observable(0);

            this.onInit();

        }

        onInit() {
            this.dataServices.ExecuteGet(this.dataServices.baseUri).done((retData: any) => {

                //populating products
                this.applyProducts(retData);

                //populating categories
                this.applyCategories();

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

            }).fail((error) => { console.log(error) });
        }

        addToCart = (product: entity.Product) => {

            let ds = new TheStoreCore.Data.TheStoreCoreDataService<entity.Product>($, 'cart/addProduct');
            var params = {
                productId: product.id,
            }

            ds.ExecuteGet(ds.baseUri, params).done((retData: any) => {
                console.log(retData);
                this.applyCartItems(retData);
            });  

        }

        setCategory = (category: string) => {

            this.selectedCategory = category;

            var params = {
                category: category
            }

            let ds = new TheStoreCore.Data.TheStoreCoreDataService<entity.Product>($, 'products/getProducts');
            ds.ExecuteGet(ds.baseUri, params).done((retData: any) => {
                //populating products
                this.applyProducts(retData);
            });        
        }

        applyProducts = (returnData: any) => {
            this.products.removeAll();
            this.products.push.apply(this.products, returnData.data.products);
        }

        applyCategories = () => {
            this.categories.removeAll();
            this.categories.push.apply(this.categories, this.products().map(function (p) {
                return p.category
            }).filter(function (value, index, self) {
                return self.indexOf(value) === index;
            }).sort());
        } 


        applyCartItems = (returnData: any) => {
            this.cartItems.removeAll();
            this.cartItems.push.apply(this.cartItems, returnData.cart.lines);
            this.total(returnData.total);
            this.cartCount(returnData.count);
        }

        showCart = () => {
            $('#cart').popover('toggle');
        }

        fadeIn = (element) => {
            setTimeout(function () {
                $('#cart').popover('show');

                $(element).slideDown(function () {
                    setTimeout(function () {
                        $('#cart').popover('hide');
                    }, 2000);
                });
            }, 100);
        };

        
    }
}
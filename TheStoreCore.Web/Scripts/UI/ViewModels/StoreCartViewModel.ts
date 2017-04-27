namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class TheStoreCartViewModel {


        private dataServices: data.TheStoreCoreDataService<entity.Product>;

        private cartItems: KnockoutObservableArray<Entities.Cart>;

        private cartTotal: KnockoutObservable<number>;

        private cartCount: KnockoutObservable<number>;

        private cartID: number;


        constructor(dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>) {
            this.dataServices = dataService;

            this.cartCount = ko.observable(0);
            this.cartTotal = ko.observable(0);
            this.cartItems = ko.observableArray([]);
            this.onInit();

        }

        onInit() {
            this.dataServices.ExecuteGet(this.dataServices.baseUri).done((retData: any) => {
               console.log(retData);
               this.applyCartItems(retData);
            }).fail((error) => { console.log(error) });
        }

        addToCart = (cartItem: any) => {

            let ds = new TheStoreCore.Data.TheStoreCoreDataService<entity.Product>($, 'cart/addProduct');
            var params = {
                productId: cartItem.product.id,
            }

            ds.ExecuteGet(ds.baseUri, params).done((retData: any) => {
                this.applyCartItems(retData);
            });  

        }


        applyCartItems = (returnData: any) => {
            this.cartItems.removeAll();
            this.cartItems.push.apply(this.cartItems, returnData.cart.lines);
            this.cartTotal(returnData.total);
        }

        removeFromCart = (cartItem: any) => {

            let ds = new TheStoreCore.Data.TheStoreCoreDataService<entity.Product>($, 'cart/removeProduct');

            ds.ExecuteDelete(ds.baseUri, cartItem.product.id).done((retData: any) => {
                this.applyCartItems(retData);
            }); 
        }

        continueShopping = () => {

        }

        checkOut = () => {

        }
    }
}
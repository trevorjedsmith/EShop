namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class SportsStoreProductsViewModel {

        private dataServices: data.TheStoreCoreDataService<entity.Product>;

        private products: KnockoutObservableArray<Entities.Product>;

        constructor(dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>) {
            this.dataServices = dataService;
            this.products = ko.observableArray([]);
        }

        getProducts() {
            this.dataServices.Get().done((data) => {
                this.products.removeAll();
                this.products.push(data);
            });
        }

       
    }
}
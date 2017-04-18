namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class SportsStoreProductsViewModel {

        private dataServices: data.TheStoreCoreDataService<entity.Product>;

        private products: KnockoutObservableArray<Entities.Product>;

        //Paging Info
        private totalPages: number;
        private itemsPerPage: number;
        private currentPage: number;

        constructor(dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>) {
            this.dataServices = dataService;
            this.products = ko.observableArray([]);
        }

        getProducts() {
            this.dataServices.ExecuteGet(this.dataServices.baseUri).done((retData: any) =>
            {
                this.products.removeAll();
                this.products.push.apply(this.products, retData.data.products);
                this.totalPages = retData.data.pagingInfo.totalPages;
                this.itemsPerPage = retData.data.pagingInfo.itemsPerPage;
                this.currentPage = retData.data.pagingInfo.currentPage;
            }).fail((error) => { console.log(error) });

        }
       
    }
}
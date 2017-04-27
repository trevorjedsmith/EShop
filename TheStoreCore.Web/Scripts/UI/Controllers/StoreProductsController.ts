namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class TheStoreProductsController {
        private dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>;
        private containerElementId: string;

        constructor() {
            this.dataService = new data.TheStoreCoreDataService($, 'products/getProducts');
        }

        PageLoad() {
            let viewModel = new TheStoreCore.UI.TheStoreProductsViewModel(this.dataService);
            ko.applyBindings(viewModel);
        }

    }
}
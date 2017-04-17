namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class SportsStoreProductsController {
        private dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>;
        private containerElementId: string;

        constructor(containerElementId: string) {
            this.dataService = new data.TheStoreCoreDataService($, 'products/getProducts');
            this.containerElementId = containerElementId;
            console.log(this.containerElementId);
        }

        PageLoad() {
            let container = $('#test');
            console.log(container);
            let viewModel = new TheStoreCore.UI.SportsStoreProductsViewModel(this.dataService);
            ko.applyBindings(viewModel);
        }

    }
}
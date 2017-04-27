namespace TheStoreCore.UI {

    import data = TheStoreCore.Data;
    import entity = TheStoreCore.Entities;

    export class TheStoreCartController {
        private dataService: TheStoreCore.Data.TheStoreCoreDataService<entity.Product>;


        constructor() {
            this.dataService = new data.TheStoreCoreDataService($, 'cart/getAllCartItems');
        }

        PageLoad() {
            let viewModel = new TheStoreCore.UI.TheStoreCartViewModel(this.dataService);
            console.log(viewModel);
            ko.applyBindings(viewModel);
        }

    }
}
namespace TheStoreCore.Entities {
    export interface Cart extends BaseEntity {
        product: Product;
        quantity: number;
        cartID: number;
    }
}
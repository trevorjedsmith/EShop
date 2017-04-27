namespace TheStoreCore.Entities {
    export interface Product extends BaseEntity {
        name: string;
        description: string;
        price: number;
        category: string;
    }
}
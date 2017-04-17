namespace TheStoreCore.Entities {
    export interface Product extends BaseEntity {
        Name: string;
        Description: string;
        Price: number;
        Category: string;
    }
}
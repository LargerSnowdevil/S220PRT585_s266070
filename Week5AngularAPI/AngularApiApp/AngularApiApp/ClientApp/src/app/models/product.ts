export class Product {
    productId?: number;
    name: string;
    quantity: number;
    language: string;
    category: {
        categoryId: number;
        name?: string;
        code?: string;
    };
}

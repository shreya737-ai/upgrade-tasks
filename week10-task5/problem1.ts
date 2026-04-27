// 1. Generic Function
function getFirstElement<T>(items: T[]): T {
    return items[0];
}

// 2. Generic Interface
interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}

// 3. Generic Class
class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    public add(item: T): void {
        this.items.push(item);
    }

    public getAll(): T[] {
        return this.items;
    }
}

// 4. Models

interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}

// 5. Use Case Implementation

// User Data Manager
const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "John" });
userManager.add({ id: 2, name: "Alice" });

// Product Data Manager
const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });

// Testing Generic Function
const firstUser = getFirstElement(userManager.getAll());
const firstProduct = getFirstElement(productManager.getAll());

// 6. Output

console.log("Users:");
console.log(userManager.getAll());

console.log("\nProducts:");
console.log(productManager.getAll());

console.log("\nFirst User:");
console.log(firstUser);

console.log("\nFirst Product:");
console.log(firstProduct);
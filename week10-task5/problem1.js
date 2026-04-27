"use strict";
// 1. Generic Function
function getFirstElement(items) {
    return items[0];
}
// 3. Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// 5. Use Case Implementation
// User Data Manager
const userManager = new DataManager();
userManager.add({ id: 1, name: "John" });
userManager.add({ id: 2, name: "Alice" });
// Product Data Manager
const productManager = new DataManager();
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

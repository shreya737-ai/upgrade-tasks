// cart.js

// Array of product objects
export const cartItems = [
  { name: "Laptop", price: 50000, quantity: 1 },
  { name: "Mouse", price: 800, quantity: 2 },
  { name: "Keyboard", price: 1500, quantity: 1 },
];

// Arrow function to calculate total cart value using reduce()
export const calculateTotal = (items) =>
  items.reduce((total, item) => total + item.price * item.quantity, 0);
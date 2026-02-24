// invoice.js

import { cartItems, calculateTotal } from "./productcart-summary.js";

// Create formatted invoice using map()
const generateInvoice = (items) => {
  console.log("SHOPPING CART INVOICE");
  console.log("-----------------------------------");

  items
    .map(
      (item) =>
        `${item.name} | ₹${item.price} x ${item.quantity} = ₹${
          item.price * item.quantity
        }`
    )
    .forEach((line) => console.log(line));

  const total = calculateTotal(items);

  console.log("-----------------------------------");
  console.log(`Total Amount: ₹${total}`);
};

// Run invoice generator
generateInvoice(cartItems);
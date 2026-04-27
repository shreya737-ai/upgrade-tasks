// 1. Variable Declaration (with explicit types)
const userName: string = "John";
let age: number = 25; // using let because we will update it
const email: string = "john@example.com";
const isSubscribed: boolean = true;

// 2. Type Inference (no explicit types)
let city = "Bangalore";   // inferred as string
let loginCount = 5;       // inferred as number

// 3. Template Literal (initial message)
const userMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log("User Profile:");
console.log(userMessage);

// 4. Operators

// Increment age by 1
age = age + 1;
console.log(`Updated Age: ${age}`);

// Check premium eligibility (age > 18 AND subscribed)
const isEligibleForPremium: boolean = age > 18 && isSubscribed;

// Comparison and logical operators
console.log(`Is age greater than 18? ${age > 18}`);
console.log(`Is user subscribed? ${isSubscribed}`);
console.log(`Eligible for Premium Plan? ${isEligibleForPremium}`);

// Additional output for inferred variables
console.log(`City: ${city}`);
console.log(`Login Count: ${loginCount}`);
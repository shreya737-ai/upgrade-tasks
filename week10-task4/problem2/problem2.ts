// 1. Function with Required Parameters
function getWelcomeMessage(name: string): string {
    return `Welcome ${name}! Glad to have you onboard.`;
}

// 2. Optional Parameters
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age information.`;
}

// 3. Default Parameters
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    return isSubscribed
        ? `${name} is subscribed to our services.`
        : `${name} is not subscribed to our services.`;
}

// 4. Return Type (Boolean function)
function isEligible(age: number): boolean {
    return age > 18;
}

// 5. Arrow Functions
const getAccountUpdateMessage = (name: string): string => {
    return `Hello ${name}, your account has been successfully updated.`;
};

// 6. Lexical 'this' using Arrow Function
const notificationService = {
    appName: "MyApp",

    // Arrow function preserves lexical 'this'
    sendNotification: (message: string): string => {
        return `[${notificationService.appName}] Notification: ${message}`;
    }
};

// 7. Execution (Testing all functions)
const username: string = "John";

console.log(getWelcomeMessage(username));

console.log(getUserInfo(username, 25));
console.log(getUserInfo(username)); // without age

console.log(getSubscriptionStatus(username, true));
console.log(getSubscriptionStatus(username)); // default false

console.log("Eligible for Premium:", isEligible(25));

console.log(getAccountUpdateMessage(username));

console.log(notificationService.sendNotification("Your profile is updated successfully."));
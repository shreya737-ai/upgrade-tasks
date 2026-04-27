"use strict";
// 1. Base Class: Employee
class Employee {
    id;
    name;
    salary;
    // Constructor
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    // 2. Getter
    getSalary() {
        return this.salary;
    }
    // 2. Setter with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    // 3. Method
    displayDetails() {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Employee Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}
// 4. Derived Class: Manager
class Manager extends Employee {
    teamSize;
    // Constructor
    constructor(id, name, salary, teamSize) {
        super(id, name, salary); // call base constructor
        this.teamSize = teamSize;
    }
    // 5. Method Overriding
    displayDetails() {
        super.displayDetails(); // reuse base method
        console.log(`Team Size: ${this.teamSize}`);
    }
}
// 6. Object Creation & Execution
// Employee Object
const emp1 = new Employee(1, "John", 30000);
emp1.displayDetails();
console.log("Updated Salary:");
emp1.setSalary(35000);
console.log(emp1.getSalary());
console.log("\n-------------------\n");
// Manager Object
const mgr1 = new Manager(2, "Alice", 60000, 5);
mgr1.displayDetails();
console.log("Updated Manager Salary:");
mgr1.setSalary(65000);
console.log(mgr1.getSalary());

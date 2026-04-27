"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const student_service_1 = require("./student.service");
const utils_1 = require("./utils");
// Sample Data
const students = [
    { id: 1, name: "john", marks: 85 },
    { id: 2, name: "alice", marks: 92 },
    { id: 3, name: "bob", marks: 67 }
];
// Formatted Names
console.log("Formatted Names:");
students.forEach(s => {
    console.log((0, utils_1.formatName)(s.name));
});
// Grades
console.log("\nGrades:");
students.forEach(s => {
    console.log(`${(0, utils_1.formatName)(s.name)}: ${(0, student_service_1.getGrade)(s.marks)}`);
});
// Average Marks
const avg = (0, utils_1.calculateAverage)(students);
console.log("\nAverage Marks:", avg);
// Topper
const topper = (0, student_service_1.getTopper)(students);
console.log("\nTopper:");
console.log(`${(0, utils_1.formatName)(topper.name)} with ${topper.marks} marks`);

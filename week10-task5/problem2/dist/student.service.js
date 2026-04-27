"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.getGrade = getGrade;
exports.getTopper = getTopper;
const constants_1 = require("./constants");
// Get Grade based on marks
function getGrade(marks) {
    if (marks >= 90)
        return "A";
    if (marks >= 75)
        return "B";
    if (marks >= constants_1.PASS_MARKS)
        return "C";
    return "F";
}
// Get Topper
function getTopper(students) {
    return students.reduce((topper, student) => student.marks > topper.marks ? student : topper);
}

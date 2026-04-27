import { Student } from "./student.model";
import { PASS_MARKS } from "./constants";

// Get Grade based on marks
export function getGrade(marks: number): string {
    if (marks >= 90) return "A";
    if (marks >= 75) return "B";
    if (marks >= PASS_MARKS) return "C";
    return "F";
}

// Get Topper
export function getTopper(students: Student[]): Student {
    return students.reduce((topper, student) =>
        student.marks > topper.marks ? student : topper
    );
}
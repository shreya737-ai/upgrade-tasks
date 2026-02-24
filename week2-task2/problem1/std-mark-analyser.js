let studentMarks = [85, 92, 78, 96, 88, 73, 90, 87];
const totalMarks = (marks)=>marks.reduce((acc, mark) => acc + mark, 0);

const averageMarks = (marks)=>totalMarks(marks) / marks.length;

const result =(avg)=>{
    return avg >=40 ? "pass" : "fail";
}
const displayMarks = (marks) =>
  marks.map((mark, index) =>
    `Student ${index + 1}: ${mark} marks`
  );

const analysemarks = (marks)=>{
    const total = totalMarks(marks);
    const average = averageMarks(marks);
    const finalResult = result(average);
    
    displayMarks(marks).forEach(mark => console.log(mark));
    console.log(`Total Marks: ${total}`);
    console.log(`Average Marks: ${average.toFixed(2)}`);
    console.log(`Result: ${finalResult}`);
}
analysemarks(studentMarks);
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentScoreAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] marks = { 78, 85, 90, 67, 88 };
            int threshold = 80;

            // Total using Aggregate (reduce equivalent)
            int totalMarks = marks.Aggregate((sum, mark) => sum + mark);

            // Average
            double averageMarks = (double)totalMarks / marks.Length;

            // Highest using iteration
            int highestScore = marks[0];
            for (int i = 1; i < marks.Length; i++)
            {
                if (marks[i] > highestScore)
                {
                    highestScore = marks[i];
                }
            }

            // Filter above threshold
            var aboveThreshold = marks.Where(mark => mark > threshold).ToArray();

            // Dictionary for subject-wise highest
            Dictionary<string, int> subjectHighest = new Dictionary<string, int>
            {
                { "Math", 90 },
                { "Science", 88 },
                { "English", 85 }
            };

            Console.WriteLine("Total Marks: " + totalMarks);
            Console.WriteLine("Average Marks: " + averageMarks);
            Console.WriteLine("Students above 80: " + aboveThreshold.Length);
            Console.WriteLine("Highest Score: " + highestScore);
        }
    }
}
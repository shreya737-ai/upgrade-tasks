using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            List<Product> products = new Product().GetProducts();

            //1. Display all products with category "FMCG"
            Console.WriteLine("1. Products with category FMCG");
            var q1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in q1)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //2. Display all products with category "Grain"
            Console.WriteLine("2. Products with category Grain");
            var q2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in q2)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //3. Sort products in ascending order by product code
            Console.WriteLine("3. Products sorted by Product Code (Ascending)");
            var q3 = products.OrderBy(p => p.ProCode);
            foreach (var item in q3)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //4. Sort products in ascending order by product Category
            Console.WriteLine("4. Products sorted by Product Category (Ascending)");
            var q4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in q4)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //5. Sort products in ascending order by product Mrp
            Console.WriteLine("5. Products sorted by Product MRP (Ascending)");
            var q5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in q5)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //6. Sort products in descending order by product Mrp
            Console.WriteLine("6. Products sorted by Product MRP (Descending)");
            var q6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in q6)
            {
                Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory} {item.ProMrp}");
            }
            Console.WriteLine();

            //7. Display products grouped by product Category
            Console.WriteLine("7. Products grouped by Category");
            var q7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in q7)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProMrp}");
                }
                Console.WriteLine();
            }

            //8. Display products grouped by product Mrp
            Console.WriteLine("8. Products grouped by MRP");
            var q8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in q8)
            {
                Console.WriteLine($"MRP: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode} {item.ProName} {item.ProCategory}");
                }
                Console.WriteLine();
            }

            //9. Display product detail with highest price in FMCG category
            Console.WriteLine("9. Highest priced product in FMCG category");
            var q9 = products
                        .Where(p => p.ProCategory == "FMCG")
                        .OrderByDescending(p => p.ProMrp)
                        .FirstOrDefault();

            if (q9 != null)
            {
                Console.WriteLine($"{q9.ProCode} {q9.ProName} {q9.ProCategory} {q9.ProMrp}");
            }
            Console.WriteLine();

            //10. Display count of total products
            Console.WriteLine("10. Total number of products");
            var q10 = products.Count();
            Console.WriteLine($"Total Products: {q10}");
            Console.WriteLine();

            //11. Display count of total products with category FMCG
            Console.WriteLine("11. Total number of FMCG products");
            var q11 = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine($"FMCG Products Count: {q11}");
            Console.WriteLine();

            //12. Display Max price
            Console.WriteLine("12. Maximum price");
            var q12 = products.Max(p => p.ProMrp);
            Console.WriteLine($"Max Price: {q12}");
            Console.WriteLine();

            //13. Display Min price
            Console.WriteLine("13. Minimum price");
            var q13 = products.Min(p => p.ProMrp);
            Console.WriteLine($"Min Price: {q13}");
            Console.WriteLine();

            //14. Check whether all products are below MRP Rs.30
            Console.WriteLine("14. Are all products below Rs.30?");
            var q14 = products.All(p => p.ProMrp < 30);
            Console.WriteLine(q14);
            Console.WriteLine();

            //15. Check whether any products are below MRP Rs.30
            Console.WriteLine("15. Are any products below Rs.30?");
            var q15 = products.Any(p => p.ProMrp < 30);
            Console.WriteLine(q15);
            Console.WriteLine();
        }
    }
}

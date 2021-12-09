using System.Linq;
namespace DemoLINQ
{
    class Program
    {
        class DepartmentClass
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
        }

        class EmployeeClass
        {
            public int EmployeeId { get; set; }
            public string EmployeeName { get; set; }
            public int DepartmentId { get; set; }
        }

        class Animal
        {
            public string Name { get; set; }
        }

        class Cat : Animal
        {
            public double Weight { get; set; }
        }

        static void Main(string[] args)
        {
            #region
            string[] words ={ "one", "two", "three", "five", "six" };
            var result = words.Select((w, i) => new { Index = i, Value = w }).Where(w => w.Value.Length <= 4).ToList();
            Console.WriteLine("Prints index for words that have a string length of 3:");
            foreach (var word in result)
            {
                Console.WriteLine(word.Value);
                Console.WriteLine(word.Index.ToString());
            }
            #endregion

            #region
            List<string> vegetables = new List<string> { "Carrot", "Selleri" };
            var result1 = from v in vegetables select v;
            Console.WriteLine("Elements in vegetables array (before add): " + result.Count());
            vegetables.Add("Broccoli");
            Console.WriteLine("Elements in vegetables array (after add): " + result.Count());

            List<string> animals = new List<string> { "dog", "cat", "duck", "bird" };
            var animal = from a in animals
                         where a.Equals("dog")
                         select a;
            Console.WriteLine(animal.Count());
            #endregion

            #region
            int[] numbers = { 1, 11, 18, 23, 30, 79 };
            var baseQuery = from b in numbers select b;
            var oddQuery = from o in numbers where o % 2 == 0 select o;
            Console.WriteLine("so chan ");
            foreach (var oddquery in oddQuery)
            {
                Console.WriteLine(oddquery);
            }
            Console.WriteLine("tong so chan la " + oddQuery.Sum());
            var evevQuery = from e in numbers where e % 2 == 1 select e;
            Console.WriteLine("so le ");
            foreach (var evevquery in evevQuery)
            {
                Console.WriteLine(evevquery);
            }
            Console.WriteLine("tong so le la " + evevQuery.Sum());
            #endregion

            #region
            var peoples = new[] {
            new { Name = "Patty", Age = 25, IsMale = false },
            new { Name = "Kenny", Age = 43, IsMale = true },
            new { Name = "Kate", Age = 37, IsMale = false }
        };
            var result2 = peoples.Where(p => p.Name.StartsWith("K")).Select(p => p);

            //var result2 =from p in peoples where( p.Name.StartsWith("K")) select p;
            foreach (var people in result2)
            {
                Console.WriteLine(people.Name);
            }
            #endregion

            #region
            string[] Words = { "hello", "wonderful", "LINQ", "beautiful", "world" };
            var shoertWords = Words.Where(word => word.Length <= 5).Select(word => word);
            foreach (var word in shoertWords)
            {
                Console.Write(word + " ");
            }
            #endregion

            #region
            Console.WriteLine();
            int[] scores =  { 13, 43, 56, 86, 54, 88, 7 };
            IEnumerable<int> scoresQuery = from score in scores where score > 0 && score < 50 select score;
            foreach (int score in scoresQuery)
            {
                Console.Write(score + " ");
            }
            #endregion

            #region
            Console.WriteLine();
            string[] words1 = new[] { "an", "apple", "a", "day" };

            IEnumerable<string> query = from word in words1 select word.Substring(0, 1);

            foreach (string s in query)
                Console.WriteLine(s);
            Console.ReadLine();
            #endregion

            #region
            List<DepartmentClass> department = new List<DepartmentClass>();
            department.Add(new DepartmentClass() { DepartmentId = 1, Name = "Account" });
            department.Add(new DepartmentClass() { DepartmentId = 2, Name = "Sales" });
            department.Add(new DepartmentClass() { DepartmentId = 3, Name = "Marketing" });

            List<EmployeeClass> employees = new List<EmployeeClass>();
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 1, EmployeeName = "William" });
            employees.Add(new EmployeeClass { DepartmentId = 2, EmployeeId = 2, EmployeeName = "Miley" });
            employees.Add(new EmployeeClass { DepartmentId = 1, EmployeeId = 3, EmployeeName = "Benjamin" });

            var list = (from e in employees join d in department 

                        on e.DepartmentId equals d.DepartmentId
                        select new
                        {
                            EmployeeName = e.EmployeeName,
                            DepartmentName = d.Name,
                        });

            foreach(var item in list)
            {
                Console.WriteLine("Employee Name: {0}   Department Name: {1} ",item.EmployeeName,item.DepartmentName);
            }
            #endregion

            #region
            int[] num = { -10,-9,-20, 12, 6, 10, 0, -3, 1,5,7,100 };
            var posNums =from posnum in num 
                         orderby posnum
                         select posnum;
            Console.WriteLine("Values in ascending order: ");
            foreach(int p in posNums)
            {
                Console.WriteLine(p);
            }

            var posNumsDesc = from posnumsdesc in num
                              orderby posnumsdesc descending
                              select posnumsdesc;
            Console.WriteLine("Values in descending order: ");//giam dan:descending
            foreach (int p in posNumsDesc)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Values");
            var Nums = from nums in num
                       select nums;
            foreach (int p in Nums)
            {
                Console.WriteLine(p);
            }
            #endregion

            #region
            List<double> numbers1 = new List<double>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };

            IEnumerable<IGrouping<double, double >> query1 = from number in numbers1
                                                     group number by number % 2;

            foreach (var group in query1)
            {
                Console.WriteLine(group.Key == 1 ? "\nOdd numbers:" : "\nEven numbers:");

                foreach (int i in group)
                    Console.WriteLine(i);
            }
            #endregion

            #region

            #region dung mang
            Cat[] Cats = new Cat[]
            {
                new Cat{ Name = "Miu", Weight = 30 },
                new Cat{ Name = "Mun", Weight = 40 },
                new Cat{ Name = "Su", Weight = 50 },
                new Cat { Name = "Bun", Weight = 20 }
            };


            var Cat = from Cat cat in Cats
                      where cat.Weight <= 40
                      select cat;
            #endregion
            #region dung list
            //List<Cat> Cats = new List<Cat>();

            //Cats.Add(new Cat() { Name = "Miu", Weight = 30 });
            //Cats.Add(new Cat() { Name = "Mun", Weight = 40 });
            //Cats.Add(new Cat() { Name = "Su", Weight = 50 });
            //Cats.Add(new Cat (){ Name = "Bun", Weight = 20 });
            //var Cat = from cat in Cats
            //            where cat.Weight <=40
            //            select cat;
            #endregion
            foreach (var cat in Cat)
            {
                Console.WriteLine("Name cat = {0} , Weight ={1}",cat.Name,cat.Weight);
            }

            Console.WriteLine("\nPress any key to continue.");
            #endregion
            Console.ReadKey();
        }
    }
}

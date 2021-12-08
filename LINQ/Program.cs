
namespace LINQ 
{ 
    class Program
    { 
        public static void QueryIntNumber()
        {
          int[] numbers = new int[]{ 1, 2, 3,4,5,6,7,8,9,10,11 };
            var QueryResult = from number in numbers
                              where (number %2)==0 
                              select number;
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        static void Main(string[] args)
        {
           
            Console.ReadKey();
        }
    }
}

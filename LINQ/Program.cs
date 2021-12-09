
using System.Xml.Linq;

namespace LINQ 
{ 
    class Program
    { public static void QueryXMLFile(string fileName)
        {
            var xmlDocument = XDocument.Load(fileName);
            IEnumerable<string> fileNames = from film in xmlDocument.Descendants("film")
                                            where (int)film.Element("releaseYear") == 2021
                                            select film.Element("name").Value;
            foreach (string filmName in fileNames)
            {
                Console.WriteLine(filmName);
            }
            var foundedFilms = from film in xmlDocument.Descendants("film")
                               select new
                               {
                                   Name = film.Element("name").Value,
                                   ReleaseYear = film.Element("releaseYear").Value

                               };
            foreach (var foundedFilm in foundedFilms)
            {
                Console.WriteLine("Name: {0}   ReleaseYear: {1} ",foundedFilm.Name,foundedFilm.ReleaseYear);
            }
        }
        public static void QueryIntNumber()
        {
          int[] numbers = new int[]{ 1, 2, 3,4,5,6,7,8,9,10,11 };
            var queryResult = from number in numbers
                              where (number %2)==0 
                              select number;
            foreach (int number in queryResult)
            {
                Console.Write(number+" ");
                
            }
            Console.WriteLine();
            Console.WriteLine("Convert query result to array ");
            var arrayOfNumber = queryResult.ToArray();
            foreach (int number in arrayOfNumber)
            {
                Console.Write(number+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Convert query result to list ");
            var listOfNumber = queryResult.ToList();
            foreach (int number in listOfNumber)
            {
                Console.Write(number+" ");
            }
        }
        static void Main(string[] args)
        {
           Program.QueryXMLFile("D:/hocthem/LINQ/LINQ/LINQ/films.xml");
         //  Program.QueryIntNumber();


            Console.ReadKey();
        }
    }
}

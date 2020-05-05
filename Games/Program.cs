using System;

namespace Games
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a number and press enter");
            while (true)
            {
                Matchresults results = new Matchresults();
                string test = Console.ReadLine();
                var arrayCreated = results.CreatArray(test);
                var resultsFromGame = results.TotalAmountOfPoints(arrayCreated, results);
                Console.WriteLine(results.WriteOutResultsFromGame(resultsFromGame));

            }
        }
    }
}

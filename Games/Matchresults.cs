using System;
using System.Collections.Generic;

namespace Games
{
    public class Matchresults
    {
        public int CountPoints { get; set; }
        public int CountMatches { get; set; }
        public int CountWinMatches { get; set; }
        public int CountEvenMatches { get; set; }
        public int CountLostMatches { get; set; }

        public Matchresults GeMatcResults(int _countPoints, int _countMatches,
            int _countWinMatches, int _countEvenMatches, int _countLostMatches)
        {
            var getResultFromGame = new Matchresults()
            {
                CountPoints = _countPoints,
                CountMatches = _countMatches,
                CountWinMatches = _countWinMatches,
                CountEvenMatches = _countEvenMatches,
                CountLostMatches = _countLostMatches,

            };
            return getResultFromGame;
        }
        public List<string> CreatArray(string games)
        {
            Random random = new Random();
            List<string> createMatchList = new List<string>();
            if (long.TryParse(games, out long numberOfgames))
            {
                for (int i = 0; i < numberOfgames; i++)
                {
                    var x = random.Next(0, 20);
                    var y = random.Next(0, 20);
                    createMatchList.Add(x.ToString() + ":" + y.ToString());
                }
            }
            return createMatchList;
        }

        public Matchresults TotalAmountOfPoints(List<string> listOfgames, Matchresults result)
        {
            foreach (var item in listOfgames)
            {
                var splitByColonMatches = item.Split(':');
                int[] convertToInArrayMatches = Array.ConvertAll(splitByColonMatches, int.Parse);
                if (convertToInArrayMatches[0] > convertToInArrayMatches[1])
                {
                    result.CountPoints += 3;
                    result.CountWinMatches++;
                }
                if (convertToInArrayMatches[0] < convertToInArrayMatches[1])
                    result.CountLostMatches++;
                if (convertToInArrayMatches[0] == convertToInArrayMatches[1])
                {
                    result.CountPoints += 1;
                    result.CountEvenMatches++;
                }
                result.CountMatches++;
            }
            return result.GeMatcResults(result.CountPoints, result.CountMatches, result.CountWinMatches, result.CountEvenMatches, result.CountLostMatches);
        }

        public string WriteOutResultsFromGame(Matchresults resultsFromGame)
        {
            return $"Total Games: {resultsFromGame.CountMatches}" + Environment.NewLine +
            $"Points: {resultsFromGame.CountPoints}" + Environment.NewLine +
            $"Wins: {resultsFromGame.CountWinMatches}" + Environment.NewLine +
            $"Lost: {resultsFromGame.CountEvenMatches}" + Environment.NewLine +
            $"Ewen: {resultsFromGame.CountLostMatches}" + Environment.NewLine +
            $"-----------------------------------";
        }
    }
}

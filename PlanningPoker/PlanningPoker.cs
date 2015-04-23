using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace PlanningPoker
{
    public class PlanningPoker
    {
        public PlanningPoker(int noPlayers)
        {
            AddGame(noPlayers);
        }

        public int AddGame(int noPlayers)
        {
            if (noPlayers == 0 || noPlayers == 1)
            {
                Console.WriteLine("Not enough Players");
                return 0;
            }
                else
                    {
                        Player[] players = new Player[noPlayers];
                        for (int x = 0; x < noPlayers; x++)
                        {
                            players[x] = new Player();
                        }
                        return players.Count();
                    }
            //    throw new NotImplementedException();
        }

        public class Player
        {
            public string Name { get; set; }
        }
        public class Story
        {

            public List<int> CreateList()
            {
               List<int> playerEstimations = new List<int>();
               return playerEstimations;
            }

            public List<int> NormalizeList(List<int> playerEstimations)
            {
                int minimum = playerEstimations.Min();
                int maximum = playerEstimations.Max();

                playerEstimations.Remove(minimum);
                playerEstimations.Remove(maximum);

                return playerEstimations;
                // throw new NotImplementedException();
            }

            public void AddPlayerEstimation(int playerEstimation, List<int> playerEstimations)
            {
               playerEstimations.Add(playerEstimation);
            }

            public int CalculateEstimationAvgRoundDown(int noPlayers, List<int> playerEstimations)
            {
                return (playerEstimations.Sum())/noPlayers;
            }

            public int CalculateEstimationMedianRoundDown(int noPlayers, List<int> playerEstimations)
            {
                List<int> sortedNumbers = playerEstimations;
                sortedNumbers.Sort();
                // get median
                int mid = noPlayers/2;
                int median = (noPlayers % 2 != 0) ? sortedNumbers[mid] : (sortedNumbers[mid] + sortedNumbers[mid - 1]) / 2;
                return median;
            }

            public int CalculateEstimationAvgRoundUp(int noPlayers, List<int> playerEstimations)
            {
                int estimationSum = playerEstimations.Sum();
                bool dividedEvenly = (estimationSum % noPlayers) == 0;
                if (dividedEvenly)
                    return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
                bool wasRoundedDown = ((estimationSum > 0) == (noPlayers > 0));
               
                if (wasRoundedDown)
                    return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations) + 1;
                    
                return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
            }

            public int CalculateEstimationAllEqual(int noPlayers, List<int> playerEstimations)
            {

                if (playerEstimations.Distinct().Skip(1).Any())
                {
                    Console.WriteLine("Estimations need to be equal");
                    return 0;
                }
                else
                    {
                        return CalculateEstimationAvgRoundDown(noPlayers, playerEstimations);
                    }
            }
        }
    }
}

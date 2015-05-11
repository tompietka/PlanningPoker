using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker
{
    public class PlanningPoker
    {
        public PlanningPoker(params string[] playerNames)
        {
            Validate(playerNames);
            Players = playerNames.Select(x => new Player(x)).ToList();
        }

        private static void Validate(string[] playerNames)
        {
            if (playerNames == null) throw new ArgumentException("Not Enough Players");
            if (playerNames.Length <= 2) throw new ArgumentException("Player Name should be 3 or greater");
            if (playerNames.Any(x => x == string.Empty)) throw new ArgumentException("Every Player should have name");
            if (playerNames.Distinct().Count() != playerNames.Length) throw new ArgumentException("Every Player should have distinct name");
        }

        public IList<Player> Players { get; private set; }
    }
}

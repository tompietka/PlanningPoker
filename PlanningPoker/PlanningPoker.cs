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
            if (playerNames == null) throw new ArgumentException("Dodaj więcej graczy");
            if (playerNames.Length <= 2) throw new ArgumentException("Gra musi mieć conajmniej 3 graczy");
            if (playerNames.Any(x => x.Length <= 2)) throw new ArgumentException("Gracze muszą mieć imiona dłuższe niż 2 znaki");
            if (playerNames.Any(x => x == string.Empty)) throw new ArgumentException("Każdy gracz musi mieć imię");
            if (playerNames.Distinct().Count() != playerNames.Length) throw new ArgumentException("Nie można dodać gry z graczami o tym samym imieniu");
        }

        public IList<Player> Players { get; private set; }
    }
}

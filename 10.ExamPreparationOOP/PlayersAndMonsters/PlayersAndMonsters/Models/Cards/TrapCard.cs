

namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card
    {
        private const int initialHealthPoints = 5;
        private const int initialDamagePoints = 120;

        public TrapCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}

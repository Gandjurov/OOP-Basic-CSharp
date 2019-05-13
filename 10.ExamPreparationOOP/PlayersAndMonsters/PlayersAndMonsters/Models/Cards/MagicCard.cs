namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class MagicCard : Card
    {
        private const int initialHealthPoints = 80;
        private const int initialDamagePoints = 5;

        public MagicCard(string name) 
            : base(name, initialDamagePoints, initialHealthPoints)
        {
        }
    }
}

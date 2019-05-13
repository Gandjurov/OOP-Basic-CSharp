namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards
        {
            get { return this.cards; }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            var cardExists = this.cards
                                 .Any(x => x.Name == card.Name);

            if (cardExists)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cards
                .FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (!Cards.Contains(card))
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.cards.Remove(card);
        }
    }
}

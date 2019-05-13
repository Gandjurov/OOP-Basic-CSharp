namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get
            {
                return username;
            }
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value,
                    "Player's username cannot be null or an empty string.");

                this.username = value;
            }
        }
        
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                Validator.ThrowIfNumberIsOrNegative(
                    value, "Player's health bonus cannot be less than zero.");

                this.health = value;
            }
        }

        
        public bool IsDead => this.Health <= 0;


        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }


            if (this.Health - damagePoints >= 0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;
            }

        }
    }
}

namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            var playerExists = this.players
                .Any(x => x.Username == player.Username);

            if (playerExists)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            var currentPlayer = this.players.FirstOrDefault(x => x.Username == username);
            return currentPlayer;
        }

        public bool Remove(IPlayer player)
        {
            if (!Players.Contains(player))
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.players.Remove(player);
        }
    }
}

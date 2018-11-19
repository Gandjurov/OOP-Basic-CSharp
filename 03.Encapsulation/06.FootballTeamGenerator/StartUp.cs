using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var teams = new List<Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(';');

                try
                {
                    if (tokens[0] == "Team")
                    {
                        teams.Add(new Team(tokens[1]));
                    }
                    else if (tokens[0] == "Add")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        var playerName = tokens[2];
                        var endurance = int.Parse(tokens[3]);
                        var sprint = int.Parse(tokens[4]);
                        var dribble = int.Parse(tokens[5]);
                        var passing = int.Parse(tokens[6]);
                        var shooting = int.Parse(tokens[7]);

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        team.AddPlayer(player);
                    }

                    else if (tokens[0] == "Remove")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        team.RemovePlayer(tokens[2]);
                    }

                    else if (tokens[0] == "Rating")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {tokens[1]} does not exist.");
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

using FifaPlayers.Classes;
using System;
using System.Collections.Generic;

namespace FifaPlayers
{
    public class Menu
    {
        App app = new App();
        DataAccess dataAccess = new DataAccess();
        public void StartMenu()
        {
            Console.Clear();
            app.WhiteCenterTextWithoutNewLine("Vad vill du göra?");

            app.CenterText("A) Skapa ditt fantasylag");
            app.CenterText("B) Ändra i ditt fantasy");
            app.CenterText("C) Se på ditt fantasylag");
            app.CenterText("");
            app.CenterText("");
            StartMenyChoices(Console.ReadKey().Key);

        }
       public void StartMenyChoices(ConsoleKey command)
        {
            switch (command)
            {
                case ConsoleKey.A: AddUserTeam(); break;
                case ConsoleKey.B: någonmetod: break;
                case ConsoleKey.C: någonmetod2: break;
            }
        }

        private void AddUserTeam()
        {
            app.WhiteCenterTextWithoutNewLine("Ange ett önskat lagnamn: ");
            CreateUserTeam(Console.ReadLine());
            List<FootballPlayer> GoalKeepers = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Goalkeeper);
            ShowPlayers(GoalKeepers);
            Console.WriteLine("Välj en målvakt genom att skriva in Id");
            AddPlayerToTeam(int.Parse(Console.ReadLine()));
        }

        private void AddPlayerToTeam(int id)
        {
            new UserTeamPlayer
            {
                PlayerId = id,
                UserTeamId = 
            }
        }

        private void ShowPlayers(List<FootballPlayer> player)
        {
            foreach (var item in player)
            {
                Console.WriteLine($"ID:{item.Id} Namn:{item.FirstName} {item.LastName} Pris:{item.Price}kr Position: {item.Position} Lag:{item.RealTeam.Name}" );
            }
        }

        private void CreateUserTeam(string teamname)
        {
            using (var context = new FifaContext())
            {
                var userTeam = new UserTeam
                {
                    TeamName = teamname,
                    TeamMoney = 10000000,
                    UserTeamPlayers = new List<UserTeamPlayer>()
                };
                context.UserTeams.Add(userTeam);
                context.SaveChanges();
            }
        }
    }
}

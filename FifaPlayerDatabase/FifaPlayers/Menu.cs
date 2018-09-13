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
            StartMenuChoices(Console.ReadKey().Key);
        }

        public void StartMenuChoices(ConsoleKey command)
        {
            switch (command)
            {
                case ConsoleKey.A: AddUserTeam(); break;
                case ConsoleKey.B: någonmetod: break;
                case ConsoleKey.C: ShowUserTeamLineUp(dataAccess.GetActiveUserId()); break;
            }
        }

        private void ShowUserTeamLineUp(int id)
        {
            List<FootballPlayer> players = dataAccess.GetUserTeamPlayers(id);
            foreach (var player in players)
            {
                app.CenterText($"{player.Position.ToString()}: {player.Name}");
            }
            Console.ReadKey();
        }

        private void AddUserTeam()
        {

            app.WhiteCenterTextWithoutNewLine("Ange ett önskat lagnamn: ");
            CreateUserTeam(Console.ReadLine());
            ShowUserTeamMoney();
            GoalKeeperChoice();
            DefendersChoice();
            MidfielderChoice();
            ForwardChoice();
            ShowUserTeamLineUp(dataAccess.GetActiveUserId());
        }
        private void GoalKeeperChoice()
        {
            List<FootballPlayer> GoalKeepers = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Goalkeeper);
            ShowPlayers(GoalKeepers);
            app.WhiteCenterTextWithoutNewLine("Välj en målvakt genom att skriva in Id");
            AddPlayerToTeam(int.Parse(Console.ReadLine()));
        }

        private void DefendersChoice()
        {
            List<FootballPlayer> defenders = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Defender);
            for (int i = 0; i < 3; i++)
            {
                ShowPlayers(defenders);
                app.WhiteCenterTextWithoutNewLine("Välj back genom att skriva in Id");
                int id = int.Parse(Console.ReadLine());
                defenders.RemoveAt(id);
                AddPlayerToTeam(id);
                ShowUserTeamMoney();
                Console.ReadKey();
            }
        }

        private void ForwardChoice()
        {
            List<FootballPlayer> forwards = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Midfielder);
            for (int i = 0; i < 1; i++)
            {
                ShowPlayers(forwards);
                app.WhiteCenterTextWithoutNewLine("Välj forward genom att skriva in Id");
                int id = int.Parse(Console.ReadLine());
                forwards.RemoveAt(id);
                AddPlayerToTeam(id);
                ShowUserTeamMoney();
                Console.ReadKey();
            }
        }

        private void MidfielderChoice()
        {
            List<FootballPlayer> midfielders = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Midfielder);
            for (int i = 0; i < 3; i++)
            {
                ShowPlayers(midfielders);
                app.WhiteCenterTextWithoutNewLine("Välj mittfältare genom att skriva in Id");
                int id = int.Parse(Console.ReadLine());
                midfielders.RemoveAt(id);
                AddPlayerToTeam(id);
                ShowUserTeamMoney();
                Console.ReadKey();
            }

        }

        private void ShowUserTeamMoney()
        {
            UserTeam userTeam = dataAccess.GetCashOfUserTeam(dataAccess.GetActiveUserId());
            app.CenterText($"{userTeam.TeamMoney}");
        }

        private void AddPlayerToTeam(int id)
        {
            new UserTeamPlayer
            {
                PlayerId = id,
                UserTeamId = dataAccess.GetActiveUserId()
            };
        }

        private void ShowPlayers(List<FootballPlayer> player)
        {
            foreach (var item in player)
            {
                app.CenterText($"ID:{item.Id} Namn:{item.Name} Pris:{item.Price}kr Position: {item.Position} Lag:{item.RealTeam.Name}");
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

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
            app.CenterText("Vad vill du göra?");

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
                case ConsoleKey.B: ChangePlayersInTeam(); break;
                case ConsoleKey.C: ShowUserTeamLineUp(); break;
            }
        }

        private void ChangePlayersInTeam()
        {
            throw new NotImplementedException();
        }

        private void ShowUserTeamLineUp()
        {
            List<FootballPlayer> players = dataAccess.GetUserTeamPlayers(LogIn.CurrentUser.Id);
            foreach (var player in players)
            {
                app.CenterText($"{player.Position.ToString()}: {player.Name}");
            }
            Console.ReadKey();
            StartMenu();
        }

        private void AddUserTeam()
        {
            app.CenterText("Ange ett önskat lagnamn: ");
            CreateUserTeam(Console.ReadLine());
            //ShowUserTeamMoney();
            GoalKeeperChoice();
            DefendersChoice();
            MidfielderChoice();
            ForwardChoice();
            ShowUserTeamLineUp();
        }
        private void GoalKeeperChoice()
        {
            if (dataAccess.CheckNumberofPlayers(Position.Goalkeeper)<1)
            {
                Console.Clear();
                app.CenterText("Välj en målvakt genom att skriva in Id");
                List<FootballPlayer> GoalKeepers = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Goalkeeper);
                ShowPlayers(GoalKeepers);
                AddPlayerToTeam(int.Parse(Console.ReadLine()));
            }

        }

        private void DefendersChoice()
        {
            int tal = dataAccess.CheckNumberofPlayers(Position.Defender);
            if (tal <= 4)
            {
                List<FootballPlayer> defenders = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Defender);
                for (int i = tal; i < 3; i++)
                {
                    Console.Clear();
                    app.CenterText("Välj back genom att skriva in Id");
                    ShowPlayers(defenders);
                    int id = int.Parse(Console.ReadLine());
                    defenders.RemoveAt(id);
                    AddPlayerToTeam(id);
                    //ShowUserTeamMoney();
                    Console.ReadKey();
                }
            }
        }
        private void MidfielderChoice()
        {
            int tal = dataAccess.CheckNumberofPlayers(Position.Midfielder);
            if (tal <= 4)
            {
                List<FootballPlayer> midfielders = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Midfielder);
                for (int i = tal; i < 3; i++)
                {
                    Console.Clear();
                    app.CenterText("Välj mittfältare genom att skriva in Id");
                    ShowPlayers(midfielders);
                    int id = int.Parse(Console.ReadLine());
                    midfielders.RemoveAt(id);
                    AddPlayerToTeam(id);
                    //ShowUserTeamMoney();
                    Console.ReadKey();
                }
            }
        }
        private void ForwardChoice()
        {
            int tal = dataAccess.CheckNumberofPlayers(Position.Forward);
            if (tal <= 2)
            {
                List<FootballPlayer> forwards = dataAccess.GetAllPlayersWithSpecificPosiction(Position.Forward);
                for (int i = tal; i < 1; i++)
                {
                    Console.Clear();
                    app.CenterText("Välj forward genom att skriva in Id");
                    ShowPlayers(forwards);
                    int id = int.Parse(Console.ReadLine());
                    forwards.RemoveAt(id);
                    AddPlayerToTeam(id);
                    //ShowUserTeamMoney();
                    Console.ReadKey();
                }
            }
        }

        //private void //ShowUserTeamMoney()
        //{
        //    UserTeam userTeam = dataAccess.GetCashOfUserTeam(dataAccess.GetActiveUserId());
        //    app.CenterText($"Du har kvar {userTeam.TeamMoney}kr");
        //}

        private void AddPlayerToTeam(int id)
        {
            using (var context = new FifaContext())
            {
               var userTeamPlayer =  new UserTeamPlayer
                {
                    PlayerId = id,
                    UserTeamId = dataAccess.GetActiveUserId()
                };
                context.UserTeamPlayers.Add(userTeamPlayer);
                context.SaveChanges();
            }
        }

        private void ShowPlayers(List<FootballPlayer> player)
        {
            foreach (var item in player)
            {
                Console.WriteLine($"ID:{item.Id.ToString().PadRight(10)} Namn:{item.Name.PadRight(10)} Pris:{item.Price.ToString().PadRight(10)} Position:{item.Position.ToString().PadRight(10)} Lag:{item.RealTeam.Name}");
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

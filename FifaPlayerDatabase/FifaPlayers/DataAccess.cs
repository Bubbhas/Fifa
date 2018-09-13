using FifaPlayers.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FifaPlayers
{
    public class DataAccess
    {
        private readonly FifaContext context;
        public DataAccess()
        {
            context = new FifaContext();
        }

        internal List<FootballPlayer> GetAllPlayersWithSpecificPosiction(Position position)
        {
            return context.FootballPlayers.Where(x => x.Position == position).ToList();
        }

        internal List<FootballPlayer> GetUserTeamPlayers(int id)
        {
            return context.FootballPlayers.Include(x => x.UserTeamPlayers.Where(p => p.UserTeamId == id)).ToList();
        }

        internal List<FootballPlayer> GetAllPlayersWithSpecificPositionAndRealTeam(Position position, RealTeam realTeam)
        {
            return context.FootballPlayers.Include(x => x.RealTeam).Where(x => x.Position == position && x.RealTeam == realTeam).ToList();
        }

        internal UserTeam GetCashOfUserTeam(int id)
        {
            return context.UserTeams.Where(x => x.Id == id).FirstOrDefault();
        }

        internal List<User> GetListOfUsers()
        {
            return context.Users.ToList();
        }

        internal int GetActiveUserId()
        {
            return context.Users.Select(x => x.Id).FirstOrDefault();
        }

        internal int GetActiveUserTeamId(int userId)
        {
            return context.Users.Single(x => x.Id == userId).ActiveUserTeamId;
        }

        internal string CheckValidationOnUsername(string UserNameInput)
        {
            throw new NotImplementedException();
        }

        internal bool CreateProfile(string username, string password)
        {
            if (UserNameExist(username))
                return false;
            else
            {
                var user = new User
                {
                    UserName = username,
                    Password = password
                };
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
        }

        internal bool UserNameExist(string username)
        {
            return context.Users.Any(x => x.UserName == username);
        }

        internal User TestUserNameAndPassword(string userName, string password)
        {
            return context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}

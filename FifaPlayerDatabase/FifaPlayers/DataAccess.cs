using FifaPlayers.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        internal List<FootballPlayer> GetUserTeamPlayers(int Id)
        {
            return context.FootballPlayers.Include(x => x.UserTeamPlayers.Where(p => p.UserTeamId == Id)).ToList();
        }


    }
}

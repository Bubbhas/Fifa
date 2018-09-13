﻿using FifaPlayers.Classes;
using Microsoft.EntityFrameworkCore;
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

        internal UserTeam GetCash(int id)
        {
            return context.UserTeams.Where(x => x.Id == id);
        }
    }
}

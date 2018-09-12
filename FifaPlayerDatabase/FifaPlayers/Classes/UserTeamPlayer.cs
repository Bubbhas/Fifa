using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPlayers.Classes
{
    public class UserTeamPlayer
    {
        public int UserTeamId { get; set; }
        public UserTeam UserTeam { get; set; }

        public int PlayerId { get; set; }
        public FootballPlayer Player { get; set; }

    }
}

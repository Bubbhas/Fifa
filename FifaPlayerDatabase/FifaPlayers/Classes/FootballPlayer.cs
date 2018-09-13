using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPlayers.Classes
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Position Position { get; set; }

        public int RealTeamId { get; set; }
        public RealTeam RealTeam { get; set; }
        public List<UserTeamPlayer> UserTeamPlayers { get; set; }
    }

    public enum Position
    {
        Forward,
        Midfielder,
        Defender,
        Goalkeeper
    }
}

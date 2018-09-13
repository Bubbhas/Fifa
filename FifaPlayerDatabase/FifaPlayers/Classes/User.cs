using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPlayers.Classes
{
    public class User
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserTeamId { get; set; }
        public UserTeam UserTeam { get; set; }
    }
}

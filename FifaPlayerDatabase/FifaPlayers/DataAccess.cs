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
    }
}

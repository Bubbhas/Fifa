using FifaPlayers.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaPlayers
{
    public class AddPlayer
    {

        public void push()
        {
            AddPlayerFromInternet();
        }

        private void AddPlayerFromInternet()
        {
            var allLines = File.ReadAllLines("AddPLayer.txt");

            List<FootballPlayer> players = new List<FootballPlayer>();

            foreach (var line in allLines)
            {
                var splittedLine = line.Split('\t');


                var name = splittedLine[0].Replace(",", "").Replace("\\", "").Trim();
                name = name.Substring(0, name.Length / 2);

                var position = splittedLine[1];

                players.Add(new FootballPlayer {

                    FirstName = name,
                    Position = Enum.Parse<Position>(position),
                    RealTeam = new RealTeam
                    {
                        Name = "Arsenal"
                    }
               
                }
                );

            }


            //FirstName.Replace(",", "").Replace("\\", "").Trim() "Petr CechPetr Cech"    string
            

        }
    }
}

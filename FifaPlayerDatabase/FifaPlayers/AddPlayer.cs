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
            AddPlayerFromInternet("ManchesterUnited.txt");
            AddPlayerFromInternet("Chelsea.txt");
            AddPlayerFromInternet("Arsenal.txt");
            AddPlayerFromInternet("Tottenham.txt");
            AddPlayerFromInternet("Manchester City.txt");
            AddPlayerFromInternet("Liverpool.txt");
      
        }

        private void AddPlayerFromInternet(string v)
        {
            var allLines = File.ReadAllLines(v);

            List<FootballPlayer> players = new List<FootballPlayer>();

            foreach (var line in allLines)
            {
                var splittedLine = line.Split('\t');


                var name = splittedLine[0].Replace(",", "").Replace("\\", "").Trim();
                name = name.Substring(0, name.Length / 2);

                var position = splittedLine[1];

                players.Add(new FootballPlayer {

                    Name = name,
                    Position = Enum.Parse<Position>(position),
                    RealTeam = new RealTeam
                    {
                        Name = v
                    }
               
                }
                );

                foreach (var item in players)
                {
                    Console.WriteLine(item.Position + item.Name.PadRight(20) + item.RealTeam.ToString().PadRight(20));
                }

            }


            //FirstName.Replace(",", "").Replace("\\", "").Trim() "Petr CechPetr Cech"    string
            

        }
    }
}

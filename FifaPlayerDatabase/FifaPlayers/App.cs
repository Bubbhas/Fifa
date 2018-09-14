using FifaPlayers.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FifaPlayers
{
    public class App
    {

        //public static User CurrentUser;
        internal void Run()
        {

            new LogIn().LogInMethod();
            new Menu().StartMenu();
        }

        public void CenterText(string s)
        {
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + s.Length / 2) + "}", s);
        }
        public void WhiteCenterTextWithoutNewLine(string s)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0," + ((Console.WindowWidth / 2) + s.Length / 2) + "}", s);
            Console.ResetColor();
        }
    }
}

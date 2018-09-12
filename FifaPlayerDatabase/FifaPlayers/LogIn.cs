using System;
using System.Collections.Generic;
using System.Text;

namespace FifaPlayers
{
    public class LogIn
    {
        App app = new App();
        public void LogInMethod()
        {
           
            app.CenterText("(L)ogga in eller (S)kapa konto?");
            string str = Console.ReadLine().ToLower();

            if (str == "l")
            {
                ShowLogIn();
            }
            else if (str == "s")
            {
                ShowCreateProfile();
            }
            else
            {
                app.CenterText("Välj något av alternativen!");
                Console.ReadKey();
                Console.Clear();
                LogInMethod();
            }
        }

        private void ShowCreateProfile()
        {
            Console.Clear();
            app.CenterText("Skapa din profil!\n");
            app.WhiteCenterTextWithoutNewLine("Ange ditt önskade användarnamn: ");
            string username = Console.ReadLine();

        }

        private void ShowLogIn()
        {
            Console.Clear();
            app.WhiteCenterTextWithoutNewLine("Ange ditt användarnamn: ");
        }
    }
}

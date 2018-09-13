using System;
using System.Collections.Generic;
using System.Text;

namespace FifaPlayers
{
    public class LogIn
    {
        DataAccess dataAccess = new DataAccess();
        App app = new App();
        public void LogInMethod()
        {
            app.CenterText("Välkommen till football fantasy");
            Console.WriteLine();
            app.WhiteCenterTextWithoutNewLine("(L)ogga in eller (S)kapa konto?");
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
            //string checkedUsername = dataAccess.CheckValidationOnUsername();
            string password = "";
            app.WhiteCenterTextWithoutNewLine("Ange ditt lösenord: ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            bool successfullCreation = dataAccess.CreateProfile(username, password);
            if(successfullCreation)
            {
                Console.Clear();
                app.CenterText("Ditt konto är skapat");
                Console.ReadKey();
                ShowLogIn();
            }
        }

        private void ShowLogIn()
        {
            Console.Clear();
            app.WhiteCenterTextWithoutNewLine("Ange ditt användarnamn: ");
            string userName = Console.ReadLine();
            string password = "";
            app.WhiteCenterTextWithoutNewLine("Ange ditt lösenord: ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();

            bool access = dataAccess.TestUserNameAndPassword(userName, password);
            if(access)
            {
                Console.Clear();
                app.CenterText("Du är nu inloggad");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                app.CenterText("Felaktigt användarnamn eller lösenord");
                Console.ReadKey();
                ShowLogIn();
            }
        }
    }
}

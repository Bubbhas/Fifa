using System;

namespace FifaPlayers
{
    public class Menu
    {
        App app = new App();
        public void StartMenu()
        {
            Console.Clear();
            app.WhiteCenterTextWithoutNewLine("Vad vill du göra?");

            app.CenterText("A) Skapa ditt fantasylag");
            app.CenterText("B) Ändra i ditt fantasy");
            app.CenterText("C) Se på ditt fantasylag");
            app.CenterText("");
            app.CenterText("");
            StartMenyChoices(Console.ReadKey().Key);

        }
       public void StartMenyChoices(ConsoleKey command)
        {
            switch (command)
            {
                case ConsoleKey.A: Någonmetod: break;
                case ConsoleKey.B: någonmetod: break;
                case ConsoleKey.C: någonmetod2: break;
            }
        }
    }
}

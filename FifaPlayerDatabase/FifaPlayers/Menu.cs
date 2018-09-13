using System;

namespace FifaPlayers
{
    public class Menu
    {
        public void StartMenu()
        {
            ShowNiceArt();
        }

        private void ShowNiceArt()
        {
            App app = new App();
            app.CenterText(@"                              +---------------------------+    ");
            app.CenterText(@"                              |\                          |\   ");
            app.CenterText(@"                              | \    @ \_    /            | \");
            app.CenterText(@"                              |  \  /  \_o--<_/           | o\");
            app.CenterText(@"______________________________|___|/______________________|-|\|__________________");
            app.CenterText(@"         /                   /    /              _ o     / /|_                /");
            app.CenterText(@"        /                   /  _o'------------- / / \ ----/                  /");
            app.CenterText(@"       /                   /  /|_                /\    /                    /");
            app.CenterText(@"      /                   /_ /\ _______________ / / __/                    /");
            app.CenterText(@"     /                      / /                                           /");
            app.CenterText(@"    /                                                                    /");
            app.CenterText(@"   /                                                                    /");
            app.CenterText(@"  /                                                                    /");
            app.CenterText(@"/____________________________________________________________________/");
        }
    }
}

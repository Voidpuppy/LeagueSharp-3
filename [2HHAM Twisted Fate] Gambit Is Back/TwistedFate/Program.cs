using System;
using SharpDX;
using LeagueSharp;
using LeagueSharp.Common;
using System.Drawing;
using Color = System.Drawing.Color;

namespace TwistedFate
{
    class Program
    {
        private static Menu Config;
        private static Orbwalking.Orbwalker Orbwalker;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            #region Verify if my champ is TF
            switch (ObjectManager.Player.ChampionName)
            {
                case "TwistedFate":
                    Game.PrintChat("<font color='#FFFF33'>[2HAM Twisted Fate] Successfully Loaded</font>");
                    break;
                default:
                    Game.PrintChat("[2HAM Twisted Fate] Your Champion is not Twisted Fate");
                    break;
            }
            #endregion
            #region Init Menu
            Config = new Menu(":: [2HAM] Twisted Fate", "TwistedFate", true);

            var OrbMenu = new Menu(":: Orbwalking", "Orbwalking");
            Orbwalker = new Orbwalking.Orbwalker(OrbMenu);
            Config.AddSubMenu(OrbMenu);

            var WMenu = new Menu(":: Spell Config [W]", "spells.config.w");
            {
                WMenu.AddItem(
                    new MenuItem("SelectBlue", "Select [Blue] Card").SetValue(new KeyBind("W".ToCharArray()[0],
                        KeyBindType.Press)));
                WMenu.AddItem(
                    new MenuItem("SelectYellow", "Select [Yellow] Card").SetValue(new KeyBind("E".ToCharArray()[0],
                        KeyBindType.Press)));
                WMenu.AddItem(
                    new MenuItem("SelectRed", "Select [Red] Card").SetValue(new KeyBind("T".ToCharArray()[0],
                        KeyBindType.Press)));
                Config.AddSubMenu(WMenu);
            }
            Config.AddToMainMenu();
            #endregion

            Game.OnUpdate += Game_GameOnUpdate;
            Drawing.OnDraw += Drawing_OnDraw;
            Drawing.OnEndScene += Drawing_OnEndScene;
        }

        private static void Game_GameOnUpdate(EventArgs args)
        {
            #region Select Card
            if (Config.Item("SelectYellow").GetValue<KeyBind>().Active)
            {
                CardSelector.StartSelecting(Cards.Yellow);
            }
            else if (Config.Item("SelectBlue").GetValue<KeyBind>().Active)
            {
                CardSelector.StartSelecting(Cards.Blue);
            }
            else if (Config.Item("SelectRed").GetValue<KeyBind>().Active)
            {
                CardSelector.StartSelecting(Cards.Red);
            }
            #endregion
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
                Utility.DrawCircle(ObjectManager.Player.Position, 5500, Color.Chartreuse, 1, 23, true);
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
                Render.Circle.DrawCircle(ObjectManager.Player.Position, 5500, Color.Chartreuse);
        }
    }
}

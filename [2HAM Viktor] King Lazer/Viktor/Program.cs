using System;
using LeagueSharp;
using LeagueSharp.Common;

namespace Viktor
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        private static void Game_OnGameLoad(EventArgs args)
        {
            switch (ObjectManager.Player.ChampionName)
            {
                case "Viktor":
                    new Champions.Viktor();
                    Game.PrintChat("<font color='#FFFF33'>[2HAM Viktor] Successfully Loaded</font>");
                    break;
                default:
                    Game.PrintChat("[2HAM Viktor] Your Champion is not Viktor");
                    break;
            }
        }
    }
}

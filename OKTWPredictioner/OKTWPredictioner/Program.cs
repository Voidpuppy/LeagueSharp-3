using LeagueSharp;
using LeagueSharp.Common;

namespace OKTWPredictioner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game.PrintChat("OKTW Prediction by Sebby");
            CustomEvents.Game.OnGameLoad += EventHandlers.Game_OnGameLoad;
        }
    }
}

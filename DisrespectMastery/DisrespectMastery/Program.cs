using LeagueSharp.Common;

namespace DisrespectMastery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += DisrespectMastery.OnLoad;
        }
    }
}

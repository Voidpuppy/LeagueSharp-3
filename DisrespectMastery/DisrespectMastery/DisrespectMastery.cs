using System;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace DisrespectMastery
{
    class DisrespectMastery : Customs
    {
        public static int LastEmote = 0;
        public static int MyKills = 0;
        public static int MyAssists = 0;
        public static int MyDeaths = 0;
        public static Random Random;


        public static void OnLoad(EventArgs eventArgs)
        {
            MenuConfig.InitMenu();
            Random = new Random();
            Game.OnUpdate += OnUpdate;
            Game.PrintChat("Mastery Badge Load");
        }

        static void OnUpdate(EventArgs args)
        {
            if (MenuGUI.IsChatOpen)
                return;

            if (ObjectManager.Player.ChampionsKilled > MyKills && IsActive("Use.When.Kill.Enemy"))
            {
                MyKills = ObjectManager.Player.ChampionsKilled;
                Disrespect();
            }
            if (ObjectManager.Player.Assists > MyAssists && IsActive("Use.When.Kill.Enemy"))
            {
                MyAssists = ObjectManager.Player.Assists;
                Disrespect();
            }
            if (ObjectManager.Player.Deaths > MyDeaths && IsActive("Use.When.I.Die"))
            {
                MyDeaths = ObjectManager.Player.Deaths;
                Disrespect();

            }
            if (IsActive("Use.When.I.Die") && ObjectManager.Get<Obj_AI_Hero>()
                    .Any(p => p.IsEnemy && p.IsVisible && p.IsDead && ObjectManager.Player.Distance(p) < 300))
            {
                Disrespect();
            }
        }

        public static void Disrespect()
        {
            if (Utils.GameTimeTickCount - LastEmote > Random.Next(5000, 150000))
            {
                LastEmote = Utils.GameTimeTickCount;
                Game.Say(MasteryBadgeCommand);
            }
        }
    }
}

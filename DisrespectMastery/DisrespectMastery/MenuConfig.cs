using LeagueSharp.Common;

namespace DisrespectMastery
{
    public class MenuConfig
    {
        public static Menu Menu;

        public static void InitMenu()
        {
            Menu = new Menu("Mastery Disrespect", "Mastery Disrespect", true);

            Menu
                .AddItem(new MenuItem("IsEnable", "Enable").SetValue(false));
            Menu
                .AddItem(new MenuItem("Flood.Mastery", "Flood Mastery").SetValue(false));
            Menu
                .AddItem(new MenuItem("Use.When.Kill.Enemy", "Use when kill Enemy").SetValue(true));
            Menu
                .AddItem(new MenuItem("Use.When.I.Die", "Use when I die").SetValue(true));

            Menu
                .AddItem(new MenuItem("devCredits", "Dev by @ TwoHam"));

            Menu.AddToMainMenu();
        }
    }
}

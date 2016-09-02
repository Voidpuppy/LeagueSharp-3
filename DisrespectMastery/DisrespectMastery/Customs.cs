namespace DisrespectMastery
{
    public class Customs
    {
        public static bool IsActive(string menuItem) => MenuConfig.Menu.Item(menuItem).IsActive();
        public static string MasteryBadgeCommand = "/masterybadge";
    }
}

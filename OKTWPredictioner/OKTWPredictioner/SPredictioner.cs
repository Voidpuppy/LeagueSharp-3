using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace OKTWPredictioner
{
    public class SPredictioner
    {
        public static Spell[] Spells = { null, null, null, null };
        public static Menu Config;

        public static void Initialize()
        {
            Config = new Menu("OKTW Predictioner", "oktwpredictioner", true);
            Config.AddItem(new MenuItem("COMBOKEY", "Combo", false).SetValue<KeyBind>(new KeyBind(32U, (KeyBindType)1, false)));
            Config.AddItem(new MenuItem("HARASSKEY", "Harass", false).SetValue<KeyBind>(new KeyBind(67U, (KeyBindType)1, false)));
            Config.AddItem(new MenuItem("ENABLED", "Enabled", false).SetValue<bool>(true));
            Config.AddItem(new MenuItem("HITCHANCE", "Hit Chance").SetValue(new StringList(Utilities.HitchanceNameArray, 2))).SetTooltip("High is recommended", Color.Green);

            Menu menu = new Menu("Skillshots", "spredskillshots", false);

            foreach (SpellData spell in SpellDatabase.Spells)
            {
                if (spell.ChampionName == ObjectManager.Player.CharData.BaseSkinName)
                {
                    Spells[(int)spell.Slot] = new Spell(spell.Slot, spell.Range, (TargetSelector.DamageType)1);
                    Spells[(int)spell.Slot].SetSkillshot((float)spell.Delay / 1000f, (float)spell.Radius, (float)spell.MissileSpeed, spell.Collisionable, spell.Type);
                    menu.AddItem(new MenuItem(string.Format("{0}{1}", (object)spell.ChampionName, (object)spell.Slot), "Convert Spell " + spell.Slot.ToString(), false).SetValue<bool>(true));
                }
            }
            Config.AddSubMenu(menu);
            Config.AddToMainMenu();

            Spellbook.OnCastSpell += EventHandlers.Spellbook_OnCastSpell;
            Obj_AI_Base.OnProcessSpellCast += EventHandlers.Obj_AI_Hero_OnProcessSpellCast;
        }
    }
}

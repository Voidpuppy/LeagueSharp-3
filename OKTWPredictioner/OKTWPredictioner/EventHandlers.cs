using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Linq;

namespace OKTWPredictioner
{
    public class EventHandlers
    {
        private static bool[] handleEvent =
        {
            true,
            true,
            true,
            true,
        };

        public static void Game_OnGameLoad(EventArgs args)
        {
            SPredictioner.Initialize();
        }

        public static void Obj_AI_Hero_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
            {
                SpellSlot slot = Utility.GetSpellSlot(ObjectManager.Player, args.SData.Name);

                if (!Utilities.IsValidSlot(slot))
                    return;

                if (!handleEvent[(int)slot])
                {
                    if (SPredictioner.Spells[(int)slot] != null)
                        handleEvent[(int)slot] = true;
                }
            }
        }

        public static void Spellbook_OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (sender.Owner.IsMe && SPredictioner.Config.Item("ENABLED", false).GetValue<bool>() 
                && (SPredictioner.Config.Item("COMBOKEY", false).GetValue<KeyBind>().Active 
                || SPredictioner.Config.Item("HARASSKEY", false).GetValue<KeyBind>().Active))
            {
                if (!Utilities.IsValidSlot(args.Slot))
                {
                    return;
                }
                if (SPredictioner.Spells[(int)args.Slot] == null)
                {
                    return;
                }
                if (!SPredictioner.Config.Item(string.Format("{0}{1}", ObjectManager.Player.ChampionName, args.Slot), false).GetValue<bool>())
                {
                    return;
                }

                if (handleEvent[(int)args.Slot])
                {
                    args.Process = false;
                    handleEvent[(int)args.Slot] = false;
                    var enemy = args.EndPosition.GetEnemiesInRange(200f).OrderByDescending(p => Utilities.GetPriority(p.ChampionName)).FirstOrDefault();

                    if (enemy == null)
                        enemy = TargetSelector.GetTarget(SPredictioner.Spells[(int)args.Slot].Range, TargetSelector.DamageType.Physical);

                    if (enemy != null)
                        SPredictioner.Spells[(int)args.Slot].CastSebby(enemy, Utilities.HitchanceArray[SPredictioner.Config.Item("SPREDHITC").GetValue<StringList>().SelectedIndex]);
                }
            }
        }
    }
}

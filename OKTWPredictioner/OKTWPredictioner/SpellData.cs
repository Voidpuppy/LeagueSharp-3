using LeagueSharp;
using LeagueSharp.Common;

namespace OKTWPredictioner
{
    public class SpellData
    {
        public SpellData.CollisionObjectTypes[] CollisionObjects = new SpellData.CollisionObjectTypes[0];
        public enum CollisionObjectTypes
        {
            Minion,
            Champions,
            YasuoWall,
        }

        public string[] ExtraMissileNames = new string[0];
        public int ExtraRange = -1;
        public string[] ExtraSpellNames = new string[0];
        public string FromObject = "";
        public string[] FromObjects = new string[0];
        public int Id = -1;
        public string MissileSpellName = "";
        public int MultipleNumber = -1;
        public string ToggleParticleName = "";
        public bool AddHitbox;
        public bool CanBeRemoved;
        public bool Centered;
        public string ChampionName;
        public int DangerValue;
        public int Delay;
        public bool DisabledByDefault;
        public bool DisableFowDetection;
        public bool DontAddExtraDuration;
        public bool DontCheckForDuplicates;
        public bool DontCross;
        public bool DontRemove;
        public int ExtraDuration;
        public bool FixedRange;
        public bool ForceRemove;
        public bool FollowCaster;
        public bool Invert;
        public bool IsDangerous;
        public int MissileAccel;
        public bool MissileDelayed;
        public bool MissileFollowsUnit;
        public int MissileMaxSpeed;
        public int MissileMinSpeed;
        public int MissileSpeed;
        public float MultipleAngle;
        public int RingRadius;
        public SpellSlot Slot;
        public string SpellName;
        public bool TakeClosestPath;
        public SkillshotType Type;
        private int _radius;
        private int _range;

        public SpellData()
        {
        }

        public SpellData(string championName, string spellName, SpellSlot slot, SkillshotType type, int delay, int range, int radius, int missileSpeed, bool addHitbox, bool fixedRange, int defaultDangerValue)
        {
            ChampionName = championName;
            SpellName = spellName;
            Slot = slot;
            Type = type;
            Delay = delay;
            Range = range;
            _radius = radius;
            MissileSpeed = missileSpeed;
            AddHitbox = addHitbox;
            FixedRange = fixedRange;
            DangerValue = defaultDangerValue;
        }

        public string MenuItemName
        {
            get
            {
                return this.ChampionName + " - " + this.SpellName;
            }
        }

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public int RawRadius
        {
            get
            {
                return _radius;
            }
        }

        public int RawRange
        {
            get
            {
                return _range;
            }
        }

        public int Range
        {
            get
            {
                return _range;
            }
            set
            {
                _range = value;
            }
        }

        public bool Collisionable
        {
            get
            {
                for (int index = 0; index < this.CollisionObjects.Length; ++index)
                {
                    if (this.CollisionObjects[index] == SpellData.CollisionObjectTypes.Champions || this.CollisionObjects[index] == SpellData.CollisionObjectTypes.Minion)
                        return true;
                }
                return false;
            }
        }
    }
}

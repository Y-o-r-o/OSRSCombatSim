using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;

namespace OSRSComSim.Models
{
    public class CombatCurretOptionModel : ObservableObject
    {
        public string CombatType { get; set; }
        public int StancBonusDef { get; set; }
        public int StancBonusStr { get; set; }
        public int StancBonusAtk { get; set; }
        public int StancBonusSpd { get; set; }
        public int StancBonusRng { get; set; }

        public CombatCurretOptionModel() : this("Punch", "Accurate") { }
        public CombatCurretOptionModel(string combat_style = "Punch", string attack_type = "Accurate")
        {
            setCombatType(combat_style, attack_type);
            setStancBonus(attack_type);
        }

        //Class needs redesign from here
        private void setCombatType(string combat_style, string attack_style)
        {
            switch (combat_style)
            {
                case "RangedAccurate":
                case "Rapid":
                case "RangedLongrange":
                case "Short fuse":
                case "Medium fuse":
                case "Long fuse":
                case "Flare":
                    CombatType = "Ranged";
                    break;
                case "Spell":
                case "Spell (Defensive)":
                case "MagicAccurate":
                case "MagicLongRange":
                case "Blaze":
                    CombatType = "Magic";
                    break;
                case "Chop":
                case "Hack":
                case "SlashBlock":
                case "Slash":
                case "Swipe":
                case "Reap":
                case "Flick":
                case "Lash":
                case "Deflect":
                case "Scorch":
                    CombatType = "Slash";
                    break;
                case "Smash":
                case "Pound":
                case "Pummel":
                case "CrushBlock":
                case "CrushJab":
                case "Bash":
                case "Focus":
                case "CrushFend":
                case "Kick":
                case "Punch":
                    CombatType = "Crush";
                    break;
                case "Lunge":
                case "StabJab":
                case "StabFend":
                case "Stab":
                case "Spike":
                case "Impale":
                case "StabBlock":
                    CombatType = "Stab";
                    break;
                default:
                    CombatType = "Crush"; //none
                    break;
            }
        }
        private void setStancBonus(string attack_type)
        {
            switch (attack_type)
            {
                case "Accurate":
                    StancBonusDef = 0;
                    StancBonusStr = 0;
                    StancBonusAtk = 3;
                    StancBonusSpd = 0;
                    StancBonusRng = 0;
                    break;
                case "Aggresive":
                    StancBonusDef = 0;
                    StancBonusStr = 3;
                    StancBonusAtk = 0;
                    StancBonusSpd = 0;
                    StancBonusRng = 0;
                    break;
                case "Defensive":
                    StancBonusDef = 3;
                    StancBonusStr = 0;
                    StancBonusAtk = 0;
                    StancBonusSpd = 0;
                    StancBonusRng = 0;
                    break;
                case "Controlled":
                    StancBonusDef = 1;
                    StancBonusStr = 1;
                    StancBonusAtk = 1;
                    StancBonusSpd = 0;
                    StancBonusRng = 0;
                    break;
                case "Rapid":
                    StancBonusDef = 0;
                    StancBonusStr = 0;
                    StancBonusAtk = 0;
                    StancBonusSpd = 1; //seconds
                    StancBonusRng = 0;
                    break;
                case "Longrange":
                    StancBonusDef = 0;
                    StancBonusStr = 0;
                    StancBonusAtk = 0;
                    StancBonusSpd = 0;
                    StancBonusRng = 2;
                    break;
                default:
                    StancBonusDef = 0;
                    StancBonusStr = 0;
                    StancBonusAtk = 0;
                    StancBonusSpd = 0;
                    StancBonusRng = 0;
                    break;
            }
        }
    }
}

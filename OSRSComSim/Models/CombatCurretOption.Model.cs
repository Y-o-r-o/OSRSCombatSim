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
        private int _stanc_bonus_def;
        private int _stanc_bonus_str;
        private int _stanc_bonus_atk;
        private int _stanc_bonus_spd; //speed
        private int _stanc_bonus_rng; //longrange


        private string _combat_type;
        private string _mele_atk_type;

        public string CombatType
        {
            get
            { return _combat_type; }
            set
            {
                _combat_type = value;
                OnPropertyChanged("CombatType");
            }
        }
        public string MeleAtkType
        {
            get
            { return _mele_atk_type; }
            set
            {
                _mele_atk_type = value;
                OnPropertyChanged("MeleAtkType");

            }
        }

        public int StancBonusDef
        {
            get
            { return _stanc_bonus_def; }
            set
            {
                _stanc_bonus_def = value;
                OnPropertyChanged("StancBonusDef");
            }
        }
        public int StancBonusStr
        {
            get
            { return _stanc_bonus_str; }
            set
            {
                _stanc_bonus_str = value;
                OnPropertyChanged("StancBonusStr");
            }
        }
        public int StancBonusAtk
        {
            get
            { return _stanc_bonus_atk; }
            set
            {
                _stanc_bonus_atk = value;
                OnPropertyChanged("StancBonusAtk");
            }
        }
        public int StancBonusSpd
        {
            get
            { return _stanc_bonus_spd; }
            set
            {
                _stanc_bonus_spd = value;
                OnPropertyChanged("StancBonusSpd");
            }
        } //speed
        public int StancBonusrRng
        {
            get
            { return _stanc_bonus_rng; }
            set
            {
                _stanc_bonus_rng = value;
                OnPropertyChanged("StancBonusrRng");
            }
        }

        public CombatCurretOptionModel() : this("Punch", "Accurate") { }
        public CombatCurretOptionModel(string combat_style = "Punch", string attack_type = "Accurate")
        {
            setCombatType(combat_style, attack_type);
            setStancBonus(attack_type);
        }

        private void setCombatType(string combat_style, string attack_style)
        {
            switch (combat_style)
            {
                case "RangedAccurate":
                case "Raipid":
                case "RangedLongrange":
                case "Short fuse":
                case "Medium fuse":
                case "Long fuse":
                    CombatType = "Ranged";
                    break;
                case "Spell":
                case "Spell (Defensive)":
                case "MagicAccurate":
                case "MagicLongRange":
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
                case "Spike":
                case "Impale":
                case "StabBlock":
                    CombatType = "Stab";
                    break;
                default:
                    CombatType = "Crush";
                    break;
            }
        }
        private void setStancBonus(string attack_type)
        {
            switch (attack_type)
            {
                case "Accurate":
                    _stanc_bonus_def = 0;
                    _stanc_bonus_str = 0;
                    _stanc_bonus_atk = 3;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 0;
                    break;
                case "Aggressive":
                    _stanc_bonus_def = 0;
                    _stanc_bonus_str = 3;
                    _stanc_bonus_atk = 0;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 0;
                    break;
                case "Defensive":
                    _stanc_bonus_def = 3;
                    _stanc_bonus_str = 0;
                    _stanc_bonus_atk = 0;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 0;
                    break;
                case "Controlled":
                    _stanc_bonus_def = 1;
                    _stanc_bonus_str = 1;
                    _stanc_bonus_atk = 1;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 0;
                    break;
                case "Rapid":
                    _stanc_bonus_def = 0;
                    _stanc_bonus_str = 0;
                    _stanc_bonus_atk = 0;
                    _stanc_bonus_spd = 1;
                    _stanc_bonus_rng = 0;
                    break;
                case "Longrange":
                    _stanc_bonus_def = 0;
                    _stanc_bonus_str = 0;
                    _stanc_bonus_atk = 0;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 2;
                    break;
                default:
                    _stanc_bonus_def = 0;
                    _stanc_bonus_str = 0;
                    _stanc_bonus_atk = 0;
                    _stanc_bonus_spd = 0;
                    _stanc_bonus_rng = 0;
                    break;
            }
        }
    }
}

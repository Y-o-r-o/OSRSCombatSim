using System;

namespace OSRSComSim.Models
{
    public class Combat
    {
        private string combat_type = "Mele";
        private string mele_atk_type = "Slash";

        public Skills PlayerSkills { get; set; }
        public Equiped PlayerEquipment { get; set; }


        private int stanc_bonus = 1;
        private double void_bonus = 1;

        private int piercing_lvl = 0;
        private int dmage_lvl = 0;
        private int def_lvl = 0;

        private int eq_def_bonus = 0;
        private int eq_piercing_bonus = 0;
        private int eq_dmage_bonus = 0;

        private double prayer_def_bonus = 0;
        private double prayer_piercing_bonus = 0;
        private double prayer_dmage_bonus = 0;


        private static Random rnd = new Random();

        public Combat() : this(null, null) { }
        public Combat(Skills player_skills = null, Equiped player_equipment = null)
        {
            if (player_skills != null)
                PlayerSkills = player_skills;
            else PlayerSkills = new Skills();
            if (player_equipment != null)
                PlayerEquipment = player_equipment;
            else PlayerEquipment = new Equiped();
        }

        public string Attack(int deffender_def_roll)
        {
            set_stats_for_attacker();
            
            int piercing_roll = get_piercing_roll();
            int maxdmg = get_dmagemax();

            if (deffender_def_roll > piercing_roll)
            {
                if (piercing_roll > rnd.Next(0, 2 * deffender_def_roll + 2))
                {
                    return rnd.Next((int)Math.Round((double)maxdmg / 5), maxdmg + 1).ToString();
                }
                else return "def";
            }
            else
            {
                if ((2 * piercing_roll + 2) - deffender_def_roll > rnd.Next(0, 2 * piercing_roll + 2))
                {
                    return rnd.Next((int)Math.Round((double)maxdmg / 5), maxdmg + 1).ToString();
                }
                else return "def";
            }
        }

        public int Deffend(Combat attacker_combat)
        {
            set_stats_for_deffender(attacker_combat);
            return get_def_roll();
        }

        public int get_piercing_roll()
        {
            return (int)(effective_level_piercing() * (eq_piercing_bonus + 64));
        }

        public int get_def_roll()
        {
            return (int)(effective_level_def() * (eq_def_bonus + 64));
        }

        public int get_dmagemax()
        {
            return (int)Math.Floor((0.5 + effective_level_dmage() * (eq_dmage_bonus + 64) / 640));
        }

        private double effective_level_dmage()
        {
            return Math.Floor((Math.Floor(dmage_lvl * prayer_dmage_bonus) + stanc_bonus + 8) * void_bonus);
        }

        private double effective_level_piercing()
        {
            return Math.Floor((Math.Floor(piercing_lvl * prayer_piercing_bonus) + stanc_bonus + 8) * void_bonus);
            
        }

        private double effective_level_def()
        {
            return Math.Floor((Math.Floor(def_lvl * prayer_def_bonus) + stanc_bonus + 8) * void_bonus);
        }

        private void set_stats_for_attacker()
        {
            switch (combat_type)
            {
                case "Mele":
                    switch (mele_atk_type)
                    {
                        case "Slash":
                            eq_piercing_bonus = PlayerEquipment.getTotalSlashAtk();
                            break;
                        case "Stab":
                            eq_piercing_bonus = PlayerEquipment.getTotalStabAtk();
                            break;
                        case "Crush":
                            eq_piercing_bonus = PlayerEquipment.getTotalCrushAtk();
                            break;
                        default:
                            break;
                    }
                    eq_dmage_bonus = PlayerEquipment.getTotalMeleStr();
                    prayer_piercing_bonus = 1;
                    prayer_dmage_bonus = 1;
                    dmage_lvl = PlayerSkills.Str_lvl;
                    piercing_lvl = PlayerSkills.Atk_lvl;
                    break;
                case "Magic":
                    eq_piercing_bonus = PlayerEquipment.getTotalMagicAtk();
                    eq_dmage_bonus = PlayerEquipment.getTotalMagicStr();
                    prayer_piercing_bonus = 1;
                    prayer_dmage_bonus = 1;
                    dmage_lvl = PlayerSkills.Magic_lvl;
                    piercing_lvl = PlayerSkills.Magic_lvl;
                    break;
                case "Ranged":
                    eq_piercing_bonus = PlayerEquipment.getTotalRangedAtk();
                    eq_dmage_bonus = PlayerEquipment.getTotalRangedStr();
                    prayer_piercing_bonus = 1;
                    prayer_dmage_bonus = 1;
                    dmage_lvl = PlayerSkills.Magic_lvl;
                    piercing_lvl = PlayerSkills.Magic_lvl;
                    break;
                default:
                    break;
            }
        }

        private void set_stats_for_deffender(Combat attacker_combat)
        {
            switch (attacker_combat.combat_type)
            {
                case "Mele":
                    switch (attacker_combat.mele_atk_type)
                    {
                        case "Slash":
                            eq_def_bonus = PlayerEquipment.getTotalSlashDef();
                            break;
                        case "Stab":
                            eq_def_bonus = PlayerEquipment.getTotalStabDef();
                            break;
                        case "Crush":
                            eq_def_bonus = PlayerEquipment.getTotalCrushDef();
                            break;
                        default:
                            break;
                    }
                    prayer_def_bonus = 1;
                    break;
                case "Magic":
                    eq_def_bonus = PlayerEquipment.getTotalMagicDef();
                    prayer_def_bonus = 1;
                    break;
                case "Ranged":
                    eq_def_bonus = PlayerEquipment.getTotalRangedDef();
                    prayer_def_bonus = 1;
                    break;
                default:
                    break;
            }
            def_lvl = PlayerSkills.Def_lvl;
        }

    }
}
using System;


namespace OSRSComSim.Models
{ 
    public class Combat
    {
        private string combat_type = "Mele";
        private string mele_atk_type = "Slash";

        private int atk_max = 0;
        private int atk_roll = 0;

        public Skills PlayerSkills { get; set; }
        public Equiped PlayerEquipment { get; set; }


        private int stanc_bonus = 1;
        private double void_bonus = 1;

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
            if (deffender_def_roll > atk_roll)
            {
                if (atk_roll > rnd.Next(0, 2 * deffender_def_roll + 2))
                {

                    return rnd.Next((int)Math.Round((double)atk_max / 5), atk_max + 1).ToString();
                }
                else return "def";
            }
            else
            {
                if ((2 * atk_roll + 2) - deffender_def_roll > rnd.Next(0, 2 * atk_roll + 2))
                {
                    return rnd.Next((int)Math.Round((double)atk_max / 5), atk_max + 1).ToString();
                }
                else return "def";
            }
        }

        public void set_combat()
        {
            atk_max = set_atkmax();
            atk_roll = set_atk_roll();
        }
        private int set_atk_roll()
        {
            switch (combat_type)
            {
                case "Mele":
                    switch (mele_atk_type)
                    {
                        case "Slash":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalSlashAtk() + 64));
                        case "Stab":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalStabAtk() + 64));
                        case "Crush":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalCrushAtk() + 64));
                        default:
                            return 0;
                    }
                case "Magic":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicAtk() + 64));
                case "Ranged":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicAtk() + 64));
                default:
                    return 0;
            }
        }

        public int get_def_roll(Combat attacker_combat)
        {
            switch (attacker_combat.combat_type)
            {
                case "Mele":
                    switch (attacker_combat.mele_atk_type)
                    {
                        case "Slash":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalSlashDef() + 64));
                        case "Stab":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalStabDef() + 64));
                        case "Crush":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalCrushDef() + 64));
                        default:
                            return 0;
                    }
                case "Magic":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicDef() + 64));
                case "Ranged":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicDef() + 64));
                default:
                    return 0;
            }
        }

        private int set_atkmax()
        {
            switch (combat_type)
            {
                case "Mele":
                    switch (mele_atk_type)
                    {
                        case "Slash":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalMeleStr() + 64));
                        case "Stab":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalMeleStr() + 64));
                        case "Crush":
                            return (int)(effective_level_def() * (PlayerEquipment.getTotalMeleStr() + 64));
                        default:
                            return 0;
                    }
                case "Magic":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicStr() + 64));
                case "Ranged":
                    return (int)(effective_level_def() * (PlayerEquipment.getTotalMagicStr() + 64));
                default:
                    return 0;
            }
        }

        private double effective_level_str()
        {
            switch (combat_type)
            {
                case "Mele":
                    return Math.Floor((Math.Floor(PlayerSkills.Str_lvl *    1.0/*prayer_str*/) + stanc_bonus + 8) * void_bonus);
                case "Magic":
                    return Math.Floor((Math.Floor(PlayerSkills.Magic_lvl *  1.0/*prayer_mstr*/) + stanc_bonus + 8) * void_bonus);
                case "Ranged":
                    return Math.Floor((Math.Floor(PlayerSkills.Ranged_lvl * 1.0/*prayer_rstr*/) + stanc_bonus + 8) * void_bonus);
                default:
                    return 0;
            }
        }

        private double effective_level_atk()
        {
            switch (combat_type)
            {
                case "Mele":
                    return Math.Floor((Math.Floor(PlayerSkills.Atk_lvl * 1.0/*prayer_atk*/) + stanc_bonus + 8) * void_bonus);
                case "Magic":
                    return Math.Floor((Math.Floor(PlayerSkills.Magic_lvl * 1.0/*prayer_matk*/) + stanc_bonus + 8) * void_bonus);
                case "Ranged":
                    return Math.Floor((Math.Floor(PlayerSkills.Ranged_lvl * 1.0/*prayer_ratk*/) + stanc_bonus + 8) * void_bonus);
                default:
                    return 0;
            }
        }

        private double effective_level_def()
        {
            switch (combat_type)
            {
                case "Mele":
                    return Math.Floor((Math.Floor(PlayerSkills.Def_lvl * 1.0/*prayer_def*/) + stanc_bonus + 8) * void_bonus);
                case "Magic":
                    return Math.Floor((Math.Floor(PlayerSkills.Def_lvl * 1.0/*prayer_mdef*/) + stanc_bonus + 8) * void_bonus);
                case "Ranged":
                    return Math.Floor((Math.Floor(PlayerSkills.Def_lvl * 1.0/*prayer_rdef*/) + stanc_bonus + 8) * void_bonus);
                default:
                    return 0;
            }
        }

    }
}

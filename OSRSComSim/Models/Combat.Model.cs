using System;

namespace OSRSComSim.Models
{
    public class CombatModel : ObservableObject
    {
        public CombatCurretOptionModel CurretOptions { get; set; }

        private double void_bonus = 1.10;

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

        public CombatModel() : this(null, null) { }
        public CombatModel(SkillsModel player_skills = null, EquipedModel player_equipment = null)
        {
            CurretOptions = new CombatCurretOptionModel();
        }

        //Combat functions
        public static string Attack(PlayerModel attacker, int deffender_def_roll)
        {
            CombatModel combat = attacker.Combat;
            CombatModel.set_stats_for_attacker(attacker);
            
            int piercing_roll = get_piercing_roll(combat);
            int maxdmg = get_dmagemax(combat);

            if (canAttack(attacker))
            {
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
            return "Message";
        }
        public static int Deffend(PlayerModel deffender, CombatModel attacker_combat)
        {
            set_stats_for_deffender(deffender,attacker_combat);
            return get_def_roll(deffender.Combat);
        }

        public static int get_piercing_roll(CombatModel combat)
        {
            return (int)(effective_level_piercing(combat) * (combat.eq_piercing_bonus + 64));
        }
        public static int get_def_roll(CombatModel combat)
        {
            return (int)(effective_level_def(combat) * (combat.eq_def_bonus + 64));
        }
        public static int get_dmagemax(CombatModel combat)
        {
            return (int)Math.Floor((0.5 + effective_level_dmage(combat) * (combat.eq_dmage_bonus + 64) / 640));
        }

        private static double effective_level_dmage(CombatModel combat)
        {
            return Math.Floor((Math.Floor(combat.dmage_lvl * combat.prayer_dmage_bonus) + combat.CurretOptions.StancBonusStr + 8) * combat.void_bonus);
        }
        private static double effective_level_piercing(CombatModel combat)
        {
            return Math.Floor((Math.Floor(combat.piercing_lvl * combat.prayer_piercing_bonus) + combat.CurretOptions.StancBonusAtk + 8) * combat.void_bonus);   
        }
        private static double effective_level_def(CombatModel combat)
        {
            return Math.Floor((Math.Floor(combat.def_lvl * combat.prayer_def_bonus) + combat.CurretOptions.StancBonusDef + 8) * combat.void_bonus);
        }

        private static void set_stats_for_attacker(PlayerModel attacker)
        {
            CombatModel combat = attacker.Combat;
            SkillsModel skills = attacker.Skills;
            EquipedModel eqp = attacker.Equiped;

            string value = combat.CurretOptions.CombatType;
            switch (value)
            {

                case "Slash":
                case "Stab":
                case "Crush":
                    combat.eq_piercing_bonus = eqp.getTotalSlashAtk();
                    combat.eq_piercing_bonus = eqp.getTotalStabAtk();
                    combat.eq_piercing_bonus = eqp.getTotalCrushAtk();
                    combat.eq_dmage_bonus = eqp.getTotalMeleStr();
                    combat.prayer_piercing_bonus = 1;
                    combat.prayer_dmage_bonus = 1;
                    combat.dmage_lvl = skills.Str_lvl;
                    combat.piercing_lvl = skills.Atk_lvl;
                    break;
                case "Magic":
                    combat.eq_piercing_bonus = eqp.getTotalMagicAtk();
                    combat.eq_dmage_bonus = eqp.getTotalMagicStr();
                    combat.prayer_piercing_bonus = 1;
                    combat.prayer_dmage_bonus = 1;
                    combat.dmage_lvl = skills.Magic_lvl;
                    combat.piercing_lvl = skills.Magic_lvl;
                    break;
                case "Ranged":
                    combat.eq_piercing_bonus = eqp.getTotalRangedAtk();
                    combat.eq_dmage_bonus = eqp.getTotalRangedStr();
                    combat.prayer_piercing_bonus = 1;
                    combat.prayer_dmage_bonus = 1;
                    combat.dmage_lvl = skills.Ranged_lvl;
                    combat.piercing_lvl = skills.Ranged_lvl;
                    break;
                default:
                    break;
            }
        }
        private static void set_stats_for_deffender(PlayerModel deffender, CombatModel attacker_combat)
        {
            CombatModel deffender_combat = deffender.Combat;
            EquipedModel deffender_eqp = deffender.Equiped;
            SkillsModel deffender_skills = deffender.Skills;
            
            string value = attacker_combat.CurretOptions.CombatType;
            switch (value)
            {
                case "Slash":
                case "Stab":
                case "Crush":
                    if (value.Equals("Slash")) deffender_combat.eq_def_bonus = deffender_eqp.getTotalSlashDef();
                    if (value.Equals("Stab")) deffender_combat.eq_def_bonus = deffender_eqp.getTotalStabDef();
                    if (value.Equals("Crush")) deffender_combat.eq_def_bonus = deffender_eqp.getTotalCrushDef();
                    deffender_combat.prayer_def_bonus = 1;
                    break;
                case "Magic":
                    deffender_combat.eq_def_bonus = deffender_eqp.getTotalMagicDef();
                    deffender_combat.prayer_def_bonus = 1;
                    break;
                case "Ranged":
                    deffender_combat.eq_def_bonus = deffender_eqp.getTotalRangedDef();
                    deffender_combat.prayer_def_bonus = 1;
                    break;
                default:
                    break;
            }
            deffender_combat.def_lvl = deffender_skills.Def_lvl;
        }

        private static bool canAttack(PlayerModel attacker)
        {
            CombatModel combat = attacker.Combat;
            EquipedModel eqp = attacker.Equiped;
            if (combat.CurretOptions.CombatType == "Ranged")
            {
                return EquipedModel.requedAmmoEquped(eqp);
            }
            else if (combat.CurretOptions.CombatType == "Magic")
            {
                return false;
            }
            else return true;
        }

    }
}
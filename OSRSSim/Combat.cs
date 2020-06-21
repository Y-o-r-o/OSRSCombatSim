using System;


namespace Csh_Exip
{
    public class Combat
    {
        public int atk_max = 0;
        public int atk_roll = 0;
        public int def_roll = 0;

        private double prayer_str = 1;
        private double prayer_atk = 1;
        private double prayer_def = 1;

        private double eq_mele_str_bonus = 0;
        private double eq_mele_atk_bonus = 0;
        private double eq_mele_def_bonus = 0;

        private int stanc_bonus = 1;
        private double void_bonus = 1;

        private static Random rnd = new Random();


        public int Attack(int deffender_def_roll)
        {
            if (deffender_def_roll > atk_roll)
            {
                if (atk_roll > rnd.Next(0, 2 * deffender_def_roll + 2))
                {

                    return rnd.Next((int)Math.Round((double)atk_max / 5), atk_max + 1);
                }
                else return 0;
            }
            else
            {
                if ((2 * atk_roll + 2) - deffender_def_roll > rnd.Next(0, 2 * atk_roll + 2))
                {
                    return rnd.Next((int)Math.Round((double)atk_max / 5), atk_max + 1);
                }
                else return 0;
            }
        }

        public void set_combat(int str_lvl, int atk_lvl, int def_lvl)
        {
            atk_max = set_atkmax(str_lvl);
            atk_roll = set_atk_roll(atk_lvl);
            def_roll = set_def_roll(def_lvl);
        }
        private int set_atk_roll(int atk_lvl)
        {
            return (int)(effective_level_atk(atk_lvl) * (eq_mele_atk_bonus + 64));
        }

        private int set_def_roll(int def_lvl)
        {

            return (int)(effective_level_def(def_lvl) * (eq_mele_def_bonus + 64));
        }

        private int set_atkmax(int str_lvl)
        {
            return (int)Math.Floor((0.5 + effective_level_str(str_lvl) * (eq_mele_str_bonus + 64) / 640));
        }

        private double effective_level_str(int str_lvl)
        {
            double e_lvl = Math.Floor((Math.Floor(str_lvl * prayer_str) + stanc_bonus + 8) * void_bonus);
            return e_lvl;
        }

        private double effective_level_atk(int atk_lvl)
        {
            double e_lvl = Math.Floor((Math.Round(atk_lvl * prayer_atk) + stanc_bonus + 8) * void_bonus);
            return e_lvl;
        }

        private double effective_level_def(int def_lvl)
        {
            double e_lvl = Math.Floor((Math.Round(def_lvl * prayer_def) + stanc_bonus + 8) * void_bonus);
            return e_lvl;
        }

    }
}

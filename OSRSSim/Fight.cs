using System;
using System.Collections.Generic;
using System.Text;

namespace Csh_Exip
{
    static class Fight
    {
        
        public static void StartFight(Players fighter_1,
            Players fighter_2)
        {

            while (true)
            {
                if (GetAttackResult(fighter_1, fighter_2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
               Console.WriteLine("{0} HP {1}, {2} HP {3}", fighter_1.name, fighter_1.hp_lvl, fighter_2.name, fighter_2.hp_lvl);

                if (GetAttackResult(fighter_2, fighter_1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                Console.WriteLine("{0} HP {1}, {2} HP {3}", fighter_1.name, fighter_1.hp_lvl, fighter_2.name, fighter_2.hp_lvl);

            }
        }

        public static string GetAttackResult(Players attacker,
            Players deffender)
        {
            int fig_1_atk_amt = attacker.combat.Attack(deffender.combat.def_roll);

            deffender.hp_lvl = deffender.hp_lvl - fig_1_atk_amt;

            if (deffender.hp_lvl <= 0)
            {
                Console.WriteLine("{0} has Died and {1} is Victorious", deffender.name, attacker.name);

                return "Game Over";
            }
            else return "Fight Again";
        }

    }
}

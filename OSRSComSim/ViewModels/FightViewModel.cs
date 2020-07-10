using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRSComSim
{
    class FightViewModel: ObservableObject
    {
        private string _fight_log;

        public string FightLog
        {
            get { return _fight_log; }
            set 
            {
                _fight_log = value;
                OnPropertyChanged("FightLog");
            }
        }

        public FightViewModel()
        {
            _fight_log = "";
        }
        
        public void StartFight(Players fighter_1,
            Players fighter_2)
        {

            while (true)
            {
                if (GetAttackResult(fighter_1, fighter_2) == "Game Over")
                {
                    _fight_log += "\nGame Over\n";
                    break;
                }
               _fight_log += "\n{0} HP {1}, {2} HP {3}"+ fighter_1.name+ fighter_1.hp_lvl+ fighter_2.name+ fighter_2.hp_lvl+"\n";

                if (GetAttackResult(fighter_2, fighter_1) == "Game Over")
                {
                   _fight_log += "\nGame Over\n";
                    break;
                }
                _fight_log += "\n{0} HP {1}, {2} HP {3}" + fighter_1.name + fighter_1.hp_lvl + fighter_2.name + fighter_2.hp_lvl + "\n";

            }
        }

        public string GetAttackResult(Players attacker,
            Players deffender)
        {
            int fig_1_atk_amt = attacker.combat.Attack(deffender.combat.def_roll);

            deffender.hp_lvl = deffender.hp_lvl - fig_1_atk_amt;

            if (deffender.hp_lvl <= 0)
            {
                _fight_log += "\n{0} has Died and {1} is Victorious" + deffender.name + attacker.name+"\n";

                return "Game Over";
            }
            else return "Fight Again";
        }

    }
}

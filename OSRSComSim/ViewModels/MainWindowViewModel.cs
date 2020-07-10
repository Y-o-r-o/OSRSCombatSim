using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private object _viewcontent;

        private Players _fighter1;
        private Players _fighter2;

        private string _fighter1name;
        private string _fighter2name;

        public string Fighter1Name 
        {
            get { return _fighter1name; }
            set 
            {
                _fighter1name = value;
                OnPropertyChanged("Fighter1Name");
            } 
        }
        public string Fighter2Name
        {
            get { return _fighter2name; }
            set
            {
                _fighter2name = value;
                OnPropertyChanged("Fighter2Name");
            }
        }
        public object ViewContent
        {
            get
            {
                return _viewcontent;
            }
            set 
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }
        public Players Fighter1
        {
            get { return _fighter1; }
            set
            {
                _fighter1 = value;
                Fighter1Name = ((Players)value).name;
                OnPropertyChanged("Fighter1");
            }
        }
        public Players Fighter2
        {
            get { return _fighter2; }
            set
            {
                _fighter2 = value;
                Fighter2Name = ((Players)value).name;
                OnPropertyChanged("Fighter1");
            }
        }



        public MainWindowViewModel()
        {
            _fighter1name = "No player selected";
            _fighter2name = "No player selected";
            _fight_log = "Waiting to fight....";
        }


        public void viewLoadScreen(string fighter_num)
        {
            ViewContent = new LoadScreenView(this, fighter_num);
        }

        public void stopView()
        {
            ViewContent = null;
        }





        //exp

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

        public void StartFight()
        {

            while (true)
            {
                if (GetAttackResult(_fighter1,_fighter2) == "Game Over")
                {
                    FightLog += "\nGame Over\n";
                    break;
                }
                FightLog += "\n" + _fighter1.name + " HP" + _fighter1.hp_lvl + ", " + _fighter2.name + " HP" + _fighter2.hp_lvl + "\n";

                if (GetAttackResult(_fighter2, _fighter1) == "Game Over")
                {
                    FightLog += "\nGame Over\n";
                    break;
                }
                FightLog += "\n" + _fighter1.name + " HP" + _fighter1.hp_lvl + ", " + _fighter2.name + " HP" + _fighter2.hp_lvl + "\n";

            }
        }

        private string GetAttackResult(Players attacker, Players deffender)
        {
            int fig_1_atk_amt = attacker.combat.Attack(deffender.combat.def_roll);

            deffender.hp_lvl = deffender.hp_lvl - fig_1_atk_amt;

            if (deffender.hp_lvl <= 0)
            {
                FightLog += "\n" + deffender.name + " has Died and " + attacker.name + " is Victorious\n";

                return "Game Over";
            }
            else return "Fight Again";
        }

    }
}

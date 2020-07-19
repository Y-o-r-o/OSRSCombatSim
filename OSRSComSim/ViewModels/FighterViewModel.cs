using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class FighterViewModel : ObservableObject
    {
        private const int status_show_time = 1000;

        private int _health_taken;
        private string _last_atk_stat_context;
        private string _last_atk_stat_color;

        private Players _player;

        public Players Player
        {
            get { return _player; }
            set
            {
                _player = value;
                OnPropertyChanged("Player");
            }
        }
        public string LastAtkStatColor
        {
            get { return _last_atk_stat_color; }
            set
            {
                _last_atk_stat_color = value;

                OnPropertyChanged("LastAtkStatColor");
            }
        }
        public string LastAtkStatContext
        {
            get { return _last_atk_stat_context; }
            set
            {
                _last_atk_stat_context = value;

                OnPropertyChanged("LastAtkStatContext");
            }
        }
        public int HealthTaken
        {
            get { return _health_taken; }
            set
            {
                _health_taken = value;

                OnPropertyChanged("HealthTaken");
            }
        }

        public FighterViewModel()
        {
            Player = new Players();
        }

        public string getAttackRessult(FighterViewModel deffender)
        {
            return Player.combat.Attack(deffender.Player.combat.def_roll);
        }
        
        public void takeDamage(string attack_res)
        {
            if (attack_res != "def")
            {
                LastAtkStatColor = "Red";
                LastAtkStatContext = attack_res.ToString();
                HealthTaken += (int)Math.Round((double.Parse(attack_res) / Player.Hp_lvl) * 100);
            }
            else
            {
                LastAtkStatColor = "Blue";
                LastAtkStatContext = "0";
            }
            Thread.Sleep(status_show_time);
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";
        }

        public bool isDead()
        {
            return HealthTaken >= 100;
        }

        public void Reset()
        {
            HealthTaken = 0;
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";

        }

    }
}

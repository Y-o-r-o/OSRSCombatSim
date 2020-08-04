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

        private Combat _fcombat;
        private string _name;
        private string _last_atk_stat_context;
        private string _last_atk_stat_color;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public Combat FighterCombat
        {
            get { return _fcombat; }
            set
            {
                _fcombat = value;
                OnPropertyChanged("FighterCombat");
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

        public FighterViewModel(Player selectedplayer = null)
        {
            if (selectedplayer == null) selectedplayer = new Player();
            Name = selectedplayer.Name;
            FighterCombat = selectedplayer.PlayerCombat;
            setupFighter();
        }
        private void setupFighter()
        {
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";
        }


        public string getAttackRessult(FighterViewModel deffender)
        {
            int deffender_def_roll = deffender.FighterCombat.Deffend(FighterCombat);
            return FighterCombat.Attack(deffender_def_roll);
        }

        public void takeDamage(string attack_res)
        {
            if (attack_res != "def")
            {
                HealthTaken += (int)Math.Round((double.Parse(attack_res) / FighterCombat.PlayerSkills.Hp_lvl) * 100);
                LastAtkStatColor = "Red";
                LastAtkStatContext = attack_res.ToString();
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

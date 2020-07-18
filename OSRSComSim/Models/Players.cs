using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Players: ObservableObject
    {
        private int _health_taken;
        private string _last_atk_stat_context;
        private string _last_atk_stat_color;


        public string Name { get; set; }
        public int Hp_lvl { get; set; }
        public int Def_lvl { get; set; }
        public int Str_lvl { get; set; }
        public int Atk_lvl { get; set; }

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

        public int HealthTaken { 
            get { return _health_taken; }
            set 
            {
                _health_taken = value;

                OnPropertyChanged("HealthTaken");
            } 
        }



        public Combat combat = new Combat();
        public Players() : this("No_name", 10, 1, 1, 1) { }
        public Players(string name = "No_name", int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1)
        {
            this.Name = name;
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
            
            this._health_taken = 0;
        
            combat.set_combat(str_lvl, atk_lvl, def_lvl);
        }

        public void Reset ()
        {
            HealthTaken = 0;
            LastAtkStatColor = "Transparent";
            LastAtkStatContext = "";

        }





    }
}

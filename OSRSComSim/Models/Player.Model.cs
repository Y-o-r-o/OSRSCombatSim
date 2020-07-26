using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Player: ObservableObject
    {
        private string _name;
        private int _hplvl;
        private int _deflvl;
        private int _strlvl;
        private int _atklvl;

        public string Name 
        {
            get 
            { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Hp_lvl
        {
            get
            { return _hplvl; }
            set
            {
                _hplvl = value;
                OnPropertyChanged("Hp_lvl");
            }
        }
        public int Def_lvl
        {
            get
            { return _deflvl; }
            set
            {
                _deflvl = value;
                OnPropertyChanged("Def_lvl");
            }
        }
        public int Str_lvl
        {
            get
            { return _strlvl; }
            set
            {
                _strlvl = value;
                OnPropertyChanged("Str_lvl");
            }
        }
        public int Atk_lvl
        {
            get
            { return _atklvl; }
            set
            {
                _atklvl = value;
                OnPropertyChanged("Atk_lvl");
            }
        }


        public Combat combat = new Combat();
        public Player() : this("Default character", 10, 1, 1, 1) { }
        public Player(string name = "Default character", int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1)
        {
            this.Name = name;
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
                    
            combat.set_combat(str_lvl, atk_lvl, def_lvl);
        }

       




    }
}

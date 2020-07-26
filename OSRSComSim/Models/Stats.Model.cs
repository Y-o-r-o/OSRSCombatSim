using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.Models
{
    public class Stats: ObservableObject
    {
        private int _hplvl;
        private int _deflvl;
        private int _strlvl;
        private int _atklvl;

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

        public Stats() : this(10, 1, 1, 1) { }
        public Stats(int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1)
        {
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
        }




    }
}

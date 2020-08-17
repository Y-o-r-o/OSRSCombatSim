namespace OSRSComSim.Models
{
    public class Skills: ObservableObject
    {
        private int _hplvl;
        private int _deflvl;
        private int _strlvl;
        private int _atklvl;
        private int _magiclvl;
        private int _rangedlvl;
        private int _prayerlvl;

        public int Hp_lvl
        {
            get
            { return _hplvl; }
            set
            {
                if (value >= 10 && value < 100)
                {
                    _hplvl = value;
                    OnPropertyChanged("Hp_lvl");
                }
            }
        }
        public int Def_lvl
        {
            get
            { return _deflvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _deflvl = value;
                    OnPropertyChanged("Def_lvl");
                }
            }
        }
        public int Str_lvl
        {
            get
            { return _strlvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _strlvl = value;
                    OnPropertyChanged("Str_lvl");
                }
            }
        }
        public int Atk_lvl
        {
            get
            { return _atklvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _atklvl = value;
                    OnPropertyChanged("Atk_lvl");
                }
            }
        }
        public int Magic_lvl
        {
            get
            { return _magiclvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _magiclvl = value;
                    OnPropertyChanged("Magic_lvl");
                }
            }
        }
        public int Ranged_lvl
        {
            get
            { return _rangedlvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _rangedlvl = value;
                    OnPropertyChanged("Ranged_lvl");
                }
            }
        }
        public int Prayer_lvl
        {
            get
            { return _prayerlvl; }
            set
            {
                if (value >= 1 && value < 100)
                {
                    _prayerlvl = value;
                    OnPropertyChanged("Prayer_lvl");
                }
            }
        }

        public Skills() : this(10, 1, 1, 1, 1 , 1, 1) { }
        public Skills(int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1,int magic_lvl = 1, int ranged_lvl = 1, int prayer_lvl = 1)
        {
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
            this.Magic_lvl = magic_lvl;
            this.Ranged_lvl = ranged_lvl;
            this.Prayer_lvl = prayer_lvl;

        }

    }
}

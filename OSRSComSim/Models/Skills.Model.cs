using System;

namespace OSRSComSim.Models
{
    public class SkillsModel : ObservableObject
    {
        private int _hplvl;
        private int _deflvl;
        private int _strlvl;
        private int _atklvl;
        private int _magiclvl;
        private int _rangedlvl;
        private int _prayerlvl;
        private int _total_combat_lvl;

        public StatusModel Status { get; set; }
        public int Hp_lvl
        {
            get
            { return _hplvl; }
            set
            {
                if (value >= 10 && value < 100)
                {
                    _hplvl = value;
                    Status = new StatusModel(_hplvl);
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
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
                    setTotalCombatLevel();
                    OnPropertyChanged("Prayer_lvl");
                }
            }
        }
        public int TotalCombat_lvl 
        {
            get { return _total_combat_lvl; }
            set
            {
                _total_combat_lvl = value;
                OnPropertyChanged("TotalCombat_lvl");
            }
        }


        public SkillsModel() : this(10, 1, 1, 1, 1 , 1, 1) { }
        public SkillsModel(int hp_lvl = 10, int def_lvl = 1, int str_lvl = 1, int atk_lvl = 1,int magic_lvl = 1, int ranged_lvl = 1, int prayer_lvl = 1)
        {
            Status = new StatusModel(hp_lvl);
            this.Def_lvl = def_lvl;
            this.Hp_lvl = hp_lvl;
            this.Str_lvl = str_lvl;
            this.Atk_lvl = atk_lvl;
            this.Magic_lvl = magic_lvl;
            this.Ranged_lvl = ranged_lvl;
            this.Prayer_lvl = prayer_lvl;
        }
        private void setTotalCombatLevel()
        {
            double t_base = (double)1 / 4 * (Def_lvl + Hp_lvl + (Prayer_lvl * (double)1 / 2));

            double t_mele  = ((double)13/40) * (Atk_lvl + Str_lvl);
            double t_ranged = ((double)13 / 40) * (Ranged_lvl * (double)1.5);
            double t_magic = ((double)13 / 40) * (Magic_lvl * (double)1.5);

            if (t_mele >= t_ranged && t_mele >= t_magic) 
            {
                TotalCombat_lvl = Convert.ToInt32(Math.Floor(t_base + t_mele)); 
            }
            else if (t_ranged >= t_magic)
            {
                TotalCombat_lvl = Convert.ToInt32(Math.Floor(t_base + t_ranged));
            }
            else TotalCombat_lvl = Convert.ToInt32(Math.Floor(t_base + t_magic));
        }
    }
}

using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    class CreatePlayerViewModel: ObservableObject
    {
        private string _name = "No_name";
        private int _hplvl = 10;
        private int _deflvl = 1;
        private int _strlvl = 1;
        private int _atklvl = 1;

        private LoadScreenViewModel _loadscreenviewmodel;

        public CreatePlayerViewModel(LoadScreenViewModel loadscreenviewmodel)
        {
            _loadscreenviewmodel = loadscreenviewmodel;
        }
        
        public string Name 
        {
            get { return _name; }
            set
            {
                if (value.Length > 20) _name = "No_name";
                else if (value.Length < 6) _name = "No_name";
                else _name = value;
            }
        }

        public int HPLvl
        {
            get { return _hplvl; }
            set
            {
                if (value < 10) _hplvl = 10;
                else if (value > 99) _hplvl = 99;
                else _hplvl = value;
                OnPropertyChanged("HpLvl");
                
            }
        }
        public int DefLvl 
        {
            get { return _deflvl; }
            set
            {
                if (value < 1) _deflvl = 1;
                else if (value > 99) _deflvl = 99;
                else _deflvl = value;
                OnPropertyChanged("DefLvl");
            }
        }
        public int StrLvl 
        {
            get { return _strlvl; }
            set
            {
                if (value < 1) _strlvl = 1;
                else if (value > 99) _strlvl = 99;
                else _strlvl = value;
                OnPropertyChanged("StrLvl");

            }
        }
        public int AtkLvl {
            get { return _atklvl; }
            set
            {
                if (value < 1) _atklvl = 1;
                else if (value > 99) _atklvl = 99;
                else _atklvl = value;
                OnPropertyChanged("AtkLvl");

            }
        }




        public void backToLoadScreen()
        {
            _loadscreenviewmodel.stopView();
        }
        public void Create()
        {
            if (_name != "No_name")
            {
                Players player = new Players
                {
                    name = _name,
                    hp_lvl = _hplvl,
                    def_lvl = _deflvl,
                    str_lvl = _strlvl,
                    atk_lvl = _atklvl
                };
                Data_store.SavePlayer(player);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.stopView();
            }
        }








    }
}

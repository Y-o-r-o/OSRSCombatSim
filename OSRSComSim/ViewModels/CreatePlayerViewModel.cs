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

        private string _setnamequotes;
        private int _selected_index;

        private LoadScreenViewModel _loadscreenviewmodel;

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

        public string SetNameQuotes 
        { 
            get
            {
                return _setnamequotes;
            }
            set 
            {
                _setnamequotes = value;
                OnPropertyChanged("SetNameQuotes");
            }

        }
        public int SelectedIndex
        { 
         get
            {
                return _selected_index;
            }
        set
            {
                if(value >= 0 && value < 4)
                {
                    _selected_index = value;
                }
                OnPropertyChanged("SelectedIndex");
            }
        }

        public CreatePlayerViewModel(LoadScreenViewModel loadscreenviewmodel)
        {
            _loadscreenviewmodel = loadscreenviewmodel;
            _setnamequotes = "Enter player name here.";
            _selected_index = 0;
        }
        


        public void resetPlayerStats()
        {
            HPLvl = 10;
            DefLvl = 1;
            StrLvl = 1;
            AtkLvl = 1;
        }
        public void setRandomPlayerStats()
        {
            Random rnd = new Random();
            HPLvl = rnd.Next(10, 100);
            DefLvl = rnd.Next(1, 100);
            StrLvl = rnd.Next(1, 100);
            AtkLvl = rnd.Next(1, 100);
        }
        public void setPlayerName(string boxtext)
        {

            if (!HasNoSpecialChars(boxtext))
            {
                SetNameQuotes = "Dont use special chars.";
            }
            else if (Data_store.CheckIfPlayerExists(boxtext))
            {
                SetNameQuotes = "Player with this name already exists.";
            }
            else if (boxtext.Length > 20 || boxtext.Length < 6)
            {
                SetNameQuotes = "Player name length must bet betwee 6 and 20.";
            }
            else 
            {
                Name = boxtext;
                SetNameQuotes = "Name set!";
                SelectedIndex = 1;
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
                (
                    name: _name,
                    hp_lvl: _hplvl,
                    def_lvl: _deflvl,
                    str_lvl: _strlvl,
                    atk_lvl: _atklvl
                );
                Data_store.SavePlayer(player);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.stopView();
            }
        }
        public bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }








    }
}

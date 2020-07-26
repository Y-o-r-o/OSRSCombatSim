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
        private string _name;
        private int _hplvl;
        private int _deflvl;
        private int _strlvl;
        private int _atklvl;

        private string _setnamequotes;
        private int _selected_index;

        private LoadScreenViewModel _loadscreenviewmodel;

        public Stats PlayerStats { get; set; }
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

        public CreatePlayerViewModel(LoadScreenViewModel loadscreenviewmodel, string name = "No_name", Stats player_stats = null)
        {
            _loadscreenviewmodel = loadscreenviewmodel;
            
            Name = name;
            if (player_stats != null)
                PlayerStats = player_stats;
            else PlayerStats = new Stats();

            setupCreatePlayerVM();
        }
        
        public void setupCreatePlayerVM()
        {
            _setnamequotes = "Enter player name here.";
            _selected_index = 0;
        }

        public void resetPlayerStats()
        {
            PlayerStats = new Stats();
        }
        public void setRandomPlayerStats()
        {
            Random rnd = new Random();
            PlayerStats.Hp_lvl = rnd.Next(10, 100);
            PlayerStats.Def_lvl = rnd.Next(1, 100);
            PlayerStats.Str_lvl = rnd.Next(1, 100);
            PlayerStats.Atk_lvl = rnd.Next(1, 100);
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
            if (_name != "Default character")
            {
                Player player = new Player
                (
                    name: _name,
                    player_stats: PlayerStats
                );
                Data_store.DeletePlayer(player.Name);
                Data_store.SavePlayer(player);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.SelectedPlayer = player;
                _loadscreenviewmodel.stopView();
            }
        }
        public bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }

    }
}

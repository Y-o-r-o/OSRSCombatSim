using OSRSComSim.Models;
using OSRSComSim.Views;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSRSComSim.ViewModels
{
   public class LoadScreenViewModel: ObservableObject
    {
        private string _fighter_num;

        public object               _viewcontent;
        
        private MainWindowViewModel _mainwindowVM;
        private string              _selected_player;

        private ObservableCollection<Players> _player_list;


        public ObservableCollection<Players> PlayerList 
        {
            get
            {
                return _player_list;
            }
            private set
            {
                _player_list = value;
                OnPropertyChanged("PlayerList");
            }
        }
        public object ViewContent
        {
            get
            {
                return _viewcontent;
            }
            set
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }
        public string SelectedPlayer
        {
            get 
            {
                return _selected_player;
            }
            set
            {
                _selected_player = value;
                OnPropertyChanged("SelectedPlayer");
            }
        }




        public LoadScreenViewModel(MainWindowViewModel mainWindowVM, string fighter_num)
        {
            _mainwindowVM = mainWindowVM;
            _player_list = new ObservableCollection<Players>();
            _selected_player = "No player selected.";
            _fighter_num = fighter_num;
            Load_players();
        }







        public void Back_to_main_screen()
        {
            _mainwindowVM.stopView();
        }
        public void viewCreatePlayer()
        {
            ViewContent = new CreatePlayerView(this);
        }
        public void stopView()
        {
            ViewContent = null;
        }
        public void outline_button(Button btn)
        {

        }
        public void delete_player(string name) {
            Data_store.DeletePlayer(name);
            Load_players();
            SelectedPlayer = "No player selected.";
        }
        public void loadSelectedFighter(string fighter_name)
        {
            if (HasNoSpecialChars(SelectedPlayer))
            {
                if (_fighter_num == "fighter 1")
                {
                    _mainwindowVM.Fighter1 = getPlayer(fighter_name);
                }
                else if (_fighter_num == "fighter 2")
                {
                    _mainwindowVM.Fighter2 = getPlayer(fighter_name);
                }
                Back_to_main_screen();
            }
            else SelectedPlayer = "No player selected!";
        }

        public bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }


        private Players getPlayer(string fighter_name) {
            foreach(Players player in PlayerList)
            {
                if (player.name == fighter_name)
                {
                    return player;
                }

            }
            return null;
        }
        public void Load_players()
        {
            PlayerList.Clear();
            Data_store.LoadPlayers(PlayerList);
            PlayerList = PlayerList;
        }

    }
}

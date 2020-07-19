﻿using OSRSComSim.Models;
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
        private string                          _fighter_num;

        public object                           _viewcontent;
        
        private MainWindowViewModel             _mainwindowVM;
        private Players                         _selected_player;

        private ObservableCollection<Players>   _player_list;


        public ObservableCollection<Players>    PlayerList 
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
        public object                           ViewContent
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
        public Players                          SelectedPlayer
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
            _selected_player = new Players();
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
        public void viewrEditPlayer()
        {
            ViewContent = new CreatePlayerView(this, SelectedPlayer.Name, SelectedPlayer.Hp_lvl, SelectedPlayer.Def_lvl, SelectedPlayer.Str_lvl, SelectedPlayer.Atk_lvl);
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
            SelectedPlayer = new Players();
        }
        public void loadSelectedFighter(string fighter_num)
        {
            if (HasNoSpecialChars(SelectedPlayer.Name))
            {
                loadFighter(fighter_num);
                Back_to_main_screen();
            }
        }

        public bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }

        public void getPlayer(string fighter_num) {
            foreach(Players player in PlayerList)
            {
                if (player.Name == fighter_num)
                {
                    SelectedPlayer = player;
                }
            }
        }
        public void Load_players()
        {
            PlayerList.Clear();
            Data_store.LoadPlayers(PlayerList);
            PlayerList = PlayerList;
        }
        private void loadFighter(string fighter_num)
        {
            if (_fighter_num == "fighter 1")
            {
                _mainwindowVM.Battle.Fighter1.Player = SelectedPlayer;
            }
            else if (_fighter_num == "fighter 2")
            {
                _mainwindowVM.Battle.Fighter2.Player = SelectedPlayer;
            }
        }
    }
}

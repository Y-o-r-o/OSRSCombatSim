﻿using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
namespace OSRSComSim.ViewModels
{
    public class LoadScreenViewModel : ObservableObject
    {
        private string _fighter_num;
        public object _viewcontent;
        private PlayerModel _selected_player;
        private ControlPanelViewModel _controls_view;
        private MainWindowViewModel _mainwindowVM;
        private ObservableCollection<PlayerModel> _player_list;

        public object View { get; set; }
        public PlayerModel SelectedPlayer
        {
            get { return _selected_player; }
            set 
            {
                _selected_player = value;
                OnPropertyChanged("SelectedPlayer");
            }
        }

        public ControlPanelViewModel ControlsView
        {
            get
            {
                return _controls_view;
            }
            set
            {
                _controls_view = value;
                OnPropertyChanged("ControlsView");
            }
        }
        public ObservableCollection<PlayerModel> PlayerList
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
            private set
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }

        public LoadScreenViewModel() : this(null, null) { }
        public LoadScreenViewModel(MainWindowViewModel mainWindowVM = null, string fighter_num = null)
        {
            _mainwindowVM = mainWindowVM;
            _player_list = new ObservableCollection<PlayerModel>();
            SelectedPlayer = new PlayerModel();
            _fighter_num = fighter_num;
            ControlsView = new ControlPanelViewModel(this, SelectedPlayer, "View");
            Load_players();

            View = new LoadScreenView(this);
        }

        public void Back_to_main_screen()
        {
            _mainwindowVM.stopView();
        }
        public void viewCreatePlayer()
        {
            ViewContent = new ControlPanelViewModel(this, cp_mode: "Create").View;
        }
        public void viewEditPlayer()
        {
            ViewContent = new ControlPanelViewModel(this, SelectedPlayer, "Edit").View;
        }
        public void stopView()
        {
            ViewContent = null;
        }
        public void delete_player(string name)
        {
            Data_store.DeletePlayer(name);
            Load_players();
            SelectedPlayer = new PlayerModel();
        }
        public void loadSelectedFighter(string fighter_num)
        {
            loadFighter(fighter_num);
            Back_to_main_screen();
        }
        public void getPlayer(string fighter_num)
        {
            foreach (PlayerModel player in PlayerList)
            {
                if (player.Name == fighter_num)
                {
                    SelectedPlayer = player;
                    ControlsView.SelectedPlayer = SelectedPlayer;
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
                _mainwindowVM.Battle.Fighter1 = new FighterViewModel(SelectedPlayer);
            }
            else if (_fighter_num == "fighter 2")
            {
                _mainwindowVM.Battle.Fighter2 = new FighterViewModel(SelectedPlayer);
            }
        }
    }
}

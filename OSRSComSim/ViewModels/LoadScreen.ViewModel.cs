using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
namespace OSRSComSim.ViewModels
{
    public class LoadScreenViewModel : ObservableObject
    {
        private string fighter_num;
        public object _viewcontent;
        private StartAppViewModel _mainwindowVM;

        public object View { get; set; }
        public PlayerModel SelectedPlayer { get; set; }

        public ControlPanelViewModel ControlsView { get; set; }
        public ObservableCollection<PlayerModel> PlayerList { get; set; }
        public object ViewContent { get; set; }

        public LoadScreenViewModel() : this(null, null) { }
        public LoadScreenViewModel(StartAppViewModel mainWindowVM = null, string fighter_num = null)
        {
            _mainwindowVM = mainWindowVM;
            PlayerList = new ObservableCollection<PlayerModel>();
            SelectedPlayer = new PlayerModel();
            this.fighter_num = fighter_num;
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
        public void loadSelectedFighter()
        {
            loadFighter();
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
                    ControlsView.run("inventory");
                }
            }
        }
        public void Load_players()
        {
            PlayerList.Clear();
            Data_store.LoadPlayers(PlayerList);
            PlayerList = PlayerList;
        }

        private void loadFighter()
        {
            if (fighter_num == "fighter 1")
            {
                _mainwindowVM.Battle.Fighter1 = new FighterViewModel(SelectedPlayer);
            }
            else if (fighter_num == "fighter 2")
            {
                _mainwindowVM.Battle.Fighter2 = new FighterViewModel(SelectedPlayer);
            }
        }
    }
}

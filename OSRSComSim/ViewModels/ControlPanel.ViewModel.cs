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

namespace OSRSComSim.ViewModels
{
    public class ControlPanelViewModel : ObservableObject
    {
        private string view_mode;
        private bool cant_edit;

        private Player _player;
        private object _viewcontent;
        public object _tabs_background;
        private string _create_mode_tabs_visibility = "Collapsed";
        private string _interactive_mode_tabs_visibility = "Collapsed";
        private LoadScreenViewModel _loadscreenviewmodel;

        public ControlPanelView View { get; set; }
        public Player SelectedPlayer 
        {
            get { return _player; }
            set 
            {
                _player = value;
                OnPropertyChanged("SelectedPlayer");
                setViewMode(view_mode);
            }
        }
        public object TabsBackground
        {
            get { return _tabs_background; }
            set
            {
                _tabs_background = value;
                OnPropertyChanged("TabsBackground");
            }
        }
        public object ViewContent
        {
            get { return _viewcontent; }
            set
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }
        public string CreateModeTabsVisibility
        {
            get { return _create_mode_tabs_visibility;  }
            set
            {
                TabsBackground = new Thickness(0, 0, 0, 0);
                _create_mode_tabs_visibility = value;
                OnPropertyChanged("CreateModeTabsVisibility");
            }
        }
        public string InteractiveModeTabsVisibility
        {
            get { return _interactive_mode_tabs_visibility; }
            set
            {
                TabsBackground = new Thickness(0, 35, 0, 0);
                _interactive_mode_tabs_visibility = value;
                OnPropertyChanged("InteractiveModeTabsVisibility");
            }
        }



        public ControlPanelViewModel() : this(null, null, null) { }
        public ControlPanelViewModel(LoadScreenViewModel loadscreenviewmodel = null, Player player = null, string cp_mode = null) // Create, View, Interactive.
        {
            _loadscreenviewmodel = loadscreenviewmodel;

            if (player != null)
                SelectedPlayer = player;
            else SelectedPlayer = new Player();

            setMode(cp_mode);
            View = new ControlPanelView(this);
        }

        private void setMode(string cp_mode)
        {
            cant_edit = true;
            if (cp_mode == "Create")
            {
                CreateModeTabsVisibility = "Visible";
                cant_edit = false;
                setViewMode("Appearance");
            }
            else if (cp_mode == "Interactive")
            {
                InteractiveModeTabsVisibility = "Visible";
                setViewMode("Skills");
            }
        }

        public void setViewMode(string view_mode)
        {
            this.view_mode = view_mode;
            switch (view_mode)
            {
                case "Appearance":
                    ViewContent = new AppearanceViewModel(SelectedPlayer).View;
                    break;
                case "Combat":
                    ViewContent = new CombatOptionsViewModel(SelectedPlayer.PlayerCombat).View;
                    break;
                case "Skills":
                    ViewContent = new SkillsViewModel(SelectedPlayer.PlayerCombat.PlayerSkills, cant_edit).View;
                    break;
                case "Inventory":
                    break;
                case "Armor":
                    ViewContent = new WornEquipmentViewModel(SelectedPlayer.PlayerCombat.PlayerEquipment, cant_edit).View;
                    break;
                case "Prayer":
                    break;
                case "Magic":
                    break;

            }
        }

        public void backToLoadScreen()
        {
            _loadscreenviewmodel.stopView();
        }
        public void Create()
        {

            if (SelectedPlayer.Name != "Default character")
            {
                Data_store.DeletePlayer(SelectedPlayer.Name);
                Data_store.SavePlayer(SelectedPlayer);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.SelectedPlayer = SelectedPlayer;
                _loadscreenviewmodel.stopView();
            }
        }


    }
}

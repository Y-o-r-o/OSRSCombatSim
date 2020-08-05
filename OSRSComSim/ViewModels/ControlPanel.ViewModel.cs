using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    class ControlPanelViewModel : ObservableObject
    {
        private object _viewcontent;
        private string _create_mode_tabs_visibility = "Collapsed";
        private string _interactive_mode_tabs_visibility = "Collapsed";

        private LoadScreenViewModel _loadscreenviewmodel;
        private EquipmentSlotsView equipmentslotsview;
        private SkillsView skillsview;
        private AppearanceView appearanceview;

        public Player SelectedPlayer { get; set; }


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
                _create_mode_tabs_visibility = value;
                OnPropertyChanged("CreateModeTabsVisibility");
            }
        }
        public string InteractiveModeTabsVisibility
        {
            get { return _interactive_mode_tabs_visibility; }
            set
            {
                _interactive_mode_tabs_visibility = value;
                OnPropertyChanged("InteractiveModeTabsVisibility");
            }
        }



        public ControlPanelViewModel() : this(null, null, null) { }
        public ControlPanelViewModel(LoadScreenViewModel loadscreenviewmodel, Player player, string cp_mode) // Create, View, Interactive.
        {
            _loadscreenviewmodel = loadscreenviewmodel;
            
            if (player != null)
                SelectedPlayer = player;
            else SelectedPlayer = new Player();

            setMode(cp_mode);

        }
        
        private void setMode(string cp_mode)
        {
            bool view_mode = false;
            switch (cp_mode)
            {
                case "Create":
                    CreateModeTabsVisibility = "Visible";
                    appearanceview = new AppearanceView(SelectedPlayer);
                    break;
                case "View":
                    view_mode = true;
                    break;
                case "Interactive":
                    view_mode = true;
                    InteractiveModeTabsVisibility = "Visible";
                    break;
            }
            skillsview = new SkillsView(SelectedPlayer.PlayerCombat.PlayerSkills, view_mode);
            equipmentslotsview = new EquipmentSlotsView(SelectedPlayer.PlayerCombat.PlayerEquipment, view_mode);

            if (cp_mode != "Create")
                ViewContent = skillsview;
            else ViewContent = appearanceview;
        }

        public void setViewMode(string view_mode)
        {
            switch (view_mode)
            {
                case "Appearance":
                    ViewContent = appearanceview;
                    break;
                case "Combat":
                    break;
                case "Skills":
                    ViewContent = skillsview;
                    break;
                case "Inventory":
                    break;
                case "Armor":
                    ViewContent = equipmentslotsview;
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

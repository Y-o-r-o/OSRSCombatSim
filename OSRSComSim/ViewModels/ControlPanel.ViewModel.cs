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
        private string _create_mode_tabs_visibility = "Collapsed";
        private string _interactive_mode_tabs_visibility = "Collapsed";

        private int _selected_index = 0;
        private EquipmentSlotsView _equipmentslotsview;
        private SkillsView _skillsview;
        private AppearanceView _appearanceview;

        public Player _player { get; set; }
        private LoadScreenViewModel _loadscreenviewmodel;


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
        public AppearanceView appearanceView
        {
            get
            {
                return _appearanceview;
            }
            set
            {
                _appearanceview = value;
                OnPropertyChanged("appearanceView");
            }
        }
        public EquipmentSlotsView equipmentSlotsView
        {
            get
            {
                return _equipmentslotsview;
            }
            set
            {
                _equipmentslotsview = value;
                OnPropertyChanged("equipmentSlotsView");
            }
        }
        public SkillsView skillsView
        {
            get
            {
                return _skillsview;
            }
            set
            {
                _skillsview = value;
                OnPropertyChanged("skillsView");
            }
        }
        
        public ControlPanelViewModel() : this(null, null, null) { }
        public ControlPanelViewModel(LoadScreenViewModel loadscreenviewmodel, Player player = null, string cp_mode = "View") // Create, View, Interactive.
        {
            _loadscreenviewmodel = loadscreenviewmodel;

            if (player != null)
                _player = player;
            else _player = new Player();

            setMode(cp_mode);

        }
        
        private void setMode(string cp_mode)
        {
            bool view_mode = false;
            switch (cp_mode)
            {
                case "Create":
                    CreateModeTabsVisibility = "Visible";
                    appearanceView = new AppearanceView(_player);
                    break;
                case "View":
                    view_mode = true;
                    break;
                case "Interactive":
                    InteractiveModeTabsVisibility = "Visible";
                    break;
            }
            skillsView = new SkillsView(_player.PlayerCombat.PlayerSkills, view_mode);
            equipmentSlotsView = new EquipmentSlotsView(_player.PlayerCombat.PlayerEquipment, view_mode);          


        }

        public void backToLoadScreen()
        {
            _loadscreenviewmodel.stopView();
        }
        public void Create()
        {

            if (_player.Name != "Default character")
            {
                Data_store.DeletePlayer(_player.Name);
                Data_store.SavePlayer(_player);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.SelectedPlayer = _player;
                _loadscreenviewmodel.stopView();
            }
        }


    }
}

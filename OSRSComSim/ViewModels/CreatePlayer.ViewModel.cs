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
    class CreatePlayerViewModel: ObservableObject
    {
        private int _selected_index;
        private EquipmentSlotsView _equipmentslotsview;
        private SkillsView _skillsview;
        private AppearanceView _appearanceview;

        public Player _player { get; set; }
        private LoadScreenViewModel _loadscreenviewmodel;

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

        public CreatePlayerViewModel(LoadScreenViewModel loadscreenviewmodel, Player player = null)
        {
            _loadscreenviewmodel = loadscreenviewmodel;

            if (player != null)
                _player = player;
            else _player = new Player();

            appearanceView = new AppearanceView(_player);
            skillsView = new SkillsView(_player.PlayerSkills);
            equipmentSlotsView = new EquipmentSlotsView(_player.PlayerEquipment, true);          

            setupCreatePlayerVM();
        }
        
        private void setupCreatePlayerVM()
        {
            _selected_index = 0;
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

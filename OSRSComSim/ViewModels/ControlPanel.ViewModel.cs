using OSRSComSim.Models;
using OSRSComSim.Views;
using System.Windows;

namespace OSRSComSim.ViewModels
{
    public class ControlPanelViewModel : ObservableObject
    {
        private string view_mode;
        private string cp_mode;

        private PlayerModel _player;
        private object _viewcontent;
        public object _tabs_background;
        private string _create_mode_tabs_visibility = "Collapsed";
        private string _edit_mode_tabs_visibility = "Collapsed";
        private string _interactive_mode_tabs_visibility = "Collapsed";
        private LoadScreenViewModel _loadscreenviewmodel;

        public object View { get; set; }
        public PlayerModel SelectedPlayer
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
            get { return _create_mode_tabs_visibility; }
            set
            {
                TabsBackground = new Thickness(0, 0, 0, 0);
                _create_mode_tabs_visibility = value;
                OnPropertyChanged("CreateModeTabsVisibility");
            }
        }
        public string EditModeTabsVisibility
        {
            get { return _edit_mode_tabs_visibility; }
            set
            {
                TabsBackground = new Thickness(0, 0, 0, 0);
                _edit_mode_tabs_visibility = value;
                OnPropertyChanged("EditModeTabsVisibility");
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
        public ControlPanelViewModel(LoadScreenViewModel loadscreenviewmodel = null, PlayerModel player = null, string cp_mode = null) // Create, Edit, View, Interactive.
        {
            _loadscreenviewmodel = loadscreenviewmodel;
            this.cp_mode = cp_mode;

            if (player != null)
                SelectedPlayer = player;
            else SelectedPlayer = new PlayerModel();

            setMode();
            View = new ControlPanelView(this);
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
                    ViewContent = new CombatOptionsViewModel(SelectedPlayer).View;
                    break;
                case "Skills":
                    ViewContent = new SkillsViewModel(SelectedPlayer.Skills, cp_mode).View;
                    break;
                case "Inventory":
                    ViewContent = new InventoryViewModel(SelectedPlayer, cp_mode).View;
                    break;
                case "Armor":
                    ViewContent = new WornEquipmentViewModel(SelectedPlayer.Equiped, cp_mode).View;
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
            if (SelectedPlayer.Name != "Default character" && !Data_store.CheckIfPlayerExists(SelectedPlayer.Name))
            {
                Data_store.SavePlayer(SelectedPlayer);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.SelectedPlayer = SelectedPlayer;
                backToLoadScreen();
            }
        }
        
        private void setMode()
        {
            if (cp_mode == "Create")
            {
                CreateModeTabsVisibility = "Visible";
                setViewMode("Appearance");
            }
            else if (cp_mode == "Edit")
            {
                Data_store.DeletePlayer(SelectedPlayer.Name);
                EditModeTabsVisibility = "Visible";
                setViewMode("Appearance");
            }
            else if (cp_mode == "Interactive")
            {
                InteractiveModeTabsVisibility = "Visible";
                setViewMode("Skills");
            }
        }
    }
}

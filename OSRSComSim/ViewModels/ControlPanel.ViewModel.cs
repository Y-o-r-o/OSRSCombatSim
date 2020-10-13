using OSRSComSim.Models;
using OSRSComSim.Views;
using System.Collections.ObjectModel;

namespace OSRSComSim.ViewModels
{
    public class ControlPanelViewModel : ObservableObject
    {
        private string cp_mode;

        private LoadScreenViewModel _loadscreenviewmodel;

        public object View { get; set; }
        public ObservableCollection<Tab> TabsLeft { get; set;}
        public ObservableCollection<Tab> TabsRight { get; set; }
        public PlayerModel SelectedPlayer { get; set; }
        public object ViewContent { get; set; }


        public ControlPanelViewModel() : this(null, null, null) { }
        public ControlPanelViewModel(LoadScreenViewModel loadscreenviewmodel = null, PlayerModel player = null, string cp_mode = null) // Create, Edit, View, Interactive.
        {
            _loadscreenviewmodel = loadscreenviewmodel;
            TabsLeft = new ObservableCollection<Tab>();
            TabsRight = new ObservableCollection<Tab>();

            this.cp_mode = cp_mode;

            if (player != null)
                SelectedPlayer = player;
            else SelectedPlayer = new PlayerModel();

            setTabs();

            View = new ControlPanelView(this);
        }


        public void run(string action)
        {
            switch (action)
            {
                case "appearance":
                    ViewContent = new AppearanceViewModel(SelectedPlayer, cp_mode).View;
                    break;
                case "combat":
                    ViewContent = new CombatOptionsViewModel(SelectedPlayer).View;
                    break;
                case "skills":
                    ViewContent = new SkillsViewModel(SelectedPlayer.Skills, cp_mode).View;
                    break;
                case "inventory":
                    ViewContent = new InventoryViewModel(SelectedPlayer, cp_mode).View;
                    break;
                case "equipment":
                    ViewContent = new WornEquipmentViewModel(SelectedPlayer.Equiped, cp_mode).View;
                    break;
                case "prayer":
                    break;
                case "magic":
                    break;
                case "accept":
                    Create();
                    break;
                case "decline":
                    backToLoadScreen();
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
                if(Data_store.CheckIfPlayerExists(SelectedPlayer.Name))
                {
                    Data_store.DeletePlayer(SelectedPlayer.Name);
                }
                Data_store.SavePlayer(SelectedPlayer);
                _loadscreenviewmodel.Load_players();
                _loadscreenviewmodel.SelectedPlayer = SelectedPlayer;
                backToLoadScreen();
            }
        }
        
        private void setTabs()
        {
            if (cp_mode == "Create" || cp_mode == "Edit")
            {
                TabsLeft.Add(new Tab(TabTypeModel.appearance));
                TabsRight.Add(new Tab(TabTypeModel.accept));
                TabsRight.Add(new Tab(TabTypeModel.decline));
            }
            if (cp_mode == "View" || cp_mode == "Edit" || cp_mode == "Create" || cp_mode == "Interactive")
            {
                TabsLeft.Add(new Tab(TabTypeModel.skills));
                TabsLeft.Add(new Tab(TabTypeModel.inventory));
                TabsLeft.Add(new Tab(TabTypeModel.equipment));
            }
            if(cp_mode == "Interactive")
            {
                TabsLeft.Insert(0, new Tab(TabTypeModel.combat));
                TabsLeft.Add(new Tab(TabTypeModel.prayer));
                TabsLeft.Add(new Tab(TabTypeModel.magic));
            }
        }
    }
}

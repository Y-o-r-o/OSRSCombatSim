namespace OSRSComSim.Models
{
    public class PlayerModel : ObservableObject
    {
        private string _name;
        private CombatModel _player_combat;
        private ItemModel[] _item;

        public string Name
        {
            get
            { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public CombatModel PlayerCombat
        {
            get
            {
                return _player_combat;
            }
            set
            {
                _player_combat = value;
            }
        }
        public ItemModel[] InventoryItem
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("InventoryItem");
            }
        }

        public PlayerModel() : this("Default character", null) { }
        public PlayerModel(string name = "Default character", CombatModel player_combat = null)
        {
            this.Name = name;
            InventoryItem = new ItemModel[28];
            for(int i = 0; i <28; i++)
            {
                InventoryItem[i] = new ItemModel();
            }
            if (player_combat != null)
                PlayerCombat = player_combat;
            else PlayerCombat = new CombatModel();
        }
    }
}

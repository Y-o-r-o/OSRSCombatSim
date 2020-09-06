namespace OSRSComSim.Models
{
    public class PlayerModel : ObservableObject
    {
        private const int inventory_capativity = 28;

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
            InventoryItem = new ItemModel[inventory_capativity];
            for(int i = 0; i < inventory_capativity; i++)
            {
                InventoryItem[i] = new ItemModel();
            }
            if (player_combat != null)
                PlayerCombat = player_combat;
            else PlayerCombat = new CombatModel();
        }
    }
}

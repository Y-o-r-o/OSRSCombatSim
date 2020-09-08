namespace OSRSComSim.Models
{
    public class PlayerModel : ObservableObject
    {

        private string _name;
        private CombatModel _player_combat;

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

        public PlayerModel() : this("Default character", null) { }
        public PlayerModel(string name = "Default character", CombatModel player_combat = null)
        {
            this.Name = name;
            if (player_combat != null)
                PlayerCombat = player_combat;
            else PlayerCombat = new CombatModel();
        }
    }
}

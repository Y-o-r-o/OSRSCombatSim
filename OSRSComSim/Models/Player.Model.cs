namespace OSRSComSim.Models
{
    public class PlayerModel : ObservableObject
    {

        private string _name;

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
        public CombatModel Combat { get; set; }
        public StatusModel Status { get; set; }
        public SkillsModel Skills { get; set; }
        public EquipedModel Equiped { get; set; }

        public PlayerModel() : this("Default character", null, null, null) { }
        public PlayerModel(string name = "Default character", CombatModel combat = null, SkillsModel skills = null, EquipedModel equiped = null)
        {
            this.Name = name;
            if (combat != null)
                Combat = combat;
            else Combat = new CombatModel();
            if (skills != null)
                Skills = skills;
            else Skills = new SkillsModel();
            if (equiped != null)
                Equiped = Equiped;
            else Equiped = new EquipedModel();
            Status = new StatusModel(Skills.Hp_lvl);
        }
    }
}

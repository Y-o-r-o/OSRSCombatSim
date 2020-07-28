using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Player: ObservableObject
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
        public Skills PlayerSkills { get; set; }
        public Equiped PlayerEquipment { get; set; }
        public Equiped PlayerEuipment { get; set; }

        public Combat combat = new Combat();


        public Player() : this("Default character", null,null) { }
        public Player(string name = "Default character", Skills player_skills = null, Equiped player_equipment = null)
        {
            this.Name = name;

            if (player_skills != null)
                PlayerSkills = player_skills;
            else PlayerSkills = new Skills();
            if (player_equipment != null)
                PlayerEquipment = player_equipment;
            else PlayerEquipment = new Equiped();
            setupPlayer();
        }

        private void setupPlayer()
        { 
            combat.set_combat(PlayerSkills.Str_lvl, PlayerSkills.Atk_lvl, PlayerSkills.Def_lvl);
        }

    }
}

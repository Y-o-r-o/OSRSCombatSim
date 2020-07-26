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
        public Skills PlayerStats { get; set; } 
        
        public Combat combat = new Combat();


        public Player() : this("Default character", null) { }
        public Player(string name = "Default character", Skills player_skills = null)
        {
            this.Name = name;

            if (player_skills != null)
                PlayerStats = player_skills;
            else PlayerStats = new Skills();

            setupPlayer();
        }

        private void setupPlayer()
        { 
            combat.set_combat(PlayerStats.Str_lvl, PlayerStats.Atk_lvl, PlayerStats.Def_lvl);
        }




    }
}

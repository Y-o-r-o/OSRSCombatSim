using System;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace OSRSComSim.Models
{
    public class Player: ObservableObject
    {
        private string _name;
        private Combat _player_combat;

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
       public Combat PlayerCombat 
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


        public Player() : this("Default character",null) { }
        public Player(string name = "Default character", Combat player_combat = null)
        {
            this.Name = name;
            if (player_combat != null)
                PlayerCombat = player_combat;
            else PlayerCombat = new Combat();
        }
    }
}

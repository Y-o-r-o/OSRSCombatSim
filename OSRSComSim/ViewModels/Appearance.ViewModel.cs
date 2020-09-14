using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Linq;

namespace OSRSComSim.ViewModels
{
    public class AppearanceViewModel: ObservableObject
    {
        private PlayerModel _player;
        private string _setnamequotes;

        public object View { get; set; }
        public string SetNameQuotes
        {
            get
            {
                return _setnamequotes;
            }
            set
            {
                _setnamequotes = value;
                OnPropertyChanged("SetNameQuotes");
            }

        }
        public string Name
        {
            get
            { return _player.Name; }
            set
            {
                _player.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public AppearanceViewModel (): this(null) { }
        public AppearanceViewModel(PlayerModel player = null)
        {
            _player = player;
            _setnamequotes = "Enter player name here.";
            
            View = new AppearanceView(this);
        }

        public void setPlayerName(string boxtext)
        {

            if (!String_functions.HasNoSpecialChars(boxtext))
            {
                SetNameQuotes = "Dont use special chars.";
            }
            else if (Data_store.CheckIfPlayerExists(boxtext))
            {
                SetNameQuotes = "Player with this name already exists.";
            }
            else if (boxtext.Length > 20 || boxtext.Length < 6)
            {
                SetNameQuotes = "Player name length must bet betwee 6 and 20.";
            }
            else
            {
                Name = Name.Remove(0);
                Name = Name.Insert(0,boxtext);
                SetNameQuotes = "Name set!";
            }

        }


    }
}

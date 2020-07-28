using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class AppearanceViewModel: ObservableObject
    {
        private Player _player;
        private string _setnamequotes;

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

        public AppearanceViewModel(Player player)
        {
            _player = player;
            _setnamequotes = "Enter player name here.";
        }

        public void setPlayerName(string boxtext)
        {

            if (!HasNoSpecialChars(boxtext))
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
                //SelectedIndex = 1;
            }

        }

        private bool HasNoSpecialChars(string yourString)
        {
            return !yourString.Any(ch => !Char.IsLetterOrDigit(ch));
        }
    }
}

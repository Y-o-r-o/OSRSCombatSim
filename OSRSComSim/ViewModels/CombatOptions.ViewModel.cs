using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class CombatOptionsViewModel: ObservableObject
    {
        private Combat _combat;

        public Combat FighterCombat
        {
            get { return _combat; }
            set
            {
                _combat = value;
                OnPropertyChanged("FighterCombat");
            }
        }

        public CombatOptionsViewModel() : this(null) { }
        public CombatOptionsViewModel (Combat combat = null)
        {
            FighterCombat = combat;

        }


    }
}

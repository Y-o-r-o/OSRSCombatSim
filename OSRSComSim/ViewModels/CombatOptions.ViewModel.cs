using OSRSComSim.Models;
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

        public CombatOptionsViewModel (Combat combat)
        {
            FighterCombat = combat;

        }


    }
}

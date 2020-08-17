using OSRSComSim.Models;
using OSRSComSim.Views;

namespace OSRSComSim.ViewModels
{
    public class CombatOptionsViewModel: ObservableObject
    {
        private Combat _combat;

        public CombatOptionsView View { get; set; }
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
            
            View = new CombatOptionsView(this);
        }

    }
}
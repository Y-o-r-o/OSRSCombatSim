using OSRSComSim.Models;
using OSRSComSim.Views;

namespace OSRSComSim.ViewModels
{
    public class CombatOptionsViewModel : ObservableObject
    {
        private Combat _combat;
        private string[] _options_visibility = null;
        private int[] _options_horizontal_place = null;
        private int[] _options_vertical_place = null;
        private int[] _options_heigth_by_rows = null;


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

        public string[] OptionsVisibility
        {
            get
            {
                return _options_visibility;
            }
            set
            {
                _options_visibility = value;
                OnPropertyChanged("OptionsVisibility");
            }
        }
        public int[] OptionsHorizontalPlace
        {
            get
            {
                return _options_horizontal_place;
            }
            set
            {
                _options_horizontal_place = value;
                OnPropertyChanged("OptionsHorizontalPlace");
            }
        }
        public int[] OptionsVerticalPlace
        {
            get
            {
                return _options_vertical_place;
            }
            set
            {
                _options_vertical_place = value;
                OnPropertyChanged("OptionsVerticalPlace");
            }
        }
        public int[] OptionsHeigthByRows
        {
            get
            {
                return _options_heigth_by_rows;
            }
            set
            {
                _options_heigth_by_rows = value;
                OnPropertyChanged("OptionsHeigthByRows");
            }
        }


        public CombatOptionsViewModel() : this(null) { }
        public CombatOptionsViewModel (Combat combat = null)
        {
            FighterCombat = combat;
            
            View = new CombatOptionsView(this);

            setupOptionsVisibility();
            setupOptionsHorizontalPlace();
            setupOptionsVerticalPlace();
            setupOptionsHeigthByRows();
        }

        private void setupOptionsVisibility()
        {
            string[] visibilieties = new string[8];

            visibilieties[0] = "Visible";
            visibilieties[1] = "Visible";
            visibilieties[2] = "Visible";
            visibilieties[3] = "Collapsed";
            visibilieties[4] = "Collapsed";
            visibilieties[5] = "Collapsed";
            visibilieties[6] = "Collapsed";
            visibilieties[7] = "Collapsed";

            OptionsVisibility = visibilieties;
        }
        private void setupOptionsHorizontalPlace()
        {
            int[] parameterof = new int[8];

            parameterof[0] = 0;
            parameterof[1] = 0;
            parameterof[2] = 1;
            parameterof[3] = 1;
            parameterof[4] = 1;
            parameterof[5] = 0;
            parameterof[6] = 1;
            parameterof[7] = 1;

            OptionsHorizontalPlace = parameterof;
        }
        private void setupOptionsVerticalPlace()
        {
            int[] parameterof = new int[8];

            parameterof[0] = 2;
            parameterof[1] = 4;
            parameterof[2] = 2;
            parameterof[3] = 4;
            parameterof[4] = 2;
            parameterof[5] = 4;
            parameterof[6] = 4;
            parameterof[7] = 2;

            OptionsVerticalPlace = parameterof;
        }
        private void setupOptionsHeigthByRows()
        {
            int[] parameterof = new int[8];

            parameterof[0] = 2;
            parameterof[1] = 2;
            parameterof[2] = 2;
            parameterof[3] = 2;
            parameterof[4] = 2;
            parameterof[5] = 2;
            parameterof[6] = 2;
            parameterof[7] = 2;

            OptionsHeigthByRows = parameterof;
        }
    }
}
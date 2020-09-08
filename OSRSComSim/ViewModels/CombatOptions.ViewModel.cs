using OSRSComSim.Models;
using OSRSComSim.Views;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace OSRSComSim.ViewModels
{
    public class CombatOptionsViewModel : ObservableObject
    {
        private CombatModel _combat;
        private string[] _options_content = null;
        private string[] _options_style_content = null;
        private string[] _options_visibility = null;
        private int[] _options_horizontal_place = null;
        private int[] _options_vertical_place = null;
        private int[] _options_heigth_by_rows = null;

        public object View { get; set; }
        public CombatModel FighterCombat
        {
            get { return _combat; }
            set
            {
                _combat = value;
                OnPropertyChanged("FighterCombat");
            }
        }

        public string[] OptionsContent
        {
            get
            {
                return _options_content;
            }
            set
            {
                _options_content = value;
                OnPropertyChanged("OptionsContent");
            }
        }
        public string[] OptionsStyleContent
        {
            get
            {
                return _options_style_content;
            }
            set
            {
                _options_style_content = value;
                OnPropertyChanged("OptionsStyleContent");
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
        public CombatOptionsViewModel(CombatModel combat = null)
        {
            FighterCombat = combat;
            WeaponTypeModel.setOptions(combat,combat.PlayerEquipment.Weapon.WeaponType);
            setupOptions();
            setCombat(WeaponTypeModel.Option1, WeaponTypeModel.Option1Style);

            View = new CombatOptionsView(this);
        }

        public void setCombat(string combat_style, string attack_type)
        {
            WeaponTypeModel.setCombat(FighterCombat, combat_style,attack_type);
        }

        private void setupOptions()
        {
            setupOptionsVisibility();
            setupOptionsContent();
            setupOptionsHorizontalPlace();
            setupOptionsVerticalPlace();
            setupOptionsHeigthByRows();
        }
        private void setupOptionsContent()
        {
            string[] content = new string[5];
            string[] contentstyle = new string[5];

            content[0] = WeaponTypeModel.Option1;
            content[1] = WeaponTypeModel.Option2;
            content[2] = WeaponTypeModel.Option3;
            content[3] = WeaponTypeModel.Option4;
            content[4] = WeaponTypeModel.Option5;

            contentstyle[0] = /*"(" + */WeaponTypeModel.Option1Style /*+ ")"*/;
            contentstyle[1] = /*"(" + */WeaponTypeModel.Option2Style /*+ ")"*/;
            contentstyle[2] = /*"(" + */WeaponTypeModel.Option3Style /*+ ")"*/;
            contentstyle[3] = /*"(" + */WeaponTypeModel.Option4Style /*+ ")"*/;
            contentstyle[4] = /*"(" + */WeaponTypeModel.Option5Style /*+ ")"*/;

            OptionsContent = content;
            OptionsStyleContent = contentstyle;
        }
        private void setupOptionsVisibility()
        {
            string[] visibilieties = new string[5];
            for (int i = WeaponTypeModel.NumberOfOptions; i < 5; i++)
            {
                visibilieties[i] = "Collapsed";
            }
            OptionsVisibility = visibilieties;
        }
        private void setupOptionsHorizontalPlace()
        {
            int[] parameterof = new int[5];
            if (WeaponTypeModel.NumberOfOptions < 5)
            {
                parameterof[0] = 0;
                parameterof[1] = 1;
                parameterof[2] = 0;
                parameterof[3] = 1;
            }
            else
            {
                parameterof[0] = 0;
                parameterof[1] = 0;
                parameterof[2] = 0;
                parameterof[3] = 1;
                parameterof[4] = 1;
            }
            OptionsHorizontalPlace = parameterof;
        }
        private void setupOptionsVerticalPlace()
        {
            int[] parameterof = new int[5];
            if (WeaponTypeModel.NumberOfOptions < 5)
            {
                parameterof[0] = 2;
                parameterof[1] = 2;
                parameterof[2] = 4;
                parameterof[3] = 4;
            }
            else
            {
                parameterof[0] = 2;
                parameterof[1] = 3;
                parameterof[2] = 5;
                parameterof[3] = 2;
                parameterof[4] = 4;
            }
            OptionsVerticalPlace = parameterof;
        }
        private void setupOptionsHeigthByRows()
        {
            int[] parameterof = new int[5];
            if (WeaponTypeModel.NumberOfOptions < 5)
            {
                parameterof[0] = 2;
                parameterof[1] = 2;
                parameterof[2] = 2;
                parameterof[3] = 2;
            }
            else
            {
                parameterof[0] = 1;
                parameterof[1] = 2;
                parameterof[2] = 1;
                parameterof[3] = 2;
                parameterof[4] = 2;
            }
            OptionsHeigthByRows = parameterof;
        }


    }
}
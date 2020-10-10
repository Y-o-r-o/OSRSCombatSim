using OSRSComSim.Models;
using OSRSComSim.Views;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace OSRSComSim.ViewModels
{
    public class CombatOptionsViewModel : ObservableObject
    {
        public object View { get; set; }
        public PlayerModel Fighter { get; set; }
        public CombatModel FighterCombat { get; set; }

        public string[] OptionsContent { get; set; }
        public string[] OptionsStyleContent { get; set; }
        public string[] OptionsVisibility { get; set; }
        public int[] OptionsHorizontalPlace { get; set; }
        public int[] OptionsVerticalPlace { get; set; }
        public int[] OptionsHeigthByRows { get; set; }


        public CombatOptionsViewModel() : this(null) { }
        public CombatOptionsViewModel(PlayerModel player)
        {
            Fighter = player;
            FighterCombat = player.Combat;
            WeaponTypeModel.setOptions(FighterCombat,player.Equiped.Weapon.WeaponType);
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
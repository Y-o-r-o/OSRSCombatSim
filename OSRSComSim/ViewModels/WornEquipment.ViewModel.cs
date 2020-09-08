using OSRSComSim.Models;
using OSRSComSim.Models.Items;
using OSRSComSim.Models.Items.Equipments;
using OSRSComSim.Views;
using System;

namespace OSRSComSim.ViewModels
{
    public class WornEquipmentViewModel : ObservableObject
    {
        private string selected_slot_table = "";

        private bool _show_select = false;
        private EquipedModel _player_equiped;
        private SelectItemViewModel _select_equipment;
        private string _equipment_info = "";

        public object View { get; set; }
        public SelectItemViewModel selectEquipment
        {
            get { return _select_equipment; }
            set
            {
                _select_equipment = value;
                OnPropertyChanged("selectEquipment");
            }
        }
        public EquipedModel PlayerEquiped
        {
            get { return _player_equiped; }
            set
            {
                _player_equiped = value;
                OnPropertyChanged("PlayerEquiped");
            }
        }
        public string EquipmentInfo
        {
            get { return _equipment_info; }
            set
            {
                _equipment_info = value;
                OnPropertyChanged("EquipmentInfo");
            }
        }


        public WornEquipmentViewModel() : this(null, "Edit") { }
        public WornEquipmentViewModel(EquipedModel player_equiped = null, string we_mode = "Edit")
        {

            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new EquipedModel();
            selectEquipment = null;
            if(we_mode == "Edit" || we_mode == "Create")
                _show_select = true;
            setEquipmentInfo();

            View = new WornEquipmentView(this);
        }

        public void manageEquipment(string selected_slot_table, bool mount = false)
        {
            this.selected_slot_table = selected_slot_table;
            if (mount)
            {
                if (_show_select)
                    selectEquipment = new SelectItemViewModel(this, selected_slot_table);
            }
            else
            {
                mountEquipment("");
            }
        }

        public void setEquipmentInfo()
        {
            string Info = "";
            Info =  "SlashAtk  " + PlayerEquiped.getTotalSlashAtk().ToString().PadRight(5) + "\n";
            Info += "StabAtk   " + PlayerEquiped.getTotalStabAtk().ToString().PadRight(5) + "\n";
            Info += "CrushAtk  " + PlayerEquiped.getTotalCrushAtk().ToString().PadRight(5) + "\n";
            Info += "MagicAtk  " + PlayerEquiped.getTotalMagicAtk().ToString().PadRight(5) + "\n";
            Info += "RangedAtk " + PlayerEquiped.getTotalRangedAtk().ToString().PadRight(5) + "\n";
            Info += "SlashDef  " + PlayerEquiped.getTotalSlashDef().ToString().PadRight(5) + "\n";
            Info += "StabDef   " + PlayerEquiped.getTotalStabDef().ToString().PadRight(5) + "\n";
            Info += "CrushDef  " + PlayerEquiped.getTotalCrushDef().ToString().PadRight(5) + "\n";
            Info += "MagicDef  " + PlayerEquiped.getTotalMagicDef().ToString().PadRight(5) + "\n";
            Info += "RangedDef " + PlayerEquiped.getTotalRangedDef().ToString().PadRight(5) + "\n";
            Info += "MeleStr   " + PlayerEquiped.getTotalMeleStr().ToString().PadRight(5) + "\n";
            Info += "MagicStr  " + PlayerEquiped.getTotalMagicStr().ToString().PadRight(5) + "\n";
            Info += "RangedStr " + PlayerEquiped.getTotalRangedStr().ToString().PadRight(5) + "\n";
            Info += "Prayer    " + PlayerEquiped.getTotalPrayer().ToString().PadRight(5) + "\n";
            Info += "Weigth    " + PlayerEquiped.getTotalWeigth().ToString().PadRight(5) + "\n";
            EquipmentInfo = Info;
        }

        public void mountEquipment(string eqp)
        {
            switch (selected_slot_table)
            {
                case "Head":
                    PlayerEquiped.Head = new EquipmentModel("Head", eqp);
                    break;
                case "Neck":
                    PlayerEquiped.Neck = new EquipmentModel("Neck", eqp);
                    break;
                case "Cape":
                    PlayerEquiped.Cape = new EquipmentModel("Cape", eqp);
                    break;
                case "Ammo":
                    PlayerEquiped.Ammo = new EquipmentModel("Ammo", eqp);
                    break;
                case "Weapon":
                    PlayerEquiped.Weapon = new WeaponModel(eqp);
                    if (PlayerEquiped.Weapon.is_two_handed) PlayerEquiped.Shield = new EquipmentModel("Shield");
                    break;
                case "Body":
                    PlayerEquiped.Body = new EquipmentModel("Body", eqp);
                    break;
                case "Shield":
                    PlayerEquiped.Shield = new EquipmentModel("Shield", eqp);
                    if (PlayerEquiped.Weapon.is_two_handed) PlayerEquiped.Weapon = new WeaponModel();
                    break;
                case "Legs":
                    PlayerEquiped.Legs = new EquipmentModel("Legs", eqp);
                    break;
                case "Feet":
                    PlayerEquiped.Feet = new EquipmentModel("Feet", eqp);
                    break;
                case "Hands":
                    PlayerEquiped.Hands = new EquipmentModel("Hands", eqp);
                    break;
                case "Ring":
                    PlayerEquiped.Ring = new EquipmentModel("Ring", eqp);
                    break;
                default:
                    break;
            }
            setEquipmentInfo();
        }


    }
}

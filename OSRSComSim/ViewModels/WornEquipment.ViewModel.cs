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

        private bool _show_select;
        private Equiped _player_equiped;
        private SelectEquipmentViewModel _select_equipment;
        private string _equipment_info = "";

        public WornEquipmentView View { get; set; }
        public SelectEquipmentViewModel selectEquipment
        {
            get { return _select_equipment; }
            set
            {
                _select_equipment = value;
                OnPropertyChanged("selectEquipment");
            }
        }
        public Equiped PlayerEquiped
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


        public WornEquipmentViewModel() : this(null, true) { }
        public WornEquipmentViewModel(Equiped player_equiped = null, bool view_mode = true)
        {

            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new Equiped();
            selectEquipment = null;
            _show_select = !view_mode;
            setEquipmentInfo();

            View = new WornEquipmentView(this);
        }

        public void manageEquipment(string selected_slot_table, bool mount = false)
        {
            this.selected_slot_table = selected_slot_table;
            if (mount)
            {
                if (_show_select)
                    selectEquipment = new SelectEquipmentViewModel(this, PlayerEquiped, selected_slot_table);
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

        public void mountEquipment(string eqp, bool is_two_handed = false)
        {
            object to_mount = set_equipment(eqp, is_two_handed);
            switch (selected_slot_table)
            {
                case "Head":
                    PlayerEquiped.Head = to_mount as Equipment;
                    break;
                case "Neck":
                    PlayerEquiped.Neck = to_mount as Equipment;
                    break;
                case "Cape":
                    PlayerEquiped.Cape = to_mount as Equipment;
                    break;
                case "Ammo":
                    PlayerEquiped.Ammo = to_mount as Equipment;
                    break;
                case "Weapon":
                    PlayerEquiped.Weapon = to_mount as Weapon;
                    if (is_two_handed) PlayerEquiped.Shield = new Equipment("Shield");
                    break;
                case "Body":
                    PlayerEquiped.Body = to_mount as Equipment;
                    break;
                case "Shield":
                    PlayerEquiped.Shield = to_mount as Equipment;
                    if (PlayerEquiped.Weapon.is_two_handed) PlayerEquiped.Weapon = new Weapon("Unarmed");
                    break;
                case "Legs":
                    PlayerEquiped.Legs = to_mount as Equipment;
                    break;
                case "Feet":
                    PlayerEquiped.Feet = to_mount as Equipment;
                    break;
                case "Hands":
                    PlayerEquiped.Hands = to_mount as Equipment;
                    break;
                case "Ring":
                    PlayerEquiped.Ring = to_mount as Equipment;
                    break;
                default:
                    break;
            }
            setEquipmentInfo();
        }

        public object set_equipment(string eqp, bool is_two_handed = false)
        {
            if (eqp != "")
            {
                //if (values[1].Contains("Free-to-play")) Member = false;   !!!!!!!!!!!!!!!!!!!
                //else Member = true;                                       !!!!!!!!!!!!!!!!!!!
                string[] values = eqp.Split(',');
                if (selected_slot_table.Contains("Weapon"))
                {
                    Weapon to_mount = new Weapon(selected_slot_table)
                    {
                        Name = values[0],
                        StabAtk = Int32.Parse(values[2]),
                        SlashAtk = Int32.Parse(values[3]),
                        CrushAtk = Int32.Parse(values[4]),
                        MagicAtk = Int32.Parse(values[5]),
                        RangedAtk = Int32.Parse(values[6]),
                        StabDef = Int32.Parse(values[7]),
                        SlashDef = Int32.Parse(values[8]),
                        CrushDef = Int32.Parse(values[9]),
                        MagicDef = Int32.Parse(values[10]),
                        RangedDef = Int32.Parse(values[11]),
                        MeleStr = Int32.Parse(values[12]),
                        RangedStr = Int32.Parse(values[13]),
                        MagicStr = Int32.Parse(values[14]),
                        Prayer = Int32.Parse(values[15]),
                        Weigth = Double.Parse(values[16]),
                        Speed = Int32.Parse(values[17]),
                        Png = setPng(values[0]),
                        WeaponType = values[18],
                        is_two_handed = is_two_handed
                    };
                    return to_mount;
                }
                else {
                    Equipment to_mount = new Equipment(selected_slot_table)
                    {
                        Name = values[0],
                        StabAtk = Int32.Parse(values[2]),
                        SlashAtk = Int32.Parse(values[3]),
                        CrushAtk = Int32.Parse(values[4]),
                        MagicAtk = Int32.Parse(values[5]),
                        RangedAtk = Int32.Parse(values[6]),
                        StabDef = Int32.Parse(values[7]),
                        SlashDef = Int32.Parse(values[8]),
                        CrushDef = Int32.Parse(values[9]),
                        MagicDef = Int32.Parse(values[10]),
                        RangedDef = Int32.Parse(values[11]),
                        MeleStr = Int32.Parse(values[12]),
                        RangedStr = Int32.Parse(values[13]),
                        MagicStr = Int32.Parse(values[14]),
                        Prayer = Int32.Parse(values[15]),
                        Weigth = Double.Parse(values[16]),
                        Speed = Int32.Parse(values[17]),
                        Png = setPng(values[0])
                    };
                    return to_mount;
                }
            }
            else
            {
                return new Equipment(selected_slot_table);
            }
        }

        private string setPng(string png_name)
        {
            string png_location = "../../Resources/Items/png/" + selected_slot_table + "/" + png_name.Replace(" ", "_") + ".png";
            if (Data_store.CheckIfFileExists(png_location))
            {
                return png_location;
            }
            else return "../../Resources/404.png";

        }
    }
}

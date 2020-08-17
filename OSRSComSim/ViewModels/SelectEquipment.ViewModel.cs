using OSRSComSim.Models;
using System.Collections.Generic;
using System.Linq;

namespace OSRSComSim.ViewModels
{
    public class SelectEquipmentViewModel: ObservableObject
    {
        WornEquipmentViewModel _wornequipmentviewmodel;

        private Equiped _player_equiped;

        public string[] _lines;

        public SelectEquipmentView View { get; set; }
        public Equiped PlayerEquiped
        {
            get { return _player_equiped; }
            set
            {
                _player_equiped = value;
                OnPropertyChanged("PlayerEquiped");
            }
        }
        public IEnumerable<string> ReadCSV
        {
            get
            {
                    return _lines.Select(line =>
                    {
                        string[] data = line.Split(',');
                        return data[0];
                    });
                }
            
        }

        public SelectEquipmentViewModel() : this(null, null, null) { }
        public SelectEquipmentViewModel(WornEquipmentViewModel wornequipmentviewmodel, Equiped player_equiped, string selected_slot_table)
        {
            _wornequipmentviewmodel = wornequipmentviewmodel;
            _lines = getCSV(selected_slot_table);//File.ReadAllLines("../../Resources/Items/csv/Slot tables/" + SelectedSlotTable + " slot table.csv");

            PlayerEquiped = player_equiped;

            View = new SelectEquipmentView(this);
        }
        

        private string getEquipmentData(string equipment_name)
        {
            foreach (string eqp in _lines)
            {
                if (eqp.Contains(equipment_name))
                    return eqp;
            }
            return "";
        }


        private string[] getCSV(string selected_slot_table)
        {
            string[] lines = null;
            switch (selected_slot_table)
            {
                case "Head":
                    lines = Properties.Resources.Head_slot_table.Split('\n');
                    break;
                case "Neck":
                    lines = Properties.Resources.Neck_slot_table.Split('\n');
                    break;
                case "Cape":
                    lines = Properties.Resources.Cape_slot_table.Split('\n');
                    break;
                case "Ammo":
                    lines = Properties.Resources.Ammo_slot_table.Split('\n');
                    break;
                case "Weapon":
                    lines = Properties.Resources.Weapon_slot_table.Split('\n');
                    break;
                case "Body":
                    lines = Properties.Resources.Body_slot_table.Split('\n');
                    break;
                case "Shield":
                    lines = Properties.Resources.Shield_slot_table.Split('\n');
                    break;
                case "Legs":
                    lines = Properties.Resources.Legs_slot_table.Split('\n');
                    break;
                case "Feet":
                    lines = Properties.Resources.Feet_slot_table.Split('\n');
                    break;
                case "Hands":
                    lines = Properties.Resources.Hands_slot_table.Split('\n');
                    break;
                case "Ring":
                    lines = Properties.Resources.Ring_slot_table.Split('\n');
                    break;
            }
            lines = lines.Skip(1).ToArray();
            lines = lines.Take(lines.Count() - 1).ToArray();
            return lines;
        }

        public void select(string equipment_name)
        {
            _wornequipmentviewmodel.mountEquipment(getEquipmentData(equipment_name));
        }
        public void stopView()
        {
            _wornequipmentviewmodel.selectEquipment = null;
        }

    }
}

using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSRSComSim.ViewModels
{
    public class SelectItemViewModel: ObservableObject
    {
        WornEquipmentViewModel _wornequipmentviewmodel;

        public string[] _lines;

        private int two_handed_idx = 0;
        private bool is_two_handed = false;

        public SelectItemView View { get; set; }


        public string SelectType { get; set; } = "Select item:";

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

        public SelectItemViewModel() : this(null, null) { }
        public SelectItemViewModel(WornEquipmentViewModel wornequipmentviewmodel, string selected_item)
        {
            _wornequipmentviewmodel = wornequipmentviewmodel;
            _lines = getCSV("Food");

            View = new SelectItemView(this);
        }
        
        private string getEquipmentData(string equipment_name)
        {
            int i = 0;
            foreach (string eqp in _lines)
            {
                i++;
                if (eqp.Contains(equipment_name))
                {
                    if (two_handed_idx <= i) is_two_handed = true;
                    return eqp;
                }
            }
            return "";
        }
        private string[] getCSV(string selected_item)
        {
            string[] lines = null;
            switch (selected_item)
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
                case "Food":
                    lines = Properties.Resources.Food.Split('\n');
                    break;
                case "Potion":
                    lines = Properties.Resources.Potions.Split('\n');
                    break;
                case "Runes":
                    lines = Properties.Resources.Runes.Split('\n');
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

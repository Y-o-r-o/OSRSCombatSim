using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSRSComSim.ViewModels
{
    public class SelectEquipmentViewModel: ObservableObject
    {
        WornEquipmentViewModel _wornequipmentviewmodel;

        private EquipedModel _player_equiped;

        public string[] _lines;

        private int two_handed_idx = 0;
        private bool is_two_handed = false;

        public SelectEquipmentView View { get; set; }
        public EquipedModel PlayerEquiped
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
        public SelectEquipmentViewModel(WornEquipmentViewModel wornequipmentviewmodel, EquipedModel player_equiped, string selected_slot_table)
        {
            _wornequipmentviewmodel = wornequipmentviewmodel;
            _lines = getCSV(selected_slot_table);//File.ReadAllLines("../../Resources/Items/csv/Slot tables/" + SelectedSlotTable + " slot table.csv");

            PlayerEquiped = player_equiped;

            View = new SelectEquipmentView(this);
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
                    string[] lines1 = Properties.Resources.Weapon_slot_table.Split('\n');
                    Array.Resize(ref lines1, lines1.Length - 1);
                    string[] lines2 = Properties.Resources.Two_handed_slot_table.Split('\n');
                    lines2 = lines2.Skip(1).ToArray();
                    two_handed_idx = lines1.Length;
                    lines = new string[lines1.Length + lines2.Length];
                    Array.Copy(lines1, lines, lines1.Length);
                    Array.Copy(lines2, 0, lines, lines1.Length, lines2.Length);
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
            _wornequipmentviewmodel.mountEquipment(getEquipmentData(equipment_name), is_two_handed);
        }
        public void stopView()
        {
            _wornequipmentviewmodel.selectEquipment = null;
        }

    }
}

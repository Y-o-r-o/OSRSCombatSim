using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class SelectEquipmentViewModel: ObservableObject
    {

        private Equiped _player_equiped;

        private string _selected_slot_table = "";
        private string[] _selected_slot_table_lines;

        public Equiped PlayerEquiped
        {
            get { return _player_equiped; }
            set
            {
                _player_equiped = value;
                OnPropertyChanged("PlayerEquiped");
            }
        }
        public string SelectedSlotTable
        {
            get { return _selected_slot_table; }
            set
            {
                _selected_slot_table = value;
                OnPropertyChanged("SelectedSlotTable");
                OnPropertyChanged("ReadCSV");
            }
        }
        public IEnumerable<string> ReadCSV
        {
            get
            {
                if (SelectedSlotTable == "")
                    return null;
                else
                {
                    string[] lines = getCSV();//File.ReadAllLines("../../Resources/Items/csv/Slot tables/" + SelectedSlotTable + " slot table.csv");

                    prepareTempEquipmentsData(lines);

                    return lines.Select(line =>
                    {
                        string[] data = line.Split(',');
                        return data[0];
                    });
                }
            }
        }

        public SelectEquipmentViewModel(Equiped player_equiped, string selected_slot_table)
        {
            PlayerEquiped = player_equiped;
            SelectedSlotTable = selected_slot_table;
        }
        public void mountEquipment(string equipment_name)
        {
            string eqp = getEquipmentData(equipment_name);

            if (!eqp.Equals(""))
            {
                switch (SelectedSlotTable)
                {
                    case "Head":
                        PlayerEquiped.Head.setData(eqp, _selected_slot_table);
                        break;
                    case "Neck":
                        PlayerEquiped.Neck.setData(eqp, _selected_slot_table);
                        break;
                    case "Cape":
                        PlayerEquiped.Cape.setData(eqp, _selected_slot_table);
                        break;
                    case "Ammo":
                        PlayerEquiped.Ammo.setData(eqp, _selected_slot_table);
                        break;
                    case "Weapon":
                        PlayerEquiped.Weapon.setData(eqp, _selected_slot_table);
                        break;
                    case "Body":
                        PlayerEquiped.Body.setData(eqp, _selected_slot_table);
                        break;
                    case "Shield":
                        PlayerEquiped.Shield.setData(eqp, _selected_slot_table);
                        break;
                    case "Legs":
                        PlayerEquiped.Legs.setData(eqp, _selected_slot_table);
                        break;
                    case "Feet":
                        PlayerEquiped.Feet.setData(eqp, _selected_slot_table);
                        break;
                    case "Hands":
                        PlayerEquiped.Hands.setData(eqp, _selected_slot_table);
                        break;
                    case "Ring":
                        PlayerEquiped.Ring.setData(eqp, _selected_slot_table);
                        break;
                }
            }
        }

        private string getEquipmentData(string equipment_name)
        {
            foreach (string eqp in _selected_slot_table_lines)
            {
                if (eqp.Contains(equipment_name))
                    return eqp;
            }
            return "";
        }
        private string[] getCSV()
        {
            string[] lines = null;
            switch (SelectedSlotTable)
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
        private void prepareTempEquipmentsData(string[] selected_slot_table_lines)
        {
            _selected_slot_table_lines = selected_slot_table_lines;
        }


    }
}

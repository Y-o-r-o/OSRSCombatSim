using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class EquipmentSlotsViewModel:ObservableObject
    {
        private Equiped _player_equiped;
        private string _selected_slot_table = "";
        private string[] _selected_slot_table_lines;

        public Equiped PlayerEquiped
        {
            get{ return _player_equiped; }
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
                    string[] lines = File.ReadAllLines("../../Resources/Items/csv/Slot tables/" + _selected_slot_table + " slot table.csv");
                    lines = lines.Skip(1).ToArray();
                    prepareTempEquipmentsData(lines);
                    
                    return lines.Select(line =>
                    {
                        string[] data = line.Split(',');
                        return data[0];
                    });
                }
            }
        }


    
        public EquipmentSlotsViewModel(Equiped player_equiped = null)
        {
            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new Equiped();
        }




        public void mountEquipment(string equipment_name)
        {
            string eqp = getEquipmentData(equipment_name);

            if (!eqp.Equals(""))
            {
                switch (_selected_slot_table)
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

        private void prepareTempEquipmentsData(string[] selected_slot_table_lines)
        {
            _selected_slot_table_lines = selected_slot_table_lines;
        }
        
    }
}

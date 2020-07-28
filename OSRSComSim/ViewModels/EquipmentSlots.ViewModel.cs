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
                    prepareTempEquipmentData(lines);
                    return lines.Select(line =>
                    {
                        string[] data = line.Split(',');
                        return data[0];
                    });
                }
            }
        }
        
        public void prepareTempEquipmentData(string[] selected_slot_table_lines)
        {
            _selected_slot_table_lines = selected_slot_table_lines;
        }
        
        public EquipmentSlotsViewModel(Equiped player_equiped = null)
        {
            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new Equiped();
        }


        
        
    }
}

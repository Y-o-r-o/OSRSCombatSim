using OSRSComSim.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OSRSComSim.ViewModels
{
    public class WornEquipmentViewModel : ObservableObject
    {
        private bool _show_select;
        private Equiped _player_equiped;
        private SelectEquipmentView _select_equipment;
        private string _equipment_info = "";

        public SelectEquipmentView selectEquipment
        {
            get { return _select_equipment; }
            set
            {
                _select_equipment = value;
                setEquipmentInfo();
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
        }

        public void viewSelectEquipment(string selected_slot_table)
        {
            if (_show_select)
                selectEquipment = new SelectEquipmentView(PlayerEquiped, selected_slot_table);
        }
        public void stopSelectEquipment()
        {
            selectEquipment = null;
            setEquipmentInfo();
        }

        public void setEquipmentInfo()
        {
            string Info = "";
            Info = "SlashAtk " + PlayerEquiped.getTotalSlashAtk() + "\n";
            Info += "StabAtk " + PlayerEquiped.getTotalStabAtk() + "\n";
            Info += "CrushAtk " + PlayerEquiped.getTotalCrushAtk() + "\n";
            Info += "MagicAtk " + PlayerEquiped.getTotalMagicAtk() + "\n";
            Info += "RangedAtk " + PlayerEquiped.getTotalRangedAtk() + "\n";
            Info += "SlashDef " + PlayerEquiped.getTotalSlashDef() + "\n";
            Info += "StabDef " + PlayerEquiped.getTotalStabDef() + "\n";
            Info += "CrushDef " + PlayerEquiped.getTotalCrushDef() + "\n";
            Info += "MagicDef " + PlayerEquiped.getTotalMagicDef() + "\n";
            Info += "RangedDef " + PlayerEquiped.getTotalRangedDef() + "\n";
            Info += "MeleStr " + PlayerEquiped.getTotalMeleStr() + "\n";
            Info += "MagicStr " + PlayerEquiped.getTotalMagicStr() + "\n";
            Info += "RangedStr " + PlayerEquiped.getTotalRangedStr() + "\n";
            Info += "Prayer " + PlayerEquiped.getTotalPrayer() + "\n";
            Info += "Weigth " + PlayerEquiped.getTotalWeigth() + "\n";
            EquipmentInfo = Info;
        }

        
    }

}

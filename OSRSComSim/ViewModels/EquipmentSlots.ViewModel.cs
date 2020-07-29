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
    public class EquipmentSlotsViewModel:ObservableObject
    {
        private bool _show_select;
        private Equiped _player_equiped;
        private SelectEquipmentView _select_equipment;
        private string _equipment_info = "";

        public SelectEquipmentView selectEquipment 
        {
            get { return _select_equipment; }
            set{
                _select_equipment = value;
                setEquipmentInfo();
                OnPropertyChanged("selectEquipment");
            }
        }
        public Equiped PlayerEquiped
        {
            get{ return _player_equiped; }
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
        public Position PositionEquipmentInfo { get; set; }

        public EquipmentSlotsViewModel(Equiped player_equiped = null, bool show_select = false)
        {

            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new Equiped();
            selectEquipment = null;
            _show_select = show_select;
            setEqpInfoPos();
            setEquipmentInfo();
        }

        public void viewSelectEquipment(string selected_slot_table)
        {
            if(_show_select)
                selectEquipment = new SelectEquipmentView(PlayerEquiped,selected_slot_table);
        }
        public void stopSelectEquipment()
        {
            selectEquipment = null;
            setEquipmentInfo();
        }

        public void setEquipmentInfo()
        {
            string Info = "";
            Info = "SlashAtk "  + PlayerEquiped.getTotalSlashAtk() + "\n";
            Info += "StabAtk "  + PlayerEquiped.getTotalStabAtk() + "\n";
            Info += "CrushAtk " + PlayerEquiped.getTotalCrushAtk() + "\n";
            Info += "MagicAtk " + PlayerEquiped.getTotalMagicAtk() + "\n";
            Info += "RangedAtk "+ PlayerEquiped.getTotalRangedAtk() + "\n";
            Info += "SlashDef " + PlayerEquiped.getTotalSlashDef() + "\n";
            Info += "StabDef "  + PlayerEquiped.getTotalStabDef() + "\n";
            Info += "CrushDef " + PlayerEquiped.getTotalCrushDef() + "\n";
            Info += "MagicDef " + PlayerEquiped.getTotalMagicDef() + "\n";
            Info += "RangedDef "+ PlayerEquiped.getTotalRangedDef() + "\n";
            Info += "MeleStr "  + PlayerEquiped.getTotalMeleStr() + "\n";
            Info += "MagicStr " + PlayerEquiped.getTotalMagicStr() + "\n";
            Info += "RangedStr "+ PlayerEquiped.getTotalRangedStr() + "\n";
            Info += "Prayer "   + PlayerEquiped.getTotalPrayer() + "\n";
            Info += "Weigth "   + PlayerEquiped.getTotalWeigth() + "\n";
            EquipmentInfo = Info;
        }

        private void setEqpInfoPos()
        {
            if (_show_select)
            {
                PositionEquipmentInfo = new Position
                    (
                        gridcol: 8,
                        gridro: 1,
                        colspan: 1,
                        rospan: 7,
                        W: 300,
                        H: 400
                    );
            }
            else
            {
                PositionEquipmentInfo = new Position
                (
                    gridcol: 1,
                    gridro: 11,
                    colspan: 7,
                    rospan: 1,
                    W: 500,
                    H: 100
                );
            }
        }
    }


    public struct Position
    {
        public int gridColumn { get; set; }
        public int gridRow { get; set; }
        public int columnSpan { get; set; }
        public int rowSpan { get; set; }
        public int Heigth { get; set; }
        public int Width { get; set; }

        public Position(int gridcol, int gridro, int colspan, int rospan, int H, int W)
        {
            gridColumn = gridcol;
            gridRow = gridro;
            columnSpan = colspan;
            rowSpan = rospan;
            Heigth = H;
            Width = W;             
        }
    }

}

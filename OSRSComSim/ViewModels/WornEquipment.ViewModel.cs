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
        private string we_mode = "";



        public object View { get; set; }
        public EquipedModel PlayerEquiped { get; set; }
        public SelectItemViewModel selectEquipmentViewModel { get; set; }
        public string EquipmentInfo { get; set; } = "";

        public WornEquipmentViewModel() : this(null, "Edit") { }
        public WornEquipmentViewModel(EquipedModel player_equiped = null, string we_mode = "Edit")
        {
            this.we_mode = we_mode;

            if (player_equiped != null)
            {
                PlayerEquiped = player_equiped;
            }
            else PlayerEquiped = new EquipedModel();
            
            selectEquipmentViewModel = null;
            
            if (we_mode == "Edit" || we_mode == "Create")
            {
                selectEquipmentViewModel = new SelectItemViewModel();
            }
            setEquipmentInfo();

            View = new WornEquipmentView(this);
        }

        public void manageEquipment(string selected_slot_table, bool mount = false)
        {
            this.selected_slot_table = selected_slot_table;
            if (mount)
            {
                if (we_mode == "Edit" || we_mode == "Create")
                    selectEquipment();
            }
            else
            {
                if (we_mode == "Interactive")
                {
                    if(EquipedModel.throwSuccesfulyEqpToInv(PlayerEquiped,EquipedModel.getEqp(PlayerEquiped, selected_slot_table)))
                    {
                        deselectEquipment();
                    }
                }
                if (we_mode == "Edit" || we_mode == "Create") deselectEquipment();
                setEquipmentInfo();
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
        } //temporary, for debuging.
        public void selectEquipment()
        {
            selectEquipmentViewModel = new SelectItemViewModel(PlayerEquiped, selected_slot_table, selected_slot_table);
        }
        public void deselectEquipment()
        {
            EquipedModel.demountEqp(PlayerEquiped, selected_slot_table);
        }
    }
}

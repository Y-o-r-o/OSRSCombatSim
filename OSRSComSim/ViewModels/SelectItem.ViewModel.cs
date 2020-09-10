using OSRSComSim.Models;
using OSRSComSim.Models.Items;
using OSRSComSim.Models.Items.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace OSRSComSim.ViewModels
{
    public class SelectItemViewModel: ObservableObject
    {
        public string[] _lines;
        private EquipedModel player_equiped;

        public object View { get; set; }

        public string SelectedItemType { get; set; }

        public IEnumerable<string> ReadCSV
        {
            get
            {
                if (SelectedItemType != null)
                    return _lines.Select(line =>
                    {
                        return line.Split(',').Skip(1).FirstOrDefault();
                    });
                else return null;
            }
        }

        public SelectItemViewModel() : this(null, null, true) { }
        public SelectItemViewModel(EquipedModel player_equiped = null, string selected_slot = null, bool view = true)
        {
            this.player_equiped = player_equiped;

            SelectedItemType = selected_slot;
            _lines = getCSV(selected_slot);

            if(view) View = new SelectItemView(this);
        }
        
        private string getEquipmentData(string equipment_name)
        {
            int i = 0;
            foreach (string eqp in _lines)
            {
                i++;
                if (eqp.Contains(equipment_name))
                {
                    return eqp;
                }
            }
            return "";
        }
        private string[] getCSV(string selected_slot)
        {
            string[] lines = null;
            switch (selected_slot)
            {
                case "Head":
                    lines = Properties.Resources.Head.Split('\n');
                    break;
                case "Neck":
                    lines = Properties.Resources.Neck.Split('\n');
                    break;
                case "Cape":
                    lines = Properties.Resources.Cape.Split('\n');
                    break;
                case "Ammo":
                    lines = Properties.Resources.Ammo.Split('\n');
                    break;
                case "Weapon":
                    lines = Properties.Resources.Weapon.Split('\n');
                    break;
                case "Body":
                    lines = Properties.Resources.Body.Split('\n');
                    break;
                case "Shield":
                    lines = Properties.Resources.Shield.Split('\n');
                    break;
                case "Legs":
                    lines = Properties.Resources.Legs.Split('\n');
                    break;
                case "Feet":
                    lines = Properties.Resources.Feet.Split('\n');
                    break;
                case "Hands":
                    lines = Properties.Resources.Hands.Split('\n');
                    break;
                case "Ring":
                    lines = Properties.Resources.Ring.Split('\n');
                    break;
                default:
                    /*All lines++
                    lines = Properties.Resources.Food.Split('\n');
                    lines = Properties.Resources.Potions.Split('\n');
                    lines = Properties.Resources.Runes.Split('\n');
                    */
                    break;
            }
            if (SelectedItemType != null)
            {
                lines = lines.Skip(1).ToArray();
                lines = lines.Take(lines.Count() - 1).ToArray();
            }
            return lines;
        }
        private int getFirstNumberFromString(string str)
        {
            return Int32.Parse(Regex.Match(str, @"\d+").Value);
        }

        public void select(string equipment_name) //exmp: inv_item_0 ... 27
        {
            switch (SelectedItemType)
            {
                case "Head":
                    player_equiped.Head = new EquipmentModel("Head", getEquipmentData(equipment_name));
                    break;
                case "Neck":
                    player_equiped.Neck = new EquipmentModel("Neck", getEquipmentData(equipment_name));
                    break;
                case "Cape":
                    player_equiped.Cape = new EquipmentModel("Cape", getEquipmentData(equipment_name));
                    break;
                case "Ammo":
                    player_equiped.Ammo = new EquipmentModel("Ammo", getEquipmentData(equipment_name));
                    break;
                case "Weapon":
                    player_equiped.Weapon = new WeaponModel(getEquipmentData(equipment_name));
                    if (player_equiped.Weapon.is_two_handed) player_equiped.Shield = new EquipmentModel("Shield");
                    break;
                case "Body":
                    player_equiped.Body = new EquipmentModel("Body", getEquipmentData(equipment_name));
                    break;
                case "Shield":
                    player_equiped.Shield = new EquipmentModel("Shield", getEquipmentData(equipment_name));
                    if (player_equiped.Weapon.is_two_handed) player_equiped.Weapon = new WeaponModel();
                    break;
                case "Legs":
                    player_equiped.Legs = new EquipmentModel("Legs", getEquipmentData(equipment_name));
                    break;
                case "Feet":
                    player_equiped.Feet = new EquipmentModel("Feet", getEquipmentData(equipment_name));
                    break;
                case "Hands":
                    player_equiped.Hands = new EquipmentModel("Hands", getEquipmentData(equipment_name));
                    break;
                case "Ring":
                    player_equiped.Ring = new EquipmentModel("Ring", getEquipmentData(equipment_name));
                    break;
                default:
                    selectForInventory();
                    break;
            }
        }

        public void selectForInventory()
        {
            player_equiped.InventoryItem[getFirstNumberFromString(SelectedItemType)] = new ItemModel(); //////
        }

        public void deselect()
        {
            switch (SelectedItemType)
            {
                case "Head":
                    player_equiped.Head = new EquipmentModel("Head");
                    break;
                case "Neck":
                    player_equiped.Neck = new EquipmentModel("Neck");
                    break;
                case "Cape":
                    player_equiped.Cape = new EquipmentModel("Cape");
                    break;
                case "Ammo":
                    player_equiped.Ammo = new EquipmentModel("Ammo");
                    break;
                case "Weapon":
                    player_equiped.Weapon = new WeaponModel();
                    break;
                case "Body":
                    player_equiped.Body = new EquipmentModel("Body");
                    break;
                case "Shield":
                    player_equiped.Shield = new EquipmentModel("Shield");
                    break;
                case "Legs":
                    player_equiped.Legs = new EquipmentModel("Legs");
                    break;
                case "Feet":
                    player_equiped.Feet = new EquipmentModel("Feet");
                    break;
                case "Hands":
                    player_equiped.Hands = new EquipmentModel("Hands");
                    break;
                case "Ring":
                    player_equiped.Ring = new EquipmentModel("Ring");
                    break;
                default:
                    player_equiped.InventoryItem[getFirstNumberFromString(SelectedItemType)] = new ItemModel(); //////
                    break;
            }
        }

        public void stopView()
        {
            //_wornequipmentviewmodel.selectEquipmentViewModel = null;
        }
    }
}

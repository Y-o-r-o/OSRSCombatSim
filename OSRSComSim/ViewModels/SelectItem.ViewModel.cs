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

        public string SelectedItemSlotName { get; set; }

        public IEnumerable<string> ReadCSV
        {
            get
            {
                if (SelectedItemSlotName != "")
                    return _lines.Select(line =>
                    {
                        return line.Split(',').Skip(1).FirstOrDefault();
                    });
                else return null;
            }
        }

        public SelectItemViewModel() : this(null, "", true) { }
        public SelectItemViewModel(EquipedModel player_equiped = null, string selected_slot = "", bool view = true)
        {
            this.player_equiped = player_equiped;

            SelectedItemSlotName = selected_slot;
            _lines = getCSV(selected_slot);


            if(view) View = new SelectItemView(this);
        }
        
        private string getItemData(string equipment_name)
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
            if (selected_slot.Contains("Head"))
                lines = Properties.Resources.Head.Split('\n');
            if (selected_slot.Contains("Neck"))
                lines = Properties.Resources.Neck.Split('\n');
            if (selected_slot.Contains("Cape"))
                lines = Properties.Resources.Cape.Split('\n');
            if (selected_slot.Contains("Ammo"))
                lines = Properties.Resources.Ammo.Split('\n');
            if (selected_slot.Contains("Weapon"))
                lines = Properties.Resources.Weapon.Split('\n');
            if (selected_slot.Contains("Body"))
                lines = Properties.Resources.Body.Split('\n');
            if (selected_slot.Contains("Shield"))
                lines = Properties.Resources.Shield.Split('\n');
            if (selected_slot.Contains("Legs"))
                lines = Properties.Resources.Legs.Split('\n');
            if (selected_slot.Contains("Feet"))
                lines = Properties.Resources.Feet.Split('\n');
            if (selected_slot.Contains("Handds"))
                lines = Properties.Resources.Hands.Split('\n');
            if (selected_slot.Contains("Ring"))
                lines = Properties.Resources.Ring.Split('\n');
            if (selected_slot.Contains("Food"))
                lines = Properties.Resources.Food.Split('\n');
            if (selected_slot.Contains("Potions"))
                lines = Properties.Resources.Potions.Split('\n');
            if (selected_slot.Contains("Runes"))
                lines = Properties.Resources.Runes.Split('\n');
            
            if (SelectedItemSlotName != "")
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
            switch (SelectedItemSlotName)
            {
                case "Head":
                    player_equiped.Head = new EquipmentModel("Head", getItemData(equipment_name));
                    break;
                case "Neck":
                    player_equiped.Neck = new EquipmentModel("Neck", getItemData(equipment_name));
                    break;
                case "Cape":
                    player_equiped.Cape = new EquipmentModel("Cape", getItemData(equipment_name));
                    break;
                case "Ammo":
                    player_equiped.Ammo = new EquipmentModel("Ammo", getItemData(equipment_name));
                    break;
                case "Weapon":
                    player_equiped.Weapon = new WeaponModel(getItemData(equipment_name));
                    if (player_equiped.Weapon.is_two_handed) player_equiped.Shield = new EquipmentModel("Shield");
                    break;
                case "Body":
                    player_equiped.Body = new EquipmentModel("Body", getItemData(equipment_name));
                    break;
                case "Shield":
                    player_equiped.Shield = new EquipmentModel("Shield", getItemData(equipment_name));
                    if (player_equiped.Weapon.is_two_handed) player_equiped.Weapon = new WeaponModel();
                    break;
                case "Legs":
                    player_equiped.Legs = new EquipmentModel("Legs", getItemData(equipment_name));
                    break;
                case "Feet":
                    player_equiped.Feet = new EquipmentModel("Feet", getItemData(equipment_name));
                    break;
                case "Hands":
                    player_equiped.Hands = new EquipmentModel("Hands", getItemData(equipment_name));
                    break;
                case "Ring":
                    player_equiped.Ring = new EquipmentModel("Ring", getItemData(equipment_name));
                    break;
                default:
                    selectForInventory(equipment_name);
                    break;
            }
        }
        public void selectForInventory(string equipment_name)
        {
            int inv_idx = getFirstNumberFromString(SelectedItemSlotName);

            string item_data = getItemData(equipment_name);
            string item_type = item_data.Split(',')[0];

            switch (item_type)
            {
                case "Equipment":
                    player_equiped.InventoryItem[inv_idx] = new EquipmentModel(SelectedItemSlotName, item_data);
                    break;
                case "Weapon":
                    player_equiped.InventoryItem[inv_idx] = new WeaponModel(item_data);
                    break;
                case "Food":
                    player_equiped.InventoryItem[inv_idx] = new FoodModel();
                    break;
                case "Potion":
                    player_equiped.InventoryItem[inv_idx] = new PotionModel();
                    break;
                case "Runes":
                    player_equiped.InventoryItem[inv_idx] = new RunesModel();
                    break;
            }
        
        }
        public void deselect()
        {
            switch (SelectedItemSlotName)
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
                    player_equiped.InventoryItem[getFirstNumberFromString(SelectedItemSlotName)] = new ItemModel(); //////
                    break;
            }
        }







    }
}

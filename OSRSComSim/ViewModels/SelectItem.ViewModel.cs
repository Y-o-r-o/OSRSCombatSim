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

        public string ItemsToSelect { get; set; }
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

        public SelectItemViewModel() : this(null, "", "", true) { }
        public SelectItemViewModel(EquipedModel player_equiped = null, string selected_slot = "", string items_to_select = "", bool view = true)
        {
            this.player_equiped = player_equiped;

            SelectedItemSlotName = selected_slot;
            ItemsToSelect = items_to_select;

            _lines = getCSV();


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
        private string[] getCSV()
        {
            string[] lines = new string[0];
            if (ItemsToSelect.Contains("Head")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Head.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Neck")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Neck.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Cape")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Cape.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Ammo")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Ammo.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Weapon")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Weapon.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Body")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Body.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Shield")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Shield.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Legs")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Legs.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Feet")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Feet.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Hands")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Hands.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Ring")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Ring.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Food")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Food.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Potions")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Potions.Split('\n'))).ToArray();
            }
            if (ItemsToSelect.Contains("Runes")){
                lines = lines.Concat(skipFirstAndLastLines(Properties.Resources.Runes.Split('\n'))).ToArray();
            }
            return lines;
        }
        private string[] skipFirstAndLastLines(string[] lines)
        {
            lines = lines.Skip(1).ToArray();
            lines = lines.Take(lines.Count() - 1).ToArray();
            return lines;
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
            object equipment;
            int inv_idx = String_functions.getFirstNumberFromString(SelectedItemSlotName);

            string item_data = getItemData(equipment_name);
            string item_type = item_data.Split(',')[0];

            switch (item_type)
            {
                case "Weapon":
                    equipment = new WeaponModel(item_data);
                    break;
                case "Food":
                    equipment = new FoodModel(item_data);
                    break;
                case "Potions":
                    equipment = new PotionModel(item_data);
                    break;
                case "Runes":
                    equipment = new RunesModel(item_data);
                    break;
                default:
                    equipment = new EquipmentModel(item_type, item_data);
                    break;
            }
            player_equiped.InventoryItem[inv_idx] = equipment;
        }

        public static void deselect(EquipedModel player_equiped, string selected_slot)
        {
            switch (selected_slot)
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
                    player_equiped.InventoryItem[String_functions.getFirstNumberFromString(selected_slot)] = new ItemModel(); //////
                    break;
            }
        }


    }
}

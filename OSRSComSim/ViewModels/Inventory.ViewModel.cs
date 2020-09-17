using OSRSComSim.Models;
using OSRSComSim.Models.Items;
using OSRSComSim.Models.Items.Equipments;
using OSRSComSim.Views;
using System;
using System.Runtime.Remoting.Messaging;

namespace OSRSComSim.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private const string add_sign_png = "../Resources/add.png";

        private SelectItemViewModel _item_select;

        private string inv_mode;

        public object View { get; set; }
        
        public PlayerModel Player { get; set; }
        public EquipedModel PlayerEquiped { get; set; }
        public string[] AddPng { get; set; }
       
        public SelectItemViewModel ItemSelect
        {
            get { return _item_select; }
            set
            {
                _item_select = value;
                OnPropertyChanged("ItemSelect");
            }
        }


        public InventoryViewModel() : this(null, "Edit") { }
        public InventoryViewModel(PlayerModel player, string inv_mode)
        {
            this.Player = player;
            this.PlayerEquiped = player.Equiped;
            this.inv_mode = inv_mode;
            AddPng = new string[28];

            setItemAddPng();

            View = new InventoryView(this);
        }

        public void slotClicked(string slot_name) 
        {
            if (inv_mode == "Edit" || inv_mode == "Create")
            {
                selectItem(slot_name);
            }
            else if (inv_mode == "Interactive")
            {
                useItem(slot_name);    
            }
        }
        public void setItemAddPng()
        {
            if (inv_mode == "Edit" || inv_mode == "Create")
            {
                for (int i = 0; i < PlayerEquiped.InventoryItem.Count; i++)
                {
                    if (PlayerEquiped.InventoryItem[i].GetType().ToString().Contains("ItemModel"))
                    {
                        AddPng[i] = add_sign_png;
                    }
                    else AddPng[i] = null;
                }
                OnPropertyChanged("AddPng");
            }
        }
        private void selectItem(string slot_name)
        {
            string items_to_select = "Head, Neck, Cape, Ammo, Weapon, Body, Shield, Legs, Feet, Hands, Ring, Food, Runes, Potions";
            deselectItem(slot_name);
            ItemSelect = new SelectItemViewModel(PlayerEquiped, slot_name, items_to_select);
        }
        private void deselectItem(string slot_name)
        {
            EquipedModel.demountEqp(PlayerEquiped, slot_name);
            setItemAddPng();
        }
        private void useItem(string slot_name)
        {
            int slot_idx = String_functions.getFirstNumberFromString(slot_name);
            object item = PlayerEquiped.InventoryItem[slot_idx];
            string item_type = ItemModel.getItemType(item as ItemModel);

            switch (item_type)
            {
                case "Equipment":
                    mountEquipment(item, slot_idx);
                    break;
                case "Food":
                    eatFood((item as FoodModel), slot_idx);
                    break;
                default: 
                    break;
            }
        }
        private void mountEquipment(object item, int slot_idx)
        {
            string equipment_type = (item as EquipmentModel).ItemType;
            object already_mounted_equipment = EquipedModel.getEqp(PlayerEquiped, equipment_type);
            if (!(already_mounted_equipment as ItemModel).Name.Equals("") && !(already_mounted_equipment as ItemModel).Name.Equals("Unarmed"))
                PlayerEquiped.InventoryItem[slot_idx] = already_mounted_equipment;
            else deselectItem(slot_idx.ToString());
            EquipedModel.mountEqp(PlayerEquiped, item);
        }
        private void eatFood(FoodModel item, int slot_idx)
        {
            StatusModel.heal(Player.Status, item.HPHeals);
            deselectItem(slot_idx.ToString());
        }
    }
}

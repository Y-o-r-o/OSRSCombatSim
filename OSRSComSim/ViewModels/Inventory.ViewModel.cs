using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Runtime.Remoting.Messaging;

namespace OSRSComSim.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private const string add_sign_png = "../Resources/add.png";

        private string inv_mode;

        private string[] _add_png;

        private EquipedModel _player_equiped;
        private SelectItemViewModel _item_select;

        public EquipedModel PlayerEquiped
        {
            get { return _player_equiped; }
            set
            {
                _player_equiped = value;
                OnPropertyChanged("PlayerEquiped");
            }
        }
        public SelectItemViewModel ItemSelect
        {
            get { return _item_select; }
            set
            {
                _item_select = value;
                OnPropertyChanged("ItemSelect");
            }
        }
        public string[] AddPng
        {
            get { return _add_png; }
            set
            {
                _add_png = value;
                OnPropertyChanged("AddPng");
            }
        }

        public object View { get; set; }

        public InventoryViewModel() : this(null, "Edit") { }
        public InventoryViewModel(EquipedModel player_equiped, string inv_mode)
        {
            this.PlayerEquiped = player_equiped;
            this.inv_mode = inv_mode;
            AddPng = new string[28];

            if (inv_mode == "Edit" || inv_mode == "Create") setItemAddPng();

            View = new InventoryView(this);
        }

        public void slotClicked(string slot_name) 
        {
            if (inv_mode == "Edit" || inv_mode == "Create")
            {
                selectItem(slot_name);
            }
        }
        public void setItemAddPng()
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
        private void selectItem(string slot_name)
        {
            string items_to_select = "Head, Neck, Cape, Ammo, Weapon, Body, Shield, Legs, Feet, Hands, Ring, Food, Runes, Potions";
            
            SelectItemViewModel.deselect(PlayerEquiped, slot_name);
            ItemSelect = new SelectItemViewModel(PlayerEquiped, slot_name, items_to_select);
        }


    }
}

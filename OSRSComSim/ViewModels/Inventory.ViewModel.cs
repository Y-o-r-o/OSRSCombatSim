using OSRSComSim.Models;
using OSRSComSim.Views;
using System;

namespace OSRSComSim.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private const string add_sign_png = "../Resources/add.png";

        private string inv_mode;


        private ItemModel[] _inventory_item;
        private string[] _slot_png;
        private SelectItemViewModel _item_select;

        public ItemModel[] InventoryItem
        {
            get { return _inventory_item; }
            set
            {
                _inventory_item = value;
                OnPropertyChanged("InventoryItem");
            }
        }
        public string[] SlotPng
        {
            get { return _slot_png; }
            set
            {
                _slot_png = value;
                OnPropertyChanged("SlotPng");
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

        public InventoryView View { get; set; }

        public InventoryViewModel() : this(null, "Edit") { }
        public InventoryViewModel(ItemModel[] InventoryItem, string inv_mode)
        {
            this.InventoryItem = InventoryItem;
            this.inv_mode = inv_mode;

            SlotPng = new string[InventoryItem.Length];
            setSlotPngs();


            View = new InventoryView(this);
        }





        private void setSlotPngs()
        {
            for (int i = 0; i < InventoryItem.Length; i++)
            {
                if (InventoryItem[i].Name == "")
                    setEmptySlotPng(i);
                else
                    SlotPng[i] = InventoryItem[i].Png;
            }
        }
        private void setEmptySlotPng(int idx)
        {
            if (inv_mode == "View" || inv_mode == "Interactive")
                SlotPng[idx] = null;
            else
                SlotPng[idx] = add_sign_png;
        }
    }
}

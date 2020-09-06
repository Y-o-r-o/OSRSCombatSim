using OSRSComSim.Models;
using OSRSComSim.Views;
using System;

namespace OSRSComSim.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        private ItemModel[] _inventory_item;
        
        public ItemModel[] InventoryItem
        {
            get { return _inventory_item; }
            set
            {
                _inventory_item = value;
                OnPropertyChanged("InventoryItem");
            }
        }

        public InventoryView View { get; set; }

        public InventoryViewModel() : this(null) { }
        public InventoryViewModel(ItemModel[] InventoryItem)
        {
            this.InventoryItem = InventoryItem;
            View = new InventoryView(this);
        }

    }
}

using OSRSComSim.Models;
using OSRSComSim.Views;
using System;

namespace OSRSComSim.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        public InventoryView View { get; set; }

        //public WornEquipmentViewModel() : this() { }
        public InventoryViewModel()
        {

            View = new InventoryView(this);
        }

    }
}

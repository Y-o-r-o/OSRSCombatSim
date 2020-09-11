using OSRSComSim.ViewModels;
using System;
using System.Windows.Controls;


namespace OSRSComSim.Views
{
    public partial class InventoryView : UserControl
    {

        public InventoryViewModel view_model;

        public InventoryView(InventoryViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void Slot_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            view_model.slotClicked((sender as Button).Tag.ToString());
        }
    }
}

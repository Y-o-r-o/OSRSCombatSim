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
    }
}

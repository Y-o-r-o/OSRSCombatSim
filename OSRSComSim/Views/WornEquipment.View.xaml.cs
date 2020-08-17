using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    public partial class WornEquipmentView : UserControl
    {

        public WornEquipmentViewModel view_model;

        public WornEquipmentView(WornEquipmentViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void Slot_Clicked(object sender, RoutedEventArgs e)
        {
            view_model.manageEquipment(((Button)sender).Tag.ToString(), ((((Button)sender).Content) as Image).Source.ToString().Contains("slot"));
        }

    }
}

using OSRSComSim.Models;
using OSRSComSim.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSRSComSim.Views
{
    /// <summary>
    /// Interaction logic for EquipmentSlots.xaml
    /// </summary>
    public partial class EquipmentSlotsView : UserControl
    {

        public EquipmentSlotsViewModel view_model;

        public EquipmentSlotsView(Equiped player_equiped = null, bool view_mode = false)
        {
            InitializeComponent();
            DataContext = new EquipmentSlotsViewModel(player_equiped, view_mode);
            view_model = DataContext as EquipmentSlotsViewModel;
        }

        private void Slot_Clicked(object sender, RoutedEventArgs e)
        {
            view_model.viewSelectEquipment(((Button)sender).Tag.ToString());
        }


        private void show_equipment_select_mouse_leave(object sender, object e)
        {
            view_model.stopSelectEquipment();
        }
    }
}

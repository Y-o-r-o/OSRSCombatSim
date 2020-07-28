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
        public EquipmentSlotsView(Equiped player_equiped = null)
        {
            InitializeComponent();
            DataContext = new EquipmentSlotsViewModel(player_equiped);
            view_model = DataContext as EquipmentSlotsViewModel;
        }

        private void Slot_Clicked(object sender, RoutedEventArgs e)
        {
            view_model.SelectedSlotTable = ((Button)sender).Tag.ToString();
        }

        private void equipment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

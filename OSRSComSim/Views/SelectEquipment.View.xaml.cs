using OSRSComSim.Models;
using System;
using System.Collections.Generic;
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

namespace OSRSComSim.ViewModels
{
    /// <summary>
    /// Interaction logic for SelectEquipmentView.xaml
    /// </summary>
    public partial class SelectEquipmentView : UserControl
    {
        public SelectEquipmentViewModel view_model;
        public SelectEquipmentView(Equiped player_equiped, string selectedslottable)
        {
            InitializeComponent();
            DataContext = new SelectEquipmentViewModel(player_equiped, selectedslottable);
            view_model = DataContext as SelectEquipmentViewModel;
        }



        private void equipment_Click(object sender, RoutedEventArgs e)
        {
            view_model.mountEquipment(((Label)sender).Content.ToString());
            select.Visibility = Visibility.Hidden;
        }

    }
}

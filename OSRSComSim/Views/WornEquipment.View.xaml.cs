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
            view_model.viewSelectEquipment(((Button)sender).Tag.ToString());
        }

    }
}

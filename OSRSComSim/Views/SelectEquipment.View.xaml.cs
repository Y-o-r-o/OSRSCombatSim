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
    public partial class SelectEquipmentView : UserControl
    {
        public SelectEquipmentViewModel view_model;
        public SelectEquipmentView(SelectEquipmentViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void equipment_Click(object sender, RoutedEventArgs e)
        {
            view_model.mountEquipment(((Label)sender).Content.ToString());
            view_model.stopView();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            view_model.stopView();
        }
    }
}

using OSRSComSim.Models;
using OSRSComSim.ViewModels;
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

namespace OSRSComSim.Views
{
    
    public partial class ControlPanelView : UserControl
    {
        public ControlPanelViewModel view_model;
        public ControlPanelView(LoadScreenViewModel loadscreenVM = null, Player player = null, string cp_mode = "View")
        {
            InitializeComponent();
            DataContext = new ControlPanelViewModel(loadscreenVM, player, cp_mode);
         }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            view_model = (ControlPanelViewModel)DataContext;
        }



        private void ViewContents_Click(object sender, RoutedEventArgs e)
        {
            view_model.setViewMode((sender as Button).Tag.ToString());
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            view_model.Create();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            view_model.backToLoadScreen();
        }
    }
}

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
    
    public partial class CreatePlayerView : UserControl
    {
        CreatePlayerViewModel view_model;
        public CreatePlayerView(LoadScreenViewModel loadscreenVM, Player player = null)
        {
            InitializeComponent();
            DataContext = new CreatePlayerViewModel(loadscreenVM, player);
         }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            view_model = (CreatePlayerViewModel)DataContext;
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

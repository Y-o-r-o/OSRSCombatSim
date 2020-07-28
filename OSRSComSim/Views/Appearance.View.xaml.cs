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
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class AppearanceView : UserControl
    {
        public AppearanceViewModel view_model;
        public AppearanceView(Player player)
        {
            InitializeComponent();
            DataContext = new AppearanceViewModel(player);
            view_model = DataContext as AppearanceViewModel;
        }

        private void EnterNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EnterNameBox.Text = "";
            EnterNameBox.FontSize = 30;
        }

        private void CaptureName_Btn_Click(object sender, RoutedEventArgs e)
        {
            view_model.setPlayerName(EnterNameBox.Text);
        }

    }
}

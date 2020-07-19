using System;
using System.Diagnostics;
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

using OSRSComSim.Models;
using OSRSComSim.ViewModels;
using OSRSComSim.Views;

namespace OSRSComSim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel view_model;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Load_Screen_loaded(object sender, RoutedEventArgs e)
        {
            view_model = DataContext as MainWindowViewModel;
        }

        private void Button_Load_1_Click(object sender, RoutedEventArgs e)
        {
            view_model.viewLoadScreen("fighter 1");
        }

        private void Button_Load_2_Click(object sender, RoutedEventArgs e)
        {
            view_model.viewLoadScreen("fighter 2");
        }

        private void Button_Fight_Click(object sender, RoutedEventArgs e)
        {
            view_model.Battle.StartFight();
        }
    }
}

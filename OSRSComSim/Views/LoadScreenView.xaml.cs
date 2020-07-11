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
using OSRSComSim.Models;
using OSRSComSim.ViewModels;

namespace OSRSComSim.Views
{
    /// <summary>
    /// Interaction logic for LoadScreenView.xaml
    /// </summary>
    public partial class LoadScreenView : UserControl
    {
        private LoadScreenViewModel view_model;

        public LoadScreenView(MainWindowViewModel mainWindowVM, string fighter_num)
        {
            InitializeComponent();

            DataContext = new LoadScreenViewModel(mainWindowVM, fighter_num);
            view_model = DataContext as LoadScreenViewModel;

        }



        private void Btn_create_new_Click(object sender, RoutedEventArgs e)
        {
            view_model.viewCreatePlayer();
        }
        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            view_model.Back_to_main_screen();
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            view_model.delete_player((sender as Button).Tag as string);
        }

        private void PlayerBorder_Click(object sender, MouseButtonEventArgs e)
        {
            view_model.SelectedPlayer = ((Border)sender).Tag.ToString();
        }

        private void button_select_Click(object sender, RoutedEventArgs e)
        {
            view_model.loadSelectedFighter(SelectedPlayer.Text);
        }
    }
}

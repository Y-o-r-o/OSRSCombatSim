using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OSRSComSim.ViewModels;

namespace OSRSComSim.Views
{
    public partial class LoadScreenView : UserControl
    {
        private LoadScreenViewModel view_model;

        public LoadScreenView(LoadScreenViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;

            InitializeComponent();
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
            view_model.getPlayer(((Button)sender).Tag.ToString());
            view_model.viewEditPlayer();
        }
        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            view_model.delete_player((sender as Button).Tag as string);
        }
        private void PlayerBorder_Click(object sender, MouseButtonEventArgs e)
        {
            view_model.getPlayer(((Border)sender).Tag.ToString());
        }
        private void button_select_Click(object sender, RoutedEventArgs e)
        {
            view_model.loadSelectedFighter();
        }
    }
}

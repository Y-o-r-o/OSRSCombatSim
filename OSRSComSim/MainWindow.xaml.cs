using System.Windows;
using OSRSComSim.ViewModels;

namespace OSRSComSim
{
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
            view_model.Battle.start_stopFight();
        }
    }
}

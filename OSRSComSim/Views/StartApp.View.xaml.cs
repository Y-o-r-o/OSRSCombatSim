using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;


namespace OSRSComSim.Views
{
    /// <summary>
    /// Interaction logic for StartApp.xaml
    /// </summary>
    public partial class StartAppView : UserControl
    {
        StartAppViewModel view_model;

        public StartAppView()
        {

            InitializeComponent();
        }
        private void Load_Screen_loaded(object sender, RoutedEventArgs e)
        {
            view_model = DataContext as StartAppViewModel;
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

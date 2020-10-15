using System.Windows;
using OSRSComSim.ViewModels;
using OSRSComSim.Views;

namespace OSRSComSim
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
        }
    }
}

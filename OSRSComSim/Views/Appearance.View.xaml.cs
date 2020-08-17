using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    /// <summary>
    /// Interaction logic for Appearance.xaml
    /// </summary>
    public partial class AppearanceView : UserControl
    {
        public AppearanceViewModel view_model;
        public AppearanceView(AppearanceViewModel VM)
        {
            view_model = VM;
            DataContext = VM;
            InitializeComponent();
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

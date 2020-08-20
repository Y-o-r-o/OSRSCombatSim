using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    public partial class CombatOptionsView : UserControl
    {

        private CombatOptionsViewModel view_model;

        public CombatOptionsView(CombatOptionsViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void CombatOption_Set(object sender, RoutedEventArgs e)
        {
            view_model.setCombat(
                (((sender as RadioButton).Content as StackPanel).Children[0] as TextBlock).Text,
                (((sender as RadioButton).Content as StackPanel).Children[1] as TextBlock).Text
            );
        }
    }
}

using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    public partial class SkillsView : UserControl
    {
        private SkillsViewModel view_model;
        public SkillsView(SkillsViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            view_model.editPlayerSkills(((Button)sender).Tag.ToString(), -1);
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            view_model.editPlayerSkills(((Button)sender).Tag.ToString(), 1);
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            view_model.resetPlayerSkills();
        }

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            view_model.setRandomPlayerSkills();
        }
    }
}

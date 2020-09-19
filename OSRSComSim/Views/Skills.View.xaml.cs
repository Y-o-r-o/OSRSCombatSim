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


        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            string tag = ((Button)sender).Tag.ToString();
            view_model.editPlayerSkills(tag, String_functions.getFirstNumberFromString(tag));
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

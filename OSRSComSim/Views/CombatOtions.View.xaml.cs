using OSRSComSim.ViewModels;
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
    }
}

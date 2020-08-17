using OSRSComSim.ViewModels;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    public partial class FighterView : UserControl
    {
        public FighterViewModel view_model;

        public FighterView(FighterViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;

            InitializeComponent();
        }





    }
}

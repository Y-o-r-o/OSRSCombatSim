using OSRSComSim.Models;
using OSRSComSim.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OSRSComSim.Views
{
    public partial class CombatOptionsView : UserControl
    {

        private CombatOptionsViewModel view_model;

        public CombatOptionsView(Combat combat)
        {
            InitializeComponent();
            DataContext = new CombatOptionsViewModel(combat);
            view_model = DataContext as CombatOptionsViewModel;
        }
    }
}

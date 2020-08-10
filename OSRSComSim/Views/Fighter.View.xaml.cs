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
    public partial class FighterView : UserControl
    {
        public FighterViewModel view_model { get; set; }

        public FighterView(Player player = null)
        {
            InitializeComponent();
            DataContext = new FighterViewModel(player);
            view_model = DataContext as FighterViewModel;
        }





    }
}

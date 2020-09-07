using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.ViewModels
{
    public partial class SelectItemView : UserControl
    {
        public SelectItemViewModel view_model;
        public SelectItemView(SelectItemViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
        }

        private void equipment_Click(object sender, RoutedEventArgs e)
        {
            view_model.select(((Label)sender).Content.ToString());
            view_model.stopView();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            view_model.stopView();
        }
    }
}

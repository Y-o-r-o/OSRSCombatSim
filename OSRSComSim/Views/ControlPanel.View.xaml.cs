using OSRSComSim.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace OSRSComSim.Views
{
    
    public partial class ControlPanelView : UserControl
    {
        public ControlPanelViewModel view_model;
        public ControlPanelView(ControlPanelViewModel VM)
        {
            view_model = VM;
            DataContext = view_model;
            InitializeComponent();
         }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            view_model = (ControlPanelViewModel)DataContext;
        }



        private void ViewContents_Click(object sender, RoutedEventArgs e)
        {
            view_model.setViewMode((sender as Button).Tag.ToString());
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            view_model.Create();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            view_model.backToLoadScreen();
        }

    }
}

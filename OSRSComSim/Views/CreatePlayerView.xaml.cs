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
    
    public partial class CreatePlayerView : UserControl
    {
        CreatePlayerViewModel view_model;
        public CreatePlayerView(LoadScreenViewModel loadscreenVM)
        {
            InitializeComponent();
            DataContext = new CreatePlayerViewModel(loadscreenVM);
         }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            view_model = (CreatePlayerViewModel)DataContext;
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            Button MinusBnt = (Button)sender;

            switch (MinusBnt.Name)
            {
                case "MinusHP":
                    view_model.HPLvl--;
                    break;
                case "MinusDef":
                    view_model.DefLvl--;
                    break;
                case "MinusStr":
                    view_model.StrLvl--;
                    break;
                case "MinusAtk":
                    view_model.AtkLvl--;
                    break;
                default:
                    //throw ex
                    break;
            }

        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            Button PlusBnt = (Button)sender;

            switch (PlusBnt.Name)
            {
                case "PlusHP":
                    view_model.HPLvl++;
                    break;
                case "PlusDef":
                    view_model.DefLvl++;
                    break;
                case "PlusStr":
                    view_model.StrLvl++;
                    break;
                case "PlusAtk":
                    view_model.AtkLvl++;
                    break;
                default:
                    //throw ex
                    break;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            view_model.HPLvl = 10;
            view_model.DefLvl = 1;
            view_model.StrLvl = 1;
            view_model.AtkLvl = 1;
        }

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            view_model.HPLvl = rnd.Next(10, 100);
            view_model.DefLvl = rnd.Next(1, 100);
            view_model.StrLvl = rnd.Next(1, 100);
            view_model.AtkLvl = rnd.Next(1, 100);
        }

        private void EnterNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EnterNameBox.Text = "";
            EnterNameBox.FontSize = 30;
        }

        private void CaptureName_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!Data_store.CheckIfPlayerExists(EnterNameBox.Text))
            {
                view_model.Name = EnterNameBox.Text;
                if (view_model.Name == "No_name")
                {
                    EnterNameBox.Text = "Name length must be between 6 and 20.";
                    EnterNameBox.FontSize = 15;
                }
                else CreatePlayerTab.SelectedIndex = 1;
            }
            else
            {
                EnterNameBox.Text = "This name already exists";
                EnterNameBox.FontSize = 15;
            }
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

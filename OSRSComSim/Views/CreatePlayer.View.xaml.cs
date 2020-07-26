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
    
    public partial class CreatePlayerView : UserControl
    {
        CreatePlayerViewModel view_model;
        public CreatePlayerView(LoadScreenViewModel loadscreenVM, string name = "No_name", Stats player_stats = null)
        {
            InitializeComponent();
            DataContext = new CreatePlayerViewModel(loadscreenVM, name, player_stats);
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
                    view_model.PlayerStats.Hp_lvl--;
                    break;
                case "MinusDef":
                    view_model.PlayerStats.Def_lvl--;
                    break;
                case "MinusStr":
                    view_model.PlayerStats.Str_lvl--;
                    break;
                case "MinusAtk":
                    view_model.PlayerStats.Atk_lvl--;
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
                    view_model.PlayerStats.Hp_lvl++;
                    break;
                case "PlusDef":
                    view_model.PlayerStats.Def_lvl++;
                    break;
                case "PlusStr":
                    view_model.PlayerStats.Str_lvl++;
                    break;
                case "PlusAtk":
                    view_model.PlayerStats.Atk_lvl++;
                    break;
                default:
                    //throw ex
                    break;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            view_model.resetPlayerStats();
        }

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            view_model.setRandomPlayerStats();
        }

        private void EnterNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            EnterNameBox.Text = "";
            EnterNameBox.FontSize = 30;
        }

        private void CaptureName_Btn_Click(object sender, RoutedEventArgs e)
        {
            view_model.setPlayerName(EnterNameBox.Text);
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

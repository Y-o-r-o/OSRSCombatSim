using OSRSComSim.Models;
using OSRSComSim.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSRSComSim.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {


        private object _viewcontent;
        private string _buttonfightcontent;
         
        public BattleViewModel Battle { get; set; }
        public object ViewContent
        {
            get
            {
                return _viewcontent;
            }
            set
            {
                _viewcontent = value;
                OnPropertyChanged("ViewContent");
            }
        }
        public string ButtonFightContent
        {
            get { return _buttonfightcontent; }
            set
            {
                _buttonfightcontent = value;
                OnPropertyChanged("ButtonFightContent");
            }
        
        }

        public MainWindowViewModel()
        {
            Battle = new BattleViewModel();
            setupMainWindowViewModel();
        }

        public void setupMainWindowViewModel()
        {
            _buttonfightcontent = "Fight";
        }

        public void changeButtonFightContext()
        {
            if (ButtonFightContent == "Fight") ButtonFightContent = "Reset";
            else if (ButtonFightContent == "Reset") ButtonFightContent = "Fight";
        }

        public void viewLoadScreen(string fighter_num)
        {
            Battle.Reset();

            ViewContent = new LoadScreenView(this, fighter_num);
        }

        public void stopView()
        {
            ViewContent = null;
        }

    }
}

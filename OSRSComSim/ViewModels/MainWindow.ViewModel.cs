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

        public MainWindowViewModel()
        {
            Battle = new BattleViewModel();
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

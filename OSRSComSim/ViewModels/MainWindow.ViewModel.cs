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
            ViewContent = new LoadScreenViewModel(this, fighter_num).View;
        }

        public void stopView()
        {
            ViewContent = null;
        }

    }
}

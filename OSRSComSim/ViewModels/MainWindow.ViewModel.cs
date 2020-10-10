namespace OSRSComSim.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public BattleViewModel Battle { get; set; }

        public object ViewContent { get; set; }

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

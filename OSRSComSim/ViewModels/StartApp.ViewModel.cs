namespace OSRSComSim.ViewModels
{
    public class StartAppViewModel : ObservableObject
    {
        public BattleViewModel Battle { get; set; }

        public object ViewContent { get; set; }

        public StartAppViewModel()
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

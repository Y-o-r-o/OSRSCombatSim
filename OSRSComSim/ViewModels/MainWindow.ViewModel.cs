



using OSRSComSim.ViewModels.Base;
using OSRSComSim.Views;
using System.Windows;
using System.Windows.Input;

namespace OSRSComSim.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Private members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        #endregion
        #region Public properties

        /// <summary>
        /// View aplication
        /// </summary>
        public StartAppView appView { get; set; }
        
        #endregion
        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor
        
        public MainWindowViewModel(Window window)
        {
            mWindow = window;

            appView = new StartAppView();

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
        }

        #endregion

    }
}

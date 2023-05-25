using AssetsView.Core;

namespace AssetsView.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }
        public RelayCommand DeleteFavouriteRates { get; set; }
        public DashboardViewModel DashboardVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }
        public HelpViewModel HelpVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            DashboardVM = new DashboardViewModel();
            SettingsVM = new SettingsViewModel();
            HelpVM = new HelpViewModel();

            CurrentView = DashboardVM;
            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
            });

            HelpViewCommand = new RelayCommand(o =>
            {
                CurrentView = HelpVM;
            });
        }
    }
}

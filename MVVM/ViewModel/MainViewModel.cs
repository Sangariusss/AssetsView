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

        private bool _isDashboardSelected;
        public bool IsDashboardSelected
        {
            get { return _isDashboardSelected; }
            set
            {
                _isDashboardSelected = value;
                OnPropertyChanged();
            }
        }

        private bool _isSettingsSelected;
        public bool IsSettingsSelected
        {
            get { return _isSettingsSelected; }
            set
            {
                _isSettingsSelected = value;
                OnPropertyChanged();
            }
        }

        private bool _isHelpSelected;
        public bool IsHelpSelected
        {
            get { return _isHelpSelected; }
            set
            {
                _isHelpSelected = value;
                OnPropertyChanged();
            }
        }

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
            IsDashboardSelected = true;

            DashboardViewCommand = new RelayCommand(o =>
            {
                CurrentView = DashboardVM;
                IsDashboardSelected = true;
                IsSettingsSelected = false;
                IsHelpSelected = false;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVM;
                IsDashboardSelected = false;
                IsSettingsSelected = true;
                IsHelpSelected = false;
            });

            HelpViewCommand = new RelayCommand(o =>
            {
                CurrentView = HelpVM;
                IsDashboardSelected = false;
                IsSettingsSelected = false;
                IsHelpSelected = true;
            });
        }
    }
}

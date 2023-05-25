using System;
using System.Windows;
using System.Windows.Input;

namespace AssetsView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ConfigModel _config;
        public MainWindow()
        {
            InitializeComponent();

            string configFilePath = "config.xml";
            _config = ConfigManager.LoadConfig(configFilePath);
            SetWindowSize(_config);
        }

        private void SetWindowSize(ConfigModel settings)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (settings != null)
            {
                if (settings.IsResolutionRadioButtonChecked1)
                {
                    Width = 811;
                    Height = 1024;
                }
                else if (settings.IsResolutionRadioButtonChecked2)
                {
                    Width = 1440;
                    Height = 1024;
                }
                else if (settings.IsResolutionRadioButtonChecked3)
                {
                    Width = 1920;
                    Height = 1040;
                    mainWindow.ExitButton.Margin = new Thickness(0, 16, 0, 0);
                }
            }
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // If left mouse button is down, start dragging the window
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }
    }
}
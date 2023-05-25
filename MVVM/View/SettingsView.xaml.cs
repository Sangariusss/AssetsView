using AssetsView.Data.Languages;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AssetsView.MVVM.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {

        private ConfigModel _config;
        public SettingsView()
        {
            InitializeComponent();
            _config = ConfigManager.LoadConfig("config.xml");
            DataContext = _config;

            ThemeRadioButton1.IsChecked = _config.IsThemeRadioButtonChecked1;
            ThemeRadioButton2.IsChecked = _config.IsThemeRadioButtonChecked2;

            LanguageRadioButton1.IsChecked = _config.IsLanguageRadioButtonChecked1;
            LanguageRadioButton2.IsChecked = _config.IsLanguageRadioButtonChecked2;

            ResolutionRadioButton1.IsChecked = _config.IsResolutionRadioButtonChecked1;
            ResolutionRadioButton2.IsChecked = _config.IsResolutionRadioButtonChecked2;
            ResolutionRadioButton3.IsChecked = _config.IsResolutionRadioButtonChecked3;
        }

        private void ThemeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _config.IsThemeRadioButtonChecked1 = ThemeRadioButton1.IsChecked ?? false;
            _config.IsThemeRadioButtonChecked2 = ThemeRadioButton2.IsChecked ?? false;

            ConfigManager.SaveConfig(_config, "config.xml");
        }

        private void LanguageRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _config.IsLanguageRadioButtonChecked1 = LanguageRadioButton1.IsChecked ?? false;
            _config.IsLanguageRadioButtonChecked2 = LanguageRadioButton2.IsChecked ?? false;

            ConfigManager.SaveConfig(_config, "config.xml");

            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked == true)
            {
                string selectedLanguage = radioButton.Content.ToString();

                if (selectedLanguage == "EN")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                }
                else if (selectedLanguage == "UK")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk");
                }
            }
            HotkeysTitleTextBlock.Text = Strings.HotkeysTitle;
            SubTitleTextBlock.Text = Strings.SubTitle;
        }

        private void ResolutionRadioButton_Checked(object sender, RoutedEventArgs e)
        {

            RadioButton radioButton = (RadioButton)sender;
            if (radioButton != null && radioButton.Content != null)
            {
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                if (mainWindow != null)
                {
                    switch (radioButton.Content.ToString())
                    {
                        case "811x1024":
                            AnimateMainWindowSize(811, 1024);
                            ThemeTextBlock.Text = "Choose the theme";
                            LanguageTextBlock.Text = "Choose the language";
                            ResolutionTextBlock.Text = "Choose the resolution";
                            mainWindow.ExitButton.Margin = new Thickness(0);

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked3 = ResolutionRadioButton3.IsChecked ?? false;

                            ConfigManager.SaveConfig(_config, "config.xml");
                            break;
                        case "1440x1024":
                            AnimateMainWindowSize(1440, 1024);
                            ThemeTextBlock.Text = "Choose the theme you like";
                            LanguageTextBlock.Text = "Choose the language you are comfortable with";
                            ResolutionTextBlock.Text = "Choose the screen resolution that suits you best";
                            mainWindow.ExitButton.Margin = new Thickness(0);

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked3 = ResolutionRadioButton3.IsChecked ?? false;

                            ConfigManager.SaveConfig(_config, "config.xml");
                            break;
                        case "1920x1040":
                            AnimateMainWindowSize(1920, 1040);
                            mainWindow.Left = 0;
                            mainWindow.Top = 0;
                            mainWindow.ExitButton.Margin = new Thickness(0, 16, 0, 0);
                            ThemeTextBlock.Text = "Choose the theme you like";
                            LanguageTextBlock.Text = "Choose the language you are comfortable with";
                            ResolutionTextBlock.Text = "Choose the screen resolution that suits you best";

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked3 = ResolutionRadioButton3.IsChecked ?? false;

                            ConfigManager.SaveConfig(_config, "config.xml");
                            break;
                    }
                }
            }
        }

        private void AnimateMainWindowSize(double width, double height)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            if (mainWindow != null)
            {
                DoubleAnimation widthAnimation = new DoubleAnimation(width, TimeSpan.FromSeconds(0.35));
                Storyboard.SetTarget(widthAnimation, mainWindow);
                Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Window.WidthProperty));

                DoubleAnimation heightAnimation = new DoubleAnimation(height, TimeSpan.FromSeconds(0.001));
                Storyboard.SetTarget(heightAnimation, mainWindow);
                Storyboard.SetTargetProperty(heightAnimation, new PropertyPath(Window.HeightProperty));

                Storyboard storyboard = new Storyboard();
                storyboard.Children.Add(heightAnimation);
                storyboard.Children.Add(widthAnimation);

                mainWindow.BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, true);
            }
        }
    }
}
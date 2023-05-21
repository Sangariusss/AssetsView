using System;
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
        public bool IsRadioButtonChecked1 { get; set; }
        public bool IsRadioButtonChecked2 { get; set; }
        public bool IsRadioButtonChecked3 { get; set; }

        public SettingsView()
        {
            InitializeComponent();
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
                            IsRadioButtonChecked1 = true;
                            IsRadioButtonChecked2 = false;
                            IsRadioButtonChecked3 = false;
                            break;
                        case "1440x1024":
                            AnimateMainWindowSize(1440, 1024);
                            ThemeTextBlock.Text = "Choose the theme you like";
                            LanguageTextBlock.Text = "Choose the language you are comfortable with";
                            ResolutionTextBlock.Text = "Choose the screen resolution that suits you best";
                            mainWindow.ExitButton.Margin = new Thickness(0);
                            IsRadioButtonChecked1 = false;
                            IsRadioButtonChecked2 = true;
                            IsRadioButtonChecked3 = false;
                            break;
                        case "1920x1040":
                            AnimateMainWindowSize(1920, 1040);
                            mainWindow.Left = 0;
                            mainWindow.Top = 0;
                            mainWindow.ExitButton.Margin = new Thickness(0, 16, 0, 0);
                            ThemeTextBlock.Text = "Choose the theme you like";
                            LanguageTextBlock.Text = "Choose the language you are comfortable with";
                            ResolutionTextBlock.Text = "Choose the screen resolution that suits you best";
                            IsRadioButtonChecked1 = false;
                            IsRadioButtonChecked2 = false;
                            IsRadioButtonChecked3 = true;
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
using AssetsView.Data.Languages;
using System.Globalization;
using System.Threading;
using System.Windows.Controls;

namespace AssetsView.MVVM.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : UserControl
    {
        public HelpView()
        {
            InitializeComponent();

            if (ConfigManager.LoadConfig("config.xml").IsLanguageRadioButtonChecked1)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            else if (ConfigManager.LoadConfig("config.xml").IsLanguageRadioButtonChecked2)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk");
            }

            ReferenceTextBlock.Text = Strings.ReferenceText;
            ReferenceSubTitleTextBlock.Text = Strings.ReferenceSubTitleText;
            CurrencyConverterExpander.Header = Strings.CurrencyConverterExpanderHeader;
            CurrencyConverterExpanderText.Text = Strings.CurrencyConverterExpanderText;
            FavouriteRatesExpander.Header = Strings.FavouriteRatesExpanderHeader;
            FavouriteRatesExpanderText.Text = Strings.FavouriteRatesExpanderText;
            ChartExpander.Header = Strings.ChartExpanderHeader;
            ChartExpanderText.Text = Strings.ChartExpanderText;
            HotkeysExpander.Header = Strings.HotkeysExpanderHeader;
            HotkeysExpanderText.Text = Strings.HotkeysExpanderText;
            AssetsViewExpander.Header = Strings.AssetsViewExpanderHeader;
            AssetsViewExpanderText.Text = Strings.AssetsViewExpanderText;
            PartnerExpander.Header = Strings.PartnerExpanderHeader;
            PartnerExpanderText.Text = Strings.PartnerExpanderText;
        }
    }
}

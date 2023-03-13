using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using SkiaSharp;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace AssetsView
{
    public class ViewModel
    {
        public ISeries[] Series { get; set; }
            = new ISeries[]
            {
                new LineSeries<double>
                {
                        Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                        Fill = null,
                        Stroke = new SolidColorPaint(SKColors.LimeGreen, 3)
                    }
            };
    }

    class Rates
    {
        public string[] Countries { get; set; }
        public static bool Import()
        {
            try
            {
                String URLString = "https://v6.exchangerate-api.com/v6/1d5720012699e0c9c11b846b/latest/USD";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    Console.WriteLine(json);
                    API_Obj Test = JsonConvert.DeserializeObject<API_Obj>(json);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class CurrencyCountry
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string ImageSource { get; set; }
    }

    public class CurrencyCountryManager
    {
        public CurrencyCountry[] GetCurrencyCountries()
        {
            CurrencyCountry[] countries = new CurrencyCountry[]
            {
            new CurrencyCountry { Name = "United States dollar", CurrencyCode = "USD", ImageSource = "/USD.png" },
            new CurrencyCountry { Name = "British pound", CurrencyCode = "GBP", ImageSource = "/GBP.png" },
            new CurrencyCountry { Name = "Euro", CurrencyCode = "EUR", ImageSource = "/EUR.png" },
            new CurrencyCountry { Name = "Australian dollar", CurrencyCode = "AUD", ImageSource = "/AUD.png" },
            new CurrencyCountry { Name = "Canadian dollar", CurrencyCode = "CAD", ImageSource = "/CAd.png" },
            new CurrencyCountry { Name = "Danish krone", CurrencyCode = "DKK", ImageSource = "/DKK.png" },
            new CurrencyCountry { Name = "Hong Kong dollar", CurrencyCode = "HKD", ImageSource = "/HKD.png" },
            new CurrencyCountry { Name = "Japanese yen", CurrencyCode = "JPY", ImageSource = "/JPY.png" },
            new CurrencyCountry { Name = "New Zealand dollar", CurrencyCode = "NZD", ImageSource = "/NZD.png" },
            new CurrencyCountry { Name = "Norwegian krone", CurrencyCode = "NOK", ImageSource = "/NOK.png" },
            new CurrencyCountry { Name = "Swiss franc", CurrencyCode = "CHF", ImageSource = "/CHF.png" },
            new CurrencyCountry { Name = "Singapore dollar", CurrencyCode = "SGD", ImageSource = "/SGD.png" },
            new CurrencyCountry { Name = "Swedish krona", CurrencyCode = "SEK", ImageSource = "/SEK.png" },
            new CurrencyCountry { Name = "Saudi rial", CurrencyCode = "SAR", ImageSource = "/SAR.png" },
            new CurrencyCountry { Name = "Taiwan dollar", CurrencyCode = "TWD", ImageSource = "/TWD.png" },
            new CurrencyCountry { Name = "South African rand", CurrencyCode = "ZAR", ImageSource = "/ZAR.png" },
            new CurrencyCountry { Name = "Brazilian real", CurrencyCode = "BRL", ImageSource = "/BRL.png" },
            new CurrencyCountry { Name = "Chinese yuan", CurrencyCode = "CNY", ImageSource = "/CNY.png" },
            new CurrencyCountry { Name = "Czech koruna", CurrencyCode = "CZK", ImageSource = "/CZK.png" },
            new CurrencyCountry { Name = "Hungarian forint", CurrencyCode = "HUF", ImageSource = "/HUF.png" },
            new CurrencyCountry { Name = "Indian rupee", CurrencyCode = "INR", ImageSource = "/INR.png" },
            new CurrencyCountry { Name = "Israeili shekel", CurrencyCode = "ILS", ImageSource = "/ILS.png" },
            new CurrencyCountry { Name = "Malaysian ringgit", CurrencyCode = "MYR", ImageSource = "/MYR.png" },
            new CurrencyCountry { Name = "Polish zloty", CurrencyCode = "PLN", ImageSource = "/PLN.png" },
            new CurrencyCountry { Name = "Russian rubble", CurrencyCode = "RUB", ImageSource = "/RUB.png" },
            new CurrencyCountry { Name = "South Korean won", CurrencyCode = "KRW", ImageSource = "/KRW.png" },
            new CurrencyCountry { Name = "Thai baht", CurrencyCode = "THB", ImageSource = "/THB.png" },
            new CurrencyCountry { Name = "Turkish lira", CurrencyCode = "TRY", ImageSource = "/TRY.png" },
            };

            return countries;
        }
    }

    public class API_Obj
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_last_update_unix { get; set; }
        public string time_last_update_utc { get; set; }
        public string time_next_update_unix { get; set; }
        public string time_next_update_utc { get; set; }
        public string base_code { get; set; }
        public ConversionRate conversion_rates { get; set; }
    }

    public class ConversionRate
    {
        public double AED { get; set; }
        public double ARS { get; set; }
        public double AUD { get; set; }
        public double BGN { get; set; }
        public double BRL { get; set; }
        public double BSD { get; set; }
        public double CAD { get; set; }
        public double CHF { get; set; }
        public double CLP { get; set; }
        public double CNY { get; set; }
        public double COP { get; set; }
        public double CZK { get; set; }
        public double DKK { get; set; }
        public double DOP { get; set; }
        public double EGP { get; set; }
        public double EUR { get; set; }
        public double FJD { get; set; }
        public double GBP { get; set; }
        public double GTQ { get; set; }
        public double HKD { get; set; }
        public double HRK { get; set; }
        public double HUF { get; set; }
        public double IDR { get; set; }
        public double ILS { get; set; }
        public double INR { get; set; }
        public double ISK { get; set; }
        public double JPY { get; set; }
        public double KRW { get; set; }
        public double KZT { get; set; }
        public double MXN { get; set; }
        public double MYR { get; set; }
        public double NOK { get; set; }
        public double NZD { get; set; }
        public double PAB { get; set; }
        public double PEN { get; set; }
        public double PHP { get; set; }
        public double PKR { get; set; }
        public double PLN { get; set; }
        public double PYG { get; set; }
        public double RON { get; set; }
        public double RUB { get; set; }
        public double SAR { get; set; }
        public double SEK { get; set; }
        public double SGD { get; set; }
        public double THB { get; set; }
        public double TRY { get; set; }
        public double TWD { get; set; }
        public double UAH { get; set; }
        public double USD { get; set; }
        public double UYU { get; set; }
        public double ZAR { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string CreateIndicator(string currency1, string currency2)
        {
            string lastLetter = "";
            if (currency2 == "USD")
            {
                lastLetter = "D";
            }
            else if (currency2 == "GBP")
            {
                lastLetter = "S";
            }
            else if (currency2 == "EUR")
            {
                lastLetter = "ER";
            }

            return currency1 + lastLetter;
        }

        public string GenerateRequestUrl(string currency1, string currency2)
        {
            string indicator = CreateIndicator(currency1, currency2);
            string apiKey = "PdEA66WhL4se9otbUq7R";

            return $"https://data.nasdaq.com/api/v3/databases/BOE/XUDL{indicator}?api_key={apiKey}";
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // If left mouse button is down, start dragging the window
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonAddFavouriteRates_Click(object sender, RoutedEventArgs e)
        {
            Rates.Import();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

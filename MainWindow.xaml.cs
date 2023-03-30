using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace AssetsView
{
    public class ViewModel
    {
        // Gets or sets the chart's series
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
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly CurrencyCountryManager _currencyCountryManager;
        // Initializes a new instance of the ViewModel class
        public ViewModel()
        {
            _currencyCountryManager = new CurrencyCountryManager();
        }
        // Returns a collection of CurrencyCountry objects
        public IEnumerable<CurrencyCountry> CountrySeries
        {
            get { return _currencyCountryManager.GetCurrencyCountries(); }
        }
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
        // Returns an array of CurrencyCountry objects
        public CurrencyCountry[] GetCurrencyCountries()
        {
            CurrencyCountry[] countries = new CurrencyCountry[]
            {
            new CurrencyCountry { Name = "United States dollar", CurrencyCode = "USD", ImageSource = "Data/Images/Flags/USD.png" },
            new CurrencyCountry { Name = "British pound", CurrencyCode = "GBP", ImageSource = "Data/Images/Flags/GBP.png" },
            new CurrencyCountry { Name = "Euro", CurrencyCode = "EUR", ImageSource = "Data/Images/Flags/EUR.png" },
            new CurrencyCountry { Name = "Australian dollar", CurrencyCode = "AUD", ImageSource = "Data/Images/Flags/AUD.png" },
            new CurrencyCountry { Name = "Canadian dollar", CurrencyCode = "CAD", ImageSource = "Data/Images/Flags/CAD.png" },
            new CurrencyCountry { Name = "Danish krone", CurrencyCode = "DKK", ImageSource = "Data/Images/Flags/DKK.png" },
            new CurrencyCountry { Name = "Hong Kong dollar", CurrencyCode = "HKD", ImageSource = "Data/Images/Flags/HKD.png" },
            new CurrencyCountry { Name = "Japanese yen", CurrencyCode = "JPY", ImageSource = "Data/Images/Flags/JPY.png" },
            new CurrencyCountry { Name = "New Zealand dollar", CurrencyCode = "NZD", ImageSource = "Data/Images/Flags/NZD.png" },
            new CurrencyCountry { Name = "Norwegian krone", CurrencyCode = "NOK", ImageSource = "Data/Images/Flags/NOK.png" },
            new CurrencyCountry { Name = "Swiss franc", CurrencyCode = "CHF", ImageSource = "Data/Images/Flags/CHF.png" },
            new CurrencyCountry { Name = "Singapore dollar", CurrencyCode = "SGD", ImageSource = "Data/Images/Flags/SGD.png" },
            new CurrencyCountry { Name = "Swedish krona", CurrencyCode = "SEK", ImageSource = "Data/Images/Flags/SEK.png" },
            new CurrencyCountry { Name = "Saudi rial", CurrencyCode = "SAR", ImageSource = "Data/Images/Flags/SAR.png" },
            new CurrencyCountry { Name = "Taiwan dollar", CurrencyCode = "TWD", ImageSource = "Data/Images/Flags/TWD.png" },
            new CurrencyCountry { Name = "South African rand", CurrencyCode = "ZAR", ImageSource = "Data/Images/Flags/ZAR.png" },
            new CurrencyCountry { Name = "Brazilian real", CurrencyCode = "BRL", ImageSource = "Data/Images/Flags/BRL.png" },
            new CurrencyCountry { Name = "Chinese yuan", CurrencyCode = "CNY", ImageSource = "Data/Images/Flags/CNY.png" },
            new CurrencyCountry { Name = "Czech koruna", CurrencyCode = "CZK", ImageSource = "Data/Images/Flags/CZK.png" },
            new CurrencyCountry { Name = "Hungarian forint", CurrencyCode = "HUF", ImageSource = "Data/Images/Flags/HUF.png" },
            new CurrencyCountry { Name = "Indian rupee", CurrencyCode = "INR", ImageSource = "Data/Images/Flags/INR.png" },
            new CurrencyCountry { Name = "Israeili shekel", CurrencyCode = "ILS", ImageSource = "Data/Images/Flags/ILS.png" },
            new CurrencyCountry { Name = "Malaysian ringgit", CurrencyCode = "MYR", ImageSource = "Data/Images/Flags/MYR.png" },
            new CurrencyCountry { Name = "Polish zloty", CurrencyCode = "PLN", ImageSource = "Data/Images/Flags/PLN.png" },
            new CurrencyCountry { Name = "Russian rubble", CurrencyCode = "RUB", ImageSource = "Data/Images/Flags/RUB.png" },
            new CurrencyCountry { Name = "South Korean won", CurrencyCode = "KRW", ImageSource = "Data/Images/Flags/KRW.png" },
            new CurrencyCountry { Name = "Thai baht", CurrencyCode = "THB", ImageSource = "Data/Images/Flags/THB.png" },
            new CurrencyCountry { Name = "Turkish lira", CurrencyCode = "TRY", ImageSource = "Data/Images/Flags/TRY.png" },
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
        private CurrencyCountry country1;
        private CurrencyCountry country2;

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
            string apiKey = "uqJe3DgGNgsPcFn3KRZW";

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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchPanel.IsVisible)
            {
                ConvertPanel.Visibility = Visibility.Visible;
            }
        }

        private bool isCurrencyButton1Selected = true;
        private void CurrencyButton1_Click(object sender, RoutedEventArgs e)
        {
            isCurrencyButton1Selected = true;
            if (ConvertPanel.IsVisible)
            {
                SearchPanel.Visibility = Visibility.Visible;
                ConvertPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void CurrencyButton2_Click(object sender, RoutedEventArgs e)
        {
            isCurrencyButton1Selected = false;
            if (ConvertPanel.IsVisible)
            {
                SearchPanel.Visibility = Visibility.Visible;
                ConvertPanel.Visibility = Visibility.Collapsed;
            }
        }

        private async void CurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            CurrencyCountry clickedCountry = (CurrencyCountry)clickedButton.DataContext;

            if (isCurrencyButton1Selected)
            {
                country1 = clickedCountry;
                CurrencyButton1.DataContext = country1;
            }
            else
            {
                country2 = clickedCountry;
                CurrencyButton2.DataContext = country2;
            }

            if (country1 != null && country2 != null)
            {
                // Generate URL for making an API request
                string requestUrl = GenerateRequestUrl(country1.CurrencyCode, country2.CurrencyCode);

                // Use the request URL to fetch the exchange rate data
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        // Extract the exchange rate data from the response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        // Do something with the exchange rate data
                    }
                    else
                    {
                        // Handle the case when the API request fails
                    }
                }
            }

            if (SearchPanel.IsVisible)
            {
                ConvertPanel.Visibility = Visibility.Visible;
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Foreground == Brushes.Gray)
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = Brushes.White;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Type a country / currency";
                SearchTextBox.Foreground = Brushes.Gray;
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
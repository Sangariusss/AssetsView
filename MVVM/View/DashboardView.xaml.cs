using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AssetsView.MVVM.View
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

    public class CurrencyCountry
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string ImageSource { get; set; }
        public string NasdaqCurrencyCode { get; set; }
    }

    public class CurrencyCountryManager
    {
        // Returns an array of CurrencyCountry objects
        public CurrencyCountry[] GetCurrencyCountries()
        {
            CurrencyCountry[] countries = new CurrencyCountry[]
            {
            new CurrencyCountry { Name = "United States dollar", CurrencyCode = "USD", NasdaqCurrencyCode = "D", ImageSource = "/Data/Images/Flags/USD.png" },
            new CurrencyCountry { Name = "British pound", CurrencyCode = "GBP", NasdaqCurrencyCode = "S", ImageSource = "/Data/Images/Flags/GBP.png" },
            new CurrencyCountry { Name = "Euro", CurrencyCode = "EUR", NasdaqCurrencyCode = "ER", ImageSource = "/Data/Images/Flags/EUR.png" },
            new CurrencyCountry { Name = "Australian dollar", CurrencyCode = "AUD", NasdaqCurrencyCode = "AD", ImageSource = "/Data/Images/Flags/AUD.png" },
            new CurrencyCountry { Name = "Canadian dollar", CurrencyCode = "CAD", NasdaqCurrencyCode = "CD", ImageSource = "/Data/Images/Flags/CAD.png" },
            new CurrencyCountry { Name = "Danish krone", CurrencyCode = "DKK", NasdaqCurrencyCode = "DK", ImageSource = "/Data/Images/Flags/DKK.png" },
            new CurrencyCountry { Name = "Hong Kong dollar", CurrencyCode = "HKD", NasdaqCurrencyCode = "HD", ImageSource = "/Data/Images/Flags/HKD.png" },
            new CurrencyCountry { Name = "Japanese yen", CurrencyCode = "JPY", NasdaqCurrencyCode = "JY", ImageSource = "/Data/Images/Flags/JPY.png" },
            new CurrencyCountry { Name = "New Zealand dollar", CurrencyCode = "NZD", NasdaqCurrencyCode = "ND", ImageSource = "/Data/Images/Flags/NZD.png" },
            new CurrencyCountry { Name = "Norwegian krone", CurrencyCode = "NOK", NasdaqCurrencyCode = "NK", ImageSource = "/Data/Images/Flags/NOK.png" },
            new CurrencyCountry { Name = "Swiss franc", CurrencyCode = "CHF", NasdaqCurrencyCode = "SF", ImageSource = "/Data/Images/Flags/CHF.png" },
            new CurrencyCountry { Name = "Singapore dollar", CurrencyCode = "SGD", NasdaqCurrencyCode = "SG", ImageSource = "/Data/Images/Flags/SGD.png" },
            new CurrencyCountry { Name = "Swedish krona", CurrencyCode = "SEK", NasdaqCurrencyCode = "SK", ImageSource = "/Data/Images/Flags/SEK.png" },
            new CurrencyCountry { Name = "Saudi rial", CurrencyCode = "SAR", NasdaqCurrencyCode = "SR", ImageSource = "/Data/Images/Flags/SAR.png" },
            new CurrencyCountry { Name = "Taiwan dollar", CurrencyCode = "TWD", NasdaqCurrencyCode = "TW", ImageSource = "/Data/Images/Flags/TWD.png" },
            new CurrencyCountry { Name = "South African rand", CurrencyCode = "ZAR", NasdaqCurrencyCode = "ZR", ImageSource = "/Data/Images/Flags/ZAR.png" },
           /* new CurrencyCountry { Name = "Brazilian real", CurrencyCode = "BRL", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/BRL.png" },
            new CurrencyCountry { Name = "Chinese yuan", CurrencyCode = "CNY", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/CNY.png" },
            new CurrencyCountry { Name = "Czech koruna", CurrencyCode = "CZK", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/CZK.png" },
            new CurrencyCountry { Name = "Hungarian forint", CurrencyCode = "HUF", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/HUF.png" },
            new CurrencyCountry { Name = "Indian rupee", CurrencyCode = "INR", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/INR.png" },
            new CurrencyCountry { Name = "Israeili shekel", CurrencyCode = "ILS", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/ILS.png" },
            new CurrencyCountry { Name = "Malaysian ringgit", CurrencyCode = "MYR", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/MYR.png" },
            new CurrencyCountry { Name = "Polish zloty", CurrencyCode = "PLN", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/PLN.png" },
            new CurrencyCountry { Name = "Russian rubble", CurrencyCode = "RUB", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/RUB.png" },
            new CurrencyCountry { Name = "South Korean won", CurrencyCode = "KRW", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/KRW.png" },
            new CurrencyCountry { Name = "Thai baht", CurrencyCode = "THB", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/THB.png" },
            new CurrencyCountry { Name = "Turkish lira", CurrencyCode = "TRY", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/TRY.png" },*/
            };

            return countries;
        }
    }

    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private CurrencyCountry country1;
        private CurrencyCountry country2;
        public DashboardView()
        {
            InitializeComponent();
        }

        public string CreateIndicator(string currency1, string currency2)
        {
            return currency1 + currency2;
        }

        public string GenerateRequestUrl(string currency1, string currency2)
        {
            string indicator = CreateIndicator(currency1, currency2);
            string apiKey = "uqJe3DgGNgsPcFn3KRZW";

            return $"https://data.nasdaq.com/api/v3/datasets/BOE/XUDL{indicator}.json?api_key={apiKey}";
        }

        private void ButtonAddFavouriteRates_Click(object sender, RoutedEventArgs e)
        {

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
                string requestUrl = GenerateRequestUrl(country1.NasdaqCurrencyCode, country2.NasdaqCurrencyCode);
                Console.Write(requestUrl);
                // Use the request URL to fetch the exchange rate data
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        // Extract the exchange rate data from the response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        // Do something with the exchange rate data
                        Console.Write(jsonResponse);
                    }
                    else
                    {
                        // Handle the case when the API request fails
                        Console.WriteLine("Error");
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

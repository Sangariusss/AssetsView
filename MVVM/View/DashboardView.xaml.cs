using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json.Linq;
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
        public ISeries[] Series { get; set; } = new ISeries[]
        {
            new LineSeries<double>
            {
                Values = new double[] { 1, 1.1, 0.9, 1.25, 0.95, 1 },
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
        public static IEnumerable<CurrencyCountry> CountrySeries
        {
            get { return CurrencyCountryManager.GetCurrencyCountries(); }
        }
    }

    public class CurrencyCountry
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string NasdaqCurrencyCode { get; set; }
        public string ImageSource { get; set; }
        public string ImageRoundedSource { get; set; }

    }

    public class CurrencyCountryManager
    {
        // Returns an array of CurrencyCountry objects
        public static CurrencyCountry[] GetCurrencyCountries()
        {
            CurrencyCountry[] countries = new CurrencyCountry[]
            {
            new CurrencyCountry { Name = "United States dollar", CurrencyCode = "USD", NasdaqCurrencyCode = "D", ImageSource = "/Data/Images/Flags/USD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/USDrounded.png"},
            new CurrencyCountry { Name = "British pound", CurrencyCode = "GBP", NasdaqCurrencyCode = "S", ImageSource = "/Data/Images/Flags/GBP.png", ImageRoundedSource = "/Data/Images/FlagsRounded/GBProunded.png"},
            new CurrencyCountry { Name = "Euro", CurrencyCode = "EUR", NasdaqCurrencyCode = "ER", ImageSource = "/Data/Images/Flags/EUR.png", ImageRoundedSource = "/Data/Images/FlagsRounded/EURrounded.png"},
            new CurrencyCountry { Name = "Australian dollar", CurrencyCode = "AUD", NasdaqCurrencyCode = "AD", ImageSource = "/Data/Images/Flags/AUD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/AUDrounded.png"},
            new CurrencyCountry { Name = "Canadian dollar", CurrencyCode = "CAD", NasdaqCurrencyCode = "CD", ImageSource = "/Data/Images/Flags/CAD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/CADrounded.png"},
            new CurrencyCountry { Name = "Danish krone", CurrencyCode = "DKK", NasdaqCurrencyCode = "DK", ImageSource = "/Data/Images/Flags/DKK.png", ImageRoundedSource = "/Data/Images/FlagsRounded/DKKrounded.png"},
            new CurrencyCountry { Name = "Hong Kong dollar", CurrencyCode = "HKD", NasdaqCurrencyCode = "HD", ImageSource = "/Data/Images/Flags/HKD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/HKDrounded.png"},
            new CurrencyCountry { Name = "Japanese yen", CurrencyCode = "JPY", NasdaqCurrencyCode = "JY", ImageSource = "/Data/Images/Flags/JPY.png", ImageRoundedSource = "/Data/Images/FlagsRounded/JPYrounded.png"},
            new CurrencyCountry { Name = "New Zealand dollar", CurrencyCode = "NZD", NasdaqCurrencyCode = "ND", ImageSource = "/Data/Images/Flags/NZD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/NZDrounded.png"},
            new CurrencyCountry { Name = "Norwegian krone", CurrencyCode = "NOK", NasdaqCurrencyCode = "NK", ImageSource = "/Data/Images/Flags/NOK.png", ImageRoundedSource = "/Data/Images/FlagsRounded/NOKrounded.png"},
            new CurrencyCountry { Name = "Swiss franc", CurrencyCode = "CHF", NasdaqCurrencyCode = "SF", ImageSource = "/Data/Images/Flags/CHF.png", ImageRoundedSource = "/Data/Images/FlagsRounded/CHFrounded.png"},
            new CurrencyCountry { Name = "Singapore dollar", CurrencyCode = "SGD", NasdaqCurrencyCode = "SG", ImageSource = "/Data/Images/Flags/SGD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/SGDrounded.png"},
            new CurrencyCountry { Name = "Swedish krona", CurrencyCode = "SEK", NasdaqCurrencyCode = "SK", ImageSource = "/Data/Images/Flags/SEK.png", ImageRoundedSource = "/Data/Images/FlagsRounded/SEKrounded.png"},
            new CurrencyCountry { Name = "Saudi rial", CurrencyCode = "SAR", NasdaqCurrencyCode = "SR", ImageSource = "/Data/Images/Flags/SAR.png", ImageRoundedSource = "/Data/Images/FlagsRounded/SARrounded.png"},
            new CurrencyCountry { Name = "Taiwan dollar", CurrencyCode = "TWD", NasdaqCurrencyCode = "TW", ImageSource = "/Data/Images/Flags/TWD.png", ImageRoundedSource = "/Data/Images/FlagsRounded/TWDrounded.png"},
            new CurrencyCountry { Name = "South African rand", CurrencyCode = "ZAR", NasdaqCurrencyCode = "ZR", ImageSource = "/Data/Images/Flags/ZAR.png", ImageRoundedSource = "/Data/Images/FlagsRounded/ZARrounded.png"},
           /* new CurrencyCountry { Name = "Brazilian real", CurrencyCode = "BRL", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/BRL.png", ImageRoundedSource = "/Data/Images/FlagsRounded/BRLrounded.png"},
            new CurrencyCountry { Name = "Chinese yuan", CurrencyCode = "CNY", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/CNY.png", ImageRoundedSource = "/Data/Images/FlagsRounded/CNYrounded.png"},
            new CurrencyCountry { Name = "Czech koruna", CurrencyCode = "CZK", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/CZK.png", ImageRoundedSource = "/Data/Images/FlagsRounded/CZKrounded.png"},
            new CurrencyCountry { Name = "Hungarian forint", CurrencyCode = "HUF", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/HUF.png", ImageRoundedSource = "/Data/Images/FlagsRounded/HUFrounded.png"},
            new CurrencyCountry { Name = "Indian rupee", CurrencyCode = "INR", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/INR.png", ImageRoundedSource = "/Data/Images/FlagsRounded/INRrounded.png"},
            new CurrencyCountry { Name = "Israeili shekel", CurrencyCode = "ILS", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/ILS.png", ImageRoundedSource = "/Data/Images/FlagsRounded/ILSrounded.png"},
            new CurrencyCountry { Name = "Malaysian ringgit", CurrencyCode = "MYR", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/MYR.png", ImageRoundedSource = "/Data/Images/FlagsRounded/MYRrounded.png"},
            new CurrencyCountry { Name = "Polish zloty", CurrencyCode = "PLN", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/PLN.png", ImageRoundedSource = "/Data/Images/FlagsRounded/PLNrounded.png"},
            new CurrencyCountry { Name = "Russian rubble", CurrencyCode = "RUB", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/RUB.png", ImageRoundedSource = "/Data/Images/FlagsRounded/RUBrounded.png"},
            new CurrencyCountry { Name = "South Korean won", CurrencyCode = "KRW", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/KRW.png", ImageRoundedSource = "/Data/Images/FlagsRounded/KRWrounded.png"},
            new CurrencyCountry { Name = "Thai baht", CurrencyCode = "THB", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/THB.png", ImageRoundedSource = "/Data/Images/FlagsRounded/THBrounded.png"},
            new CurrencyCountry { Name = "Turkish lira", CurrencyCode = "TRY", NasdaqCurrencyCode = "", ImageSource = "/Data/Images/Flags/TRY.png", ImageRoundedSource = "/Data/Images/FlagsRounded/TRYrounded.png"},*/
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

        private double exchangeRate;
        private double convertedAmount;

        public DashboardView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ImageRounded1.DataContext = new CurrencyCountry { ImageRoundedSource = "/Data/Images/FlagsRounded/EURrounded.png" };
            ImageRounded2.DataContext = new CurrencyCountry { ImageRoundedSource = "/Data/Images/FlagsRounded/USDrounded.png" };
            CurrencyButton1.DataContext = new CurrencyCountry { CurrencyCode = "EUR", ImageSource = "/Data/Images/Flags/EUR.png", NasdaqCurrencyCode = "ER" };
            CurrencyButton2.DataContext = new CurrencyCountry { CurrencyCode = "USD", ImageSource = "/Data/Images/Flags/USD.png", NasdaqCurrencyCode = "D" };
        }

        public static string CreateIndicator(string currency1, string currency2)
        {
            return currency1 + currency2;
        }

        public static string GenerateRequestUrl(string currency1, string currency2)
        {
            string indicator = CreateIndicator(currency1, currency2);
            string apiKey = "uqJe3DgGNgsPcFn3KRZW";
            string url = $"https://data.nasdaq.com/api/v3/datasets/BOE/XUDL{indicator}.json?api_key={apiKey}";

            // Add query parameter to request latest data
            url += "&order=desc&limit=1";

            return url;
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
                ImageRounded1.DataContext = country1;
            }
            else
            {
                country2 = clickedCountry;
                CurrencyButton2.DataContext = country2;
                ImageRounded2.DataContext = country2;
            }

            if (country1 != null && country2 != null)
            {
                // Generate URL for making an API request
                string requestUrl = GenerateRequestUrl(country1.NasdaqCurrencyCode, country2.NasdaqCurrencyCode);
                Console.Write(requestUrl);
                // Use the request URL to fetch the exchange rate data
                using HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    // Extract the exchange rate data from the response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject exchangeData = JObject.Parse(jsonResponse);
                    exchangeRate = exchangeData["dataset"]["data"][0][1].Value<double>();
                    double reverseExchangeRate = 1.0 / exchangeRate;

                    // Update the exchange rate text with the selected currencies and exchange rate
                    ExchangeRateTextBlock1.Text = $"1 {country1.CurrencyCode} = {reverseExchangeRate:F5} {country2.CurrencyCode}";
                    ExchangeRateTextBlock2.Text = $"1 {country1.CurrencyCode} = {reverseExchangeRate:F5} {country2.CurrencyCode}";
                    CurrencyConversionTextBlock.Text = $"{country1.CurrencyCode} to {country2.CurrencyCode}";

                    // Update the exchange rate values in the two TextBox controls
                    CurrencyTextBox1.Text = reverseExchangeRate.ToString();
                    CurrencyTextBox2.Text = reverseExchangeRate.ToString();
                }
                else
                {
                    // Handle the case when the API request fails
                    Console.WriteLine("Error");
                }
            }

            if (SearchPanel.IsVisible)
            {
                ConvertPanel.Visibility = Visibility.Visible;
            }
        }

        private void CurrencyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox changedTextBox = (TextBox)sender;
            if (changedTextBox == CurrencyTextBox1)
            {
                if (double.TryParse(CurrencyTextBox1.Text, out double amount))
                {
                    convertedAmount = amount * (1.0 / exchangeRate);
                    CurrencyTextBox2.Text = convertedAmount.ToString("0.##");
                }
                else
                {
                    CurrencyTextBox2.Text = "";
                }
            }
            else if (changedTextBox == CurrencyTextBox2)
            {
                if (double.TryParse(CurrencyTextBox2.Text, out double amount))
                {
                    convertedAmount = amount * exchangeRate;
                    CurrencyTextBox1.Text = convertedAmount.ToString("0.##");
                }
                else
                {
                    CurrencyTextBox1.Text = "";
                }
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

        private void CurrencyTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsDigit(c) && c != ',')
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void SearchTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!Char.IsLetter(c))
                {
                    e.Handled = true;
                    break;
                }
            }
        }
    }
}

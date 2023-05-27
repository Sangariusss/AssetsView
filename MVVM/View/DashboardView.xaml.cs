using AssetsView.Data.Languages;
using LiveChartsCore;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AssetsView.MVVM.View
{
    public class ViewModel
    {
        // Gets or sets the chart's series
        public ISeries[] Series { get; set; } = new ISeries[]
        {
            new LineSeries<double, CircleGeometry>
            {
                Values = new ObservableCollection<double> { 1, 1, 1, 1, 1, 1, 1 },
                GeometryStroke = null,
                GeometryFill = null,
                LineSmoothness = 0,
                Fill = null,
                Stroke = new SolidColorPaint(SKColors.LimeGreen, 3),
                TooltipLabelFormatter =
                    (ChartPoint) => $"1 EUR = {ChartPoint.PrimaryValue:C5}USD{Environment.NewLine}2023 Today, 12:00"
            }
        };

        public Axis[] XAxes { get; set; }
            = new Axis[]
            {
                new Axis
                {
                    TextSize = 0,
                }
            };

        public Axis[] YAxes { get; set; }
            = new Axis[]
            {
                new Axis
                {
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                    LabelsPaint = new SolidColorPaint(SKColors.DimGray),
                    TextSize = 18,

                    SeparatorsPaint = new SolidColorPaint(SKColors.DimGray)
                    {
                        StrokeThickness = 2,
                    }
                }
            };

        public SolidColorPaint TooltipTextPaint { get; set; } =
        new SolidColorPaint
        {
            Color = SKColors.LimeGreen,
        };

        public SolidColorPaint TooltipBackgroundPaint { get; set; } =
        new SolidColorPaint(new SKColor(14, 14, 14));

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
        public string? Name { get; set; }
        public string? CurrencyCode { get; set; }
        public string? NasdaqCurrencyCode { get; set; }
        public string? ImageSource { get; set; }
        public string? ImageRoundedSource { get; set; }

    }

    public class CurrencyCountryManager
    {
        public string? filterText;
        public CurrencyCountry[] FilterCurrencyCountries()
        {
            string searchText = this.filterText.Replace(" ", "");
            CurrencyCountry[] allCountries = GetCurrencyCountries();
            List<CurrencyCountry> filteredCountries = new List<CurrencyCountry>();

            if (filterText == "Type a country / currency" || filterText == "Select the first currency" || filterText == "Select the second currency")
            {
                return allCountries;
            }

            foreach (CurrencyCountry country in allCountries)
            {
                if (country.Name.ToLower().Replace(" ", "").Contains(searchText.ToLower()) ||
                    country.CurrencyCode.ToLower().Replace(" ", "").Contains(searchText.ToLower()))
                {
                    filteredCountries.Add(country);
                }
            }

            return filteredCountries.ToArray();
        }

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

        private ConfigModel _config;
        public DashboardView()
        {
            InitializeComponent();

            _config = ConfigManager.LoadConfig("config.xml");

            ThemeRadioButton1.IsChecked = _config.IsThemeRadioButtonChecked1;
            ThemeRadioButton2.IsChecked = _config.IsThemeRadioButtonChecked2;

            LanguageRadioButton1.IsChecked = _config.IsLanguageRadioButtonChecked1;
            LanguageRadioButton2.IsChecked = _config.IsLanguageRadioButtonChecked2;

            ResolutionRadioButton1.IsChecked = _config.IsResolutionRadioButtonChecked1;
            ResolutionRadioButton2.IsChecked = _config.IsResolutionRadioButtonChecked2;
            ResolutionRadioButton3.IsChecked = _config.IsResolutionRadioButtonChecked3;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateHistoryExchangeRate();
            UpdateCurrentExchangeRate();
            ImageRounded1.DataContext = new CurrencyCountry { ImageRoundedSource = "/Data/Images/FlagsRounded/EURrounded.png" };
            ImageRounded2.DataContext = new CurrencyCountry { ImageRoundedSource = "/Data/Images/FlagsRounded/USDrounded.png" };
            CurrencyButton1.DataContext = new CurrencyCountry { CurrencyCode = "EUR", ImageSource = "/Data/Images/Flags/EUR.png" };
            CurrencyButton2.DataContext = new CurrencyCountry { CurrencyCode = "USD", ImageSource = "/Data/Images/Flags/USD.png" };
            country1 = new CurrencyCountry { CurrencyCode = "EUR", NasdaqCurrencyCode = "ER" };
            country2 = new CurrencyCountry { CurrencyCode = "USD", NasdaqCurrencyCode = "D" };
        }

        public static string CreateIndicator(string currency1, string currency2)
        {
            return currency1 + currency2;
        }

        public static string GenerateRequestCurrentExchangeRateUrl(string currency1, string currency2)
        {
            string indicator = CreateIndicator(currency1, currency2);
            string apiKey = "uqJe3DgGNgsPcFn3KRZW";
            string url = $"https://data.nasdaq.com/api/v3/datasets/BOE/XUDL{indicator}.json?api_key={apiKey}";

            // Add query parameter to request latest data
            url += "&order=desc&limit=1";

            return url;
        }

        public static string GenerateRequestHistoryExchangeRateUrl(string currency1, string currency2, DateTime startDate, DateTime endDate)
        {
            string indicator = CreateIndicator(currency1, currency2);
            string apiKey = "uqJe3DgGNgsPcFn3KRZW";
            string url = $"https://data.nasdaq.com/api/v3/datasets/BOE/XUDL{indicator}.json?api_key={apiKey}";

            // Add query parameters to request historical data
            url += $"&start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}";

            // Set the order to ascending to get data in chronological order
            url += "&order=asc";

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

        private void CurrencyButton_Click(object sender, RoutedEventArgs e)
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

            UpdateCurrentExchangeRate();
            UpdateHistoryExchangeRate();

            if (SearchPanel.IsVisible)
            {
                ConvertPanel.Visibility = Visibility.Visible;
            }
        }

        private async void UpdateCurrentExchangeRate()
        {
            if (country1 != null && country2 != null)
            {
                // Generate URL for making an API request
                string requestUrl = GenerateRequestCurrentExchangeRateUrl(country1.NasdaqCurrencyCode, country2.NasdaqCurrencyCode);
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
        }

        private async void UpdateHistoryExchangeRate()
        {
            DateTime startDate;
            DateTime endDate;

            if (country1 != null && country2 != null)
            {
                // Determine the selected time period based on the selected RadioButton
                if (RadioButton1M.IsChecked == true)
                {
                    startDate = DateTime.Today.AddMonths(-1);
                    endDate = DateTime.Today;
                }
                else if (RadioButton3M.IsChecked == true)
                {
                    startDate = DateTime.Today.AddMonths(-3);
                    endDate = DateTime.Today;
                }
                else if (RadioButton6M.IsChecked == true)
                {
                    startDate = DateTime.Today.AddMonths(-6);
                    endDate = DateTime.Today;
                }
                else if (RadioButton1Y.IsChecked == true)
                {
                    startDate = DateTime.Today.AddYears(-1);
                    endDate = DateTime.Today;
                }
                else if (RadioButton5Y.IsChecked == true)
                {
                    startDate = DateTime.Today.AddYears(-5);
                    endDate = DateTime.Today;
                }
                else if (RadioButton10Y.IsChecked == true)
                {
                    startDate = DateTime.Today.AddYears(-10);
                    endDate = DateTime.Today;
                }
                else
                {
                    // No RadioButton selected, handle this case if necessary
                    return;
                }

                // Generate URL for making an API request
                string requestUrl = GenerateRequestHistoryExchangeRateUrl(country1.NasdaqCurrencyCode, country2.NasdaqCurrencyCode, startDate, endDate);
                Console.Write(requestUrl);

                // Use the request URL to fetch the exchange rate data
                using HttpClient client = new();
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Extract the exchange rate data from the response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject exchangeData = JObject.Parse(jsonResponse);

                    // Extract the historical exchange rates from the response
                    JArray historicalData = (JArray)exchangeData["dataset"]["data"];
                    // Create a dictionary to store the corresponding dates for each exchange rate

                    List<double> exchangeRates = new List<double>(); // Create a list to store exchange rates
                    List<DateTime> dates = new List<DateTime>(); // Create a list to store dates

                    foreach (JArray dataPoint in historicalData)
                    {
                        DateTime date = DateTime.Parse(dataPoint[0].Value<string>()); // Parse the date from the data
                        double exchangeRate = dataPoint[1].Value<double>();
                        double reverseExchangeRate = 1.0 / exchangeRate;
                        exchangeRates.Add(reverseExchangeRate);
                        dates.Add(date); // Add the date to the list
                    }

                    // Create a new LineSeries from the exchangeRates list
                    var lineSeries = new LineSeries<double, CircleGeometry>
                    {
                        Values = new ObservableCollection<double>(exchangeRates),
                        LineSmoothness = 0,
                        GeometryStroke = null,
                        GeometryFill = null,
                        Fill = null,
                        Stroke = new SolidColorPaint(SKColors.LimeGreen, 3),
                        TooltipLabelFormatter = (chartPoint) =>
                        {
                            string currency1 = country1.CurrencyCode;
                            string currency2 = country2.CurrencyCode;
                            int index = exchangeRates.IndexOf(chartPoint.PrimaryValue);
                            DateTime date = dates[index]; // Get the corresponding date from the list
                            string formattedDate = date.ToString("yyyy-MM-dd"); // Format the date as desired
                            return $"1 {currency1} = {chartPoint.PrimaryValue:F5} {currency2}{Environment.NewLine}{formattedDate}";
                        },
                    };
                    // Add the new LineSeries to the chart's Series collection
                    CurrencyChart.Series = new ISeries[] { lineSeries };
                }
                else
                {
                    // Handle the case when the API request fails
                    Console.WriteLine("Error");
                }
            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // Call the UpdateHistoryExchangeRate method when a RadioButton is checked
            UpdateHistoryExchangeRate();
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
            if (SearchTextBox.IsFocused == true)
            {
                SearchTextBox.Text = "";
                SearchTextBox.Foreground = Brushes.White;
            }

            if (SelectCurrencyTextBox1.IsFocused == true)
            {
                SelectCurrencyTextBox1.Text = "";
                SelectCurrencyTextBox1.Foreground = Brushes.White;
            }
            if (SelectCurrencyTextBox2.IsFocused == true)
            {
                SelectCurrencyTextBox2.Text = "";
                SelectCurrencyTextBox2.Foreground = Brushes.White;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = Strings.SearchTextBoxText;
                SearchTextBox.Foreground = Brushes.Gray;
                SelectCurrencyTextBox1.Text = "Select the first currency";
                SelectCurrencyTextBox1.Foreground = Brushes.Gray;
                SelectCurrencyTextBox2.Text = "Select the second currency";
                SelectCurrencyTextBox2.Foreground = Brushes.Gray;
            }
        }

        private void SelectCurrencyTextBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectCurrencyTextBox1.Text))
            {
                SelectCurrencyTextBox1.Text = Strings.SelectCurrencyText1;
                SelectCurrencyTextBox1.Foreground = Brushes.Gray;
            }
        }

        private void SelectCurrencyTextBox2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SelectCurrencyTextBox2.Text))
            {
                SelectCurrencyTextBox2.Text = Strings.SelectCurrencyText2;
                SelectCurrencyTextBox2.Foreground = Brushes.Gray;
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

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double windowWidth = e.NewSize.Width;

            if (windowWidth == 711)
            {
                Grid.SetRow(FavouritePopularPanel, 1);
                Grid.SetColumn(FavouritePopularPanel, 0);
                Grid.SetRow(AddFavouriteRatesPanel, 1);
                Grid.SetColumn(AddFavouriteRatesPanel, 0);
                ExtendedPanel.Visibility = Visibility.Collapsed;
                ConvertPanel.Margin = new Thickness(37, 0, 34, 541);
                SearchPanel.Margin = new Thickness(37, 0, 34, 541);
                ChartPanel.Margin = new Thickness(37, 399, 34, 0);
                FavouritePopularPanel.Margin = new Thickness(0, 14, 33, 0);
                AddFavouriteRatesPanel.Margin = new Thickness(0, 14, 33, 0);
            }
            else if (windowWidth == 1340)
            {
                Grid.SetRow(FavouritePopularPanel, 0);
                Grid.SetColumn(FavouritePopularPanel, 1);
                Grid.SetRow(AddFavouriteRatesPanel, 0);
                Grid.SetColumn(AddFavouriteRatesPanel, 1);
                ExtendedPanel.Visibility = Visibility.Collapsed;
                ConvertPanel.Margin = new Thickness(37, 0, 34, 541);
                SearchPanel.Margin = new Thickness(37, 0, 34, 541);
                ChartPanel.Margin = new Thickness(37, 399, 34, 0);
                FavouritePopularPanel.Margin = new Thickness(0, 0, 33, 0);
                AddFavouriteRatesPanel.Margin = new Thickness(0, 0, 33, 0);
            }
            else if (windowWidth == 1820)
            {
                ExtendedPanel.Visibility = Visibility.Visible;
                ConvertPanel.Margin = new Thickness(37, 0, 14, 541);
                SearchPanel.Margin = new Thickness(37, 0, 14, 541);
                ChartPanel.Margin = new Thickness(37, 399, 14, 0);
                FavouritePopularPanel.Margin = new Thickness(0, 0, 14, 0);
                AddFavouriteRatesPanel.Margin = new Thickness(0, 0, 14, 0);
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CountryListView != null && SearchTextBox.Text != Strings.SearchTextBoxText)
            {
                CurrencyCountryManager currencyCountryManager = new CurrencyCountryManager();
                currencyCountryManager.filterText = SearchTextBox.Text;

                // Update the ListView's ItemSource with the filtered list of currency countries
                CurrencyCountry[] filteredCurrencyCountriesArray = currencyCountryManager.FilterCurrencyCountries();
                List<CurrencyCountry> filteredCurrencyCountriesList = new List<CurrencyCountry>(filteredCurrencyCountriesArray);
                CountryListView.ItemsSource = filteredCurrencyCountriesList;

                if (filteredCurrencyCountriesList.Count == 0)
                {
                    // No matches found - display the text block
                    NoMatchesTextBlock.Visibility = Visibility.Visible;
                    CountryListView.ItemsSource = null;
                }
                else
                {
                    // Matches found - hide the text block and update the ListView's ItemSource
                    NoMatchesTextBlock.Visibility = Visibility.Collapsed;
                    CountryListView.ItemsSource = filteredCurrencyCountriesList;
                }
            }
        }

        private void SwitchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool isDataContextSwapped = false;
        private void FavouriteSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle the DataContext values of SelectCurrencyTextBox1 and SelectCurrencyTextBox2
            if (isDataContextSwapped)
            {
                SelectCurrencyTextBox1.DataContext = SelectedCurrencyTextBlock1.DataContext;
                SelectCurrencyTextBox2.DataContext = SelectedCurrencyTextBlock2.DataContext;
            }
            else
            {
                SelectCurrencyTextBox1.DataContext = SelectedCurrencyTextBlock2.DataContext;
                SelectCurrencyTextBox2.DataContext = SelectedCurrencyTextBlock1.DataContext;
            }

            isDataContextSwapped = !isDataContextSwapped;
        }

        ObservableCollection<FavouriteListItem> favouriteList = new ObservableCollection<FavouriteListItem>();
        public class FavouriteListItem
        {
            public ImageSource ImageRoundedSource1 { get; set; }
            public ImageSource ImageRoundedSource2 { get; set; }
            public string CurrencyConversionText { get; set; }
            public string ExchangeRateText { get; set; }
        }

        private void StarToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            FavouriteListView.ItemsSource = favouriteList;
            ImageSource imageRoundedSource1 = ImageRounded1.Source;
            ImageSource imageRoundedSource2 = ImageRounded2.Source;
            string currencyConversionText = CurrencyConversionTextBlock.Text;
            string exchangeRateText = ExchangeRateTextBlock2.Text;

            FavouriteListItem item = new FavouriteListItem();
            item.ImageRoundedSource1 = imageRoundedSource1;
            item.ImageRoundedSource2 = imageRoundedSource2;
            item.CurrencyConversionText = CurrencyConversionTextBlock.Text;
            item.ExchangeRateText = ExchangeRateTextBlock2.Text;

            favouriteList.Add(item);
            UpdateNotFoundFavouritesVisibility();
        }

        private void StarToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ImageSource imageRoundedSource1 = ImageRounded1.Source;
            ImageSource imageRoundedSource2 = ImageRounded2.Source;

            // Find the item with matching ImageRoundedSource1 and ImageRoundedSource2
            FavouriteListItem itemToRemove = favouriteList.FirstOrDefault(item =>
                item.ImageRoundedSource1 == imageRoundedSource1 && item.ImageRoundedSource2 == imageRoundedSource2);

            if (itemToRemove != null)
            {
                favouriteList.Remove(itemToRemove);
            }

            UpdateNotFoundFavouritesVisibility();
        }

        private void UpdateNotFoundFavouritesVisibility()
        {
            if (FavouriteListView.Items.Count == 0)
            {
                NoFoundFavouritesTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                NoFoundFavouritesTextBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void ImageRounded1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateToggleButtonCheckedState();
        }

        private void ImageRounded2_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateToggleButtonCheckedState();
        }

        private void UpdateToggleButtonCheckedState()
        {
            ImageSource imageRoundedSource1 = ImageRounded1.Source;
            ImageSource imageRoundedSource2 = ImageRounded2.Source;

            bool isCurrencyPairInFavourites = favouriteList.Any(item =>
                item.ImageRoundedSource1 == imageRoundedSource1 && item.ImageRoundedSource2 == imageRoundedSource2);

            StarToggleButton.IsChecked = isCurrencyPairInFavourites;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            FavouriteListItem selectedItem = button.DataContext as FavouriteListItem;

            if (selectedItem != null)
            {
                // Перевірка, якщо значення ImageRoundedSource вже встановлені
                if (!(ImageRounded1.DataContext?.Equals(new { ImageRoundedSource = selectedItem.ImageRoundedSource1 }) ?? true) && !(ImageRounded2.DataContext?.Equals(new { ImageRoundedSource = selectedItem.ImageRoundedSource2 }) ?? true))
                {
                    ImageRounded1.DataContext = new { ImageRoundedSource = selectedItem.ImageRoundedSource1 };
                    ImageRounded2.DataContext = new { ImageRoundedSource = selectedItem.ImageRoundedSource2 };
                    StarToggleButton.IsChecked = true;
                }

                if (!CurrencyConversionTextBlock.Text.Equals(selectedItem.CurrencyConversionText))
                {
                    CurrencyConversionTextBlock.Text = selectedItem.CurrencyConversionText;
                }
            }
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

            RadioButton radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.IsChecked == true)
            {
                string selectedLanguage = radioButton.Content.ToString();

                if (selectedLanguage == "English" || selectedLanguage == "Англійська")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                    NoFoundFavouritesTextBlock.Margin = new Thickness(120, -392, 20, 0);
                    NoMatchesTextBlock.Margin = new Thickness(127, -227, 89, 0);
                    NoMatchesFavouriteTextBlock.Margin = new Thickness(106, -617, 0, 0);
                    CloseButton.Margin = new Thickness(252, 27, 0, 0);
                }
                else if (selectedLanguage == "Ukrainian" || selectedLanguage == "Українська")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk");
                    NoFoundFavouritesTextBlock.Margin = new Thickness(75, -392, 20, 0);
                    NoMatchesTextBlock.Margin = new Thickness(109, -227, 109, 0);
                    NoMatchesFavouriteTextBlock.Margin = new Thickness(88, -617, 0, 0);
                    CloseButton.Margin = new Thickness(119, 27, 0, 0);
                }
            }

            ConvertTitle.Text = Strings.ConvertTitle;
            FavouriteRatesTitle.Text = Strings.FavouriteRatesTitleText;
            PopularTitle.Text = Strings.PopularTitle;
            NoFoundFavouritesTextBlock.Text = Strings.NoFoundFavouritesText;
            NoMatchesTextBlock.Text = Strings.NoMatchesText;
            SearchTextBox.Text = Strings.SearchTextBoxText;
            PercentageChangeTextBlock.Text = Strings.PercentageChangeText;
            SelectFavouriteRatesTitle.Text = Strings.SelectFavouriteRatesTitleText;
            RadioButton1Y.Content = Strings.RadioButton1Y;
            RadioButton5Y.Content = Strings.RadioButton5Y;
            RadioButton10Y.Content = Strings.RadioButton10Y;
            SelectCurrencyTextBox1.Text = Strings.SelectCurrencyText1;
            SelectCurrencyTextBox2.Text = Strings.SelectCurrencyText2;
            NoMatchesFavouriteTextBlock.Text = Strings.NoMatchesText;
            QuickSettingsTextBlock.Text = Strings.QuickSettingsText;
            SetHotkeysTextBlock.Text = Strings.SetHotkeysText;
            DashboardTextBlock.Text = Strings.DashboardShortText;
            SettingsTextBlock.Text = Strings.SettingsText;
            HelpTextBlock.Text = Strings.HelpText;
            DeleteFavouriteRatesTextBlock.Text = Strings.DeleteFavouriteRatesText;
            SwapCurrenciesTextBlock.Text = Strings.SwapCurrenciesShortText;
            ThemeTextBlock.Text = Strings.ThemeShortText;
            LanguageTextBlock.Text = Strings.LanguageShortText;
            ResolutionTextBlock.Text = Strings.ResolutionShortText;
            ThemeRadioButton1.Content = Strings.ThemeRadioButtonContent1;
            ThemeRadioButton2.Content = Strings.ThemeRadioButtonContent2;
            LanguageRadioButton1.Content = Strings.LanguageRadioButtonContent1;
            LanguageRadioButton2.Content = Strings.LanguageRadioButtonContent2;

            ConfigManager.SaveConfig(_config, "config.xml");
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
                            mainWindow.ExitButton.Margin = new Thickness(0);

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;

                            ConfigManager.SaveConfig(_config, "config.xml");
                            break;
                        case "1440x1024":
                            AnimateMainWindowSize(1440, 1024);
                            ConvertPanel.Margin = new Thickness(37, 0, 34, 541);
                            SearchPanel.Margin = new Thickness(37, 0, 34, 541);
                            ChartPanel.Margin = new Thickness(37, 399, 34, 0);
                            FavouritePopularPanel.Margin = new Thickness(0, 14, 33, 0);
                            mainWindow.ExitButton.Margin = new Thickness(0);

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;

                            ConfigManager.SaveConfig(_config, "config.xml");
                            break;
                        case "1920x1040":
                            AnimateMainWindowSize(1920, 1040);
                            mainWindow.Left = 0;
                            mainWindow.Top = 0;
                            mainWindow.ExitButton.Margin = new Thickness(0, 16, 0, 0);

                            _config.IsResolutionRadioButtonChecked1 = ResolutionRadioButton1.IsChecked ?? false;
                            _config.IsResolutionRadioButtonChecked2 = ResolutionRadioButton2.IsChecked ?? false;

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

        private void AddFavouriteRatesButton_Click(object sender, RoutedEventArgs e)
        {
            AddFavouriteRatesPanel.Visibility = Visibility.Visible;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            AddFavouriteRatesPanel.Visibility = Visibility.Collapsed;
        }

        private void SelectCurrencyTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FavouriteRatesListView != null && SelectCurrencyTextBox1.Text != Strings.SelectCurrencyText1)
            {
                CurrencyCountryManager currencyCountryManager = new CurrencyCountryManager();
                currencyCountryManager.filterText = SelectCurrencyTextBox1.Text;

                // Update the ListView's ItemSource with the filtered list of currency countries
                CurrencyCountry[] filteredCurrencyCountriesArray = currencyCountryManager.FilterCurrencyCountries();
                List<CurrencyCountry> filteredCurrencyCountriesList = new List<CurrencyCountry>(filteredCurrencyCountriesArray);
                FavouriteRatesListView.ItemsSource = filteredCurrencyCountriesList;

                if (filteredCurrencyCountriesList.Count == 0)
                {
                    FavouriteRatesListView.ItemsSource = null;
                    NoMatchesFavouriteTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    FavouriteRatesListView.ItemsSource = filteredCurrencyCountriesList;
                    NoMatchesFavouriteTextBlock.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void SelectCurrencyTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FavouriteRatesListView != null && SelectCurrencyTextBox2.Text != Strings.SelectCurrencyText2)
            {
                CurrencyCountryManager currencyCountryManager = new CurrencyCountryManager();
                currencyCountryManager.filterText = SelectCurrencyTextBox2.Text;

                // Update the ListView's ItemSource with the filtered list of currency countries
                CurrencyCountry[] filteredCurrencyCountriesArray = currencyCountryManager.FilterCurrencyCountries();
                List<CurrencyCountry> filteredCurrencyCountriesList = new List<CurrencyCountry>(filteredCurrencyCountriesArray);
                FavouriteRatesListView.ItemsSource = filteredCurrencyCountriesList;

                if (filteredCurrencyCountriesList.Count == 0)
                {
                    FavouriteRatesListView.ItemsSource = null;
                    NoMatchesFavouriteTextBlock.Visibility = Visibility.Visible;
                }
                else
                {
                    FavouriteRatesListView.ItemsSource = filteredCurrencyCountriesList;
                    NoMatchesFavouriteTextBlock.Visibility = Visibility.Collapsed;
                }
            }
        }

        private bool isFirstImageSelected = false;
        private bool isSecondImageSelected = false;
        private void FavouriteCurrencyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            CurrencyCountry selectedCurrency = (CurrencyCountry)button.DataContext;

            if (!isFirstImageSelected)
            {
                SelectedCurrencyImage1.DataContext = new { SelectedCurrency = selectedCurrency };
                SelectedCurrencyTextBlock1.DataContext = new { SelectedCurrency = selectedCurrency };
                SelectedCurrencyNameTextBlock1.DataContext = new { SelectedCurrency = selectedCurrency };
                DeleteSelectedCurrencyButton1.Visibility = Visibility.Visible;
                SelectCurrencyTextBox1.IsEnabled = false;
                SelectCurrencyTextBox1.Text = "";
                isFirstImageSelected = true;
            }
            else if (!isSecondImageSelected)
            {
                SelectedCurrencyImage2.DataContext = new { SelectedCurrency = selectedCurrency };
                SelectedCurrencyTextBlock2.DataContext = new { SelectedCurrency = selectedCurrency };
                SelectedCurrencyNameTextBlock2.DataContext = new { SelectedCurrency = selectedCurrency };
                DeleteSelectedCurrencyButton2.Visibility = Visibility.Visible;
                SelectCurrencyTextBox2.IsEnabled = false;
                SelectCurrencyTextBox2.Text = "";
                isSecondImageSelected = true;
            }

            if (isFirstImageSelected && isSecondImageSelected)
            {
                AddFavouriteRatesPanel.Visibility = Visibility.Collapsed;

                FavouriteListView.ItemsSource = favouriteList;
                ImageSource imageRoundedSource1 = SelectedCurrencyImage1.Source;
                ImageSource imageRoundedSource2 = SelectedCurrencyImage2.Source;
                string currencyConversionText = $"{SelectedCurrencyTextBlock1.Text} to {SelectedCurrencyTextBlock2.Text}";
                string exchangeRateText = null;

                FavouriteListItem item = new FavouriteListItem();
                item.ImageRoundedSource1 = imageRoundedSource1;
                item.ImageRoundedSource2 = imageRoundedSource2;
                item.CurrencyConversionText = currencyConversionText;
                item.ExchangeRateText = exchangeRateText;

                favouriteList.Add(item);
                UpdateNotFoundFavouritesVisibility();

                isFirstImageSelected = false;
                isSecondImageSelected = false;

                DeleteSelectedCurrencyButton1.Visibility = Visibility.Collapsed;
                DeleteSelectedCurrencyButton2.Visibility = Visibility.Collapsed;

                SelectCurrencyTextBox1.IsEnabled = true;
                SelectCurrencyTextBox2.IsEnabled = true;

                SelectedCurrencyImage1.DataContext = null;
                SelectedCurrencyTextBlock1.DataContext = null;
                SelectedCurrencyNameTextBlock1.DataContext = null;
                SelectCurrencyTextBox1.Text = Strings.SelectCurrencyText1;

                SelectedCurrencyImage2.DataContext = null;
                SelectedCurrencyTextBlock2.DataContext = null;
                SelectedCurrencyNameTextBlock2.DataContext = null;
                SelectCurrencyTextBox2.Text = Strings.SelectCurrencyText2;
            }
        }

        private void DeleteSelectedCurrencyButton1_Click(object sender, RoutedEventArgs e)
        {
            if (isFirstImageSelected)
            {
                DeleteSelectedCurrencyButton1.Visibility = Visibility.Collapsed;
                SelectedCurrencyImage1.DataContext = null;
                SelectedCurrencyTextBlock1.DataContext = null;
                SelectedCurrencyNameTextBlock1.DataContext = null;
                isFirstImageSelected = false;
                SelectCurrencyTextBox1.IsEnabled = true;
                SelectCurrencyTextBox1.Text = Strings.SelectCurrencyText1;
            }
        }

        private void DeleteSelectedCurrencyButton2_Click(object sender, RoutedEventArgs e)
        {
            if (isSecondImageSelected)
            {
                DeleteSelectedCurrencyButton2.Visibility = Visibility.Collapsed;
                SelectedCurrencyImage2.DataContext = null;
                SelectedCurrencyTextBlock2.DataContext = null;
                SelectedCurrencyNameTextBlock2.DataContext = null;
                isSecondImageSelected = false;
                SelectCurrencyTextBox2.IsEnabled = true;
                SelectCurrencyTextBox2.Text = Strings.SelectCurrencyText2;
            }
        }
    }
}

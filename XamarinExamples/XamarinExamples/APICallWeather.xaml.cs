using Flurl;
using Flurl.Http;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamples.Model;
using XamarinExamples.Service;

namespace XamarinExamples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class APICallWeather : ContentPage
    {
        APIService client;
        public APICallWeather()
        {
            InitializeComponent();

            Tempratures = new ObservableCollection<string> { "" };
            BindingContext = this;

            client = APIService.DefaultApiService;

            ButtonFetch.Clicked += async (sender, e) =>
            {
                await GetFlurlWeatherAsync();
            };
        }

        private async Task GetApiServiceWeatherAsync()
        {
            if (city_input.Text != null)
            {
                Task.Run(async () =>
                {
                    var result = await client.GetWeather(city_input.Text);
                    Debug.WriteLine(string.Format("Current temprature of {0} is {1} Degrees Celcius", result.name, result.main.temp));

                    this.temp_city_name.Text = result.name;
                    this.temp_degree.Text = string.Format("{0} Degree Celcius", result.main.temp);
                    Tempratures.Add(string.Format("{0} | {1} Degree Celcius", result.name, result.main.temp));
                }).GetAwaiter().GetResult();
            }
            else
            {
                await DisplayAlert("Warnning", "Please enter the city name to get weather details", "OK");
            }
        }

        private async Task GetFlurlWeatherAsync()
        {
            if (city_input.Text != null)
            {
                var url = new Url(Constant.BASE_URL)
                    .SetQueryParams(new
                    {
                        APPID = Constant.API_KEY,
                        q = city_input.Text,
                        units = "metric"
                    });
                using (var fc = new FlurlClient())
                {
                    var result = await url.WithClient(fc).GetJsonAsync<WeatherDetails>();
                    temp_city_name.Text = result.name;
                    temp_degree.Text = result.main.temp + " Celsius";
                    Tempratures.Add(result.name + " " + result.main.temp + " Celsius");
                }
            }
            else
            {
                await DisplayAlert("Warnning", "Please enter the city name to get weather details", "OK");
            }
        }

        public ObservableCollection<string> Tempratures { get; private set; }
    }
}
using Flurl;
using Flurl.Http;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExamples.Model;

namespace XamarinExamples.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class APICallWeather : ContentPage
    {
        public APICallWeather()
        {
            InitializeComponent();

            Tempratures = new ObservableCollection<string> { "" };
            BindingContext = this;

        
            ButtonFetch.Clicked += async (sender, e) =>
            {
                await GetFlurlWeatherAsync();
            };
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
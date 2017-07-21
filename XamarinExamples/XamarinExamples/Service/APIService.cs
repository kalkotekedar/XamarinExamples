using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XamarinExamples.Model;

namespace XamarinExamples.Service
{
    public partial class APIService
    {
        public static APIService apiService = new APIService();

        public static APIService DefaultApiService
        {
            get { return apiService; }

            set { apiService = value; }
        }

        public async Task<WeatherDetails> GetWeather(string city_name)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(Constant.BASE_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("/weather?q=" + city_name + "&APPID=" + Constant.API_KEY);
                    if (response.IsSuccessStatusCode)
                    {
                        var resString = await response.Content.ReadAsStringAsync();

                        WeatherDetails weather = JsonConvert.DeserializeObject<WeatherDetails>(resString);
                        return weather;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return null;
        }
    }
}
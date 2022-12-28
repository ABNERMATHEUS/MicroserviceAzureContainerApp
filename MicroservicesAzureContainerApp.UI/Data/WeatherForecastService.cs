namespace MicroservicesAzureContainerApp.UI.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public WeatherForecastService(IHttpClientFactory httpClientFactory, IConfiguration configuration = null)
        {
            _httpClientFactory=httpClientFactory;
            _configuration=configuration;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("");
                var url = $"{_configuration.GetSection("URL_API").Value}/WeatherForecast";
                var response = await client.GetFromJsonAsync<WeatherForecast[]>(url);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
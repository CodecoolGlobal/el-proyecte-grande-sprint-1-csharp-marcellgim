using Microsoft.AspNetCore.Mvc.Testing;

namespace BpRobotics.Tests
{
    public class Tests
    {
        private HttpClient _httpClient;
        [SetUp]
        public void Setup()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Test]
        public async Task Test1()
        {
            var response = await _httpClient.GetAsync("WeatherForecast/hello-world");
            string result = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("Hello World!", result);
        }
    }
}
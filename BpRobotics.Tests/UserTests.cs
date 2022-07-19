using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.OpenApi.Expressions;

namespace BpRobotics.Tests
{
    public class UserTests
    {
        private readonly HttpClient _httpClient;
        private readonly string _dataFile = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ExpectedData.json");
        private readonly JsonDocument _expectedJson;
        public UserTests()
        {
            TestingWebAppFactory<Program> factory = new TestingWebAppFactory<Program>();
            _httpClient = factory.CreateClient();

            var jsonString = File.ReadAllText(_dataFile);
            _expectedJson = JsonDocument.Parse(jsonString);
        }

        ~UserTests()
        {
            _expectedJson.Dispose();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllTest()
        {
            // Arrange
            var expected = _expectedJson.RootElement.GetProperty("GetAllUsers").GetRawText();

            // Act
            var response = await _httpClient.GetAsync("api/users");

            // Assert
            response.EnsureSuccessStatusCode();


            string result = await response.Content.ReadAsStringAsync();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
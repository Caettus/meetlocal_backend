using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using backend.application.Models;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Net;

namespace Backend.IntegrationTests
{
    [TestFixture]
    public class GatheringIntegrationTests
    {
        private WebApplicationFactory<Program> _factory;
        public HttpClient _client { get; private set; }

        [SetUp]
        public void SetUp()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureAppConfiguration((context, config) =>
                    {
                        config.AddJsonFile(configPath);
                    });
                });
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            if (_client != null)
            {
                _client.Dispose();
            }

            if (_factory != null)
            {
                _factory.Dispose();
            }
        }


        [Test]
        public async Task AddGathering_ValidInput_ReturnsOk()
        {
            // Arrange
            var gathering = new gatheringModel
            {
                GatheringName = "Test Gathering",
                GatheringDate = "2021-01-01",
                GatheringTime = "12:00",
                GatheringLocation = "Test Location",
                GatheringDescription = "Test Description",
                GatheringOrganiser = "Test Organiser",
                GatheringCategory = "Test Category"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/gathering", gathering);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

        }
    }
}
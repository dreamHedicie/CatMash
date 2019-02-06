using CatMash.WebAPI.Services;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using System.Net.Http.Headers;
using System.Text;

namespace CathMash.Tests
{
    [TestFixture]
    public class LatelierClientTest
    {
        private Uri _requestUri;

        [Test]
        public async Task ShouldReturnAllImages()
        {
            var handler = new HttpMessageHandlerMock(SendMock);
            var httpClient = new HttpClient(handler);
            var latelierClient = new LatelierClient(httpClient);

            var images = await latelierClient.GetImages();

            Assert.That(_requestUri, Is.EqualTo(new Uri("https://latelier.co/data/cats.json")));
            images.Should().BeEquivalentTo(ImagesMock.Images);
        }

        private HttpResponseMessage SendMock(HttpRequestMessage message, CancellationToken cancellationToken)
        {
            var catsJson = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "cats.json"));
            _requestUri = message.RequestUri;
            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(catsJson, Encoding.UTF8, "application/json")
            };
            return response;
        }
    }
}

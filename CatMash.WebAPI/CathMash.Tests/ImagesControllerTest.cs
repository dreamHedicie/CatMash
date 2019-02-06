using CathMash.Tests;
using CatMash.WebAPI.Controllers;
using CatMash.WebAPI.Models;
using CatMash.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ImagesControllerTest
    {
        private ImagesController _controller;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var latelierClient = Substitute.For<ILatelierClient>();
            latelierClient.GetImages().Returns(ImagesMock.Images);
            _controller = new ImagesController(latelierClient);
        }

        [Test]
        public async Task ShouldReturnsImageWithGoodIdIfItExists()
        {
            var result = (await _controller.Get("MTgwODA3MA")).Result;

            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That((result as OkObjectResult).Value, Is.EqualTo("http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"));
        }

        [Test]
        public async Task ShouldReturnsNotFoundErrorIfItDoesntExist()
        {
            var result = (await _controller.Get("inexistant")).Result;

            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
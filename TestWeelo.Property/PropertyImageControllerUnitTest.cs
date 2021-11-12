using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Api.Controllers;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace TestWeelo.Property
{
    [TestFixture]
    public class PropertyImageControllerUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_Property_Image_Post_Valid()
        {
            var mock = new Mock<IPropertyImageAppService>();
            ImageDto propertyImage = new() { File = "mi imagen en base64", PropertyCode = "1234" };
            mock.Setup(c => c.AddImgeToPropertyAsync(propertyImage)).Returns(Task.CompletedTask);

            ImageController controller = new(mock.Object);
            var result = await controller.Post(propertyImage);

            Assert.IsTrue(((StatusCodeResult)result).StatusCode == 200, "imagen no se pudo insertar");
        }
    }
}

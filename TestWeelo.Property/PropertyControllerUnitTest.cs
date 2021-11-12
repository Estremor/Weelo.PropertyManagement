using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weelo.PropertyManagement.Api.Controllers;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace TestWeelo.Property
{
    [TestFixture]
    public class PropertyControllerUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_Property_Valid()
        {
            var mock = new Mock<IPropertyAppService>();
            string propertyObj = "{  \"name\": \"Word Trade center\",  \"address\": \"carrera 90 bis #83c - 28\",  \"price\": 556.0,  \"codeInternal\": \"54455545\",  \"year\": 1995,  \"ownerDocument\": \"1010211905\"}";
            PropertyDataDto property = Newtonsoft.Json.JsonConvert.DeserializeObject<PropertyDataDto>(propertyObj);
            mock.Setup(c => c.SavePropertyAsync(property)).Returns(Task.CompletedTask);

            PropertyController controller = new PropertyController(mock.Object);
            var dto = await controller.Post(property);

            Assert.IsTrue(((ObjectResult)dto).StatusCode == 200, "Propiedad no se pudo insertar");
        }

        [Test]
        public async Task Test_Property_Put_Valid()
        {
            var mock = new Mock<IPropertyAppService>();
            string propertyObj = "{  \"name\": \"Word Trade center\",  \"address\": \"carrera 90 bis #83c - 28\",  \"price\": 556.0,  \"codeInternal\": \"54455545\",  \"year\": 1995,  \"ownerDocument\": \"1010211905\"}";
            PropertyTraceDto property = Newtonsoft.Json.JsonConvert.DeserializeObject<PropertyTraceDto>(propertyObj);
            mock.Setup(c => c.UpdatePropertyAsync(property)).Returns(Task.CompletedTask);

            PropertyController controller = new PropertyController(mock.Object);
            var dto = await controller.Put(property);

            Assert.IsTrue(((StatusCodeResult)dto).StatusCode == 200, "Propiedad no Actualizada");
        }

        [Test]
        public async Task Test_Property_Patch_Valid()
        {
            var mock = new Mock<IPropertyAppService>();
            var price = new PriceDto { InernalCode = "string", Price = 20 };
            mock.Setup(c => c.UpdatePriceAsync(price)).Returns(Task.CompletedTask);

            PropertyController controller = new PropertyController(mock.Object);
            var dto = await controller.UpdatePrice(price);

            Assert.IsTrue(((StatusCodeResult)dto).StatusCode == 200, "no se pudo actualizar el precio");
        }
    }
}

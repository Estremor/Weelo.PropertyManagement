using Moq;
using System;
using NUnit.Framework;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Services;
using Weelo.PropertyManagement.Domain.IRepository;
using entity = Weelo.PropertyManagement.Domain.Entities;

namespace TestWeelo.Property
{
    public class PropertyImageDomainUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_Property_Image_SaveImage_Valid()
        {
            Mock<IRepository<entity.Property>> mockproperty = new();
            Mock<IRepository<entity.PropertyImage>> mockImage = new();

            var img = new entity.PropertyImage { Enabled = true, File = Array.Empty<byte>(), IdProperty = Guid.NewGuid() };
            mockproperty.Setup(c => c.Entity.Find(img.IdProperty)).Returns(new entity.Property { });

            PropertyImageDomainService service = new(mockImage.Object, mockproperty.Object);
            var result = await service.SaveImageAsync(img);

            Assert.IsTrue(result.IsSuccessful, "Ocurrio un error al guaradar una imagen");

        }

        [Test]
        public async Task Test_Property_Image_SaveImage_Not_Valid()
        {
            Mock<IRepository<entity.Property>> mockproperty = new();
            Mock<IRepository<entity.PropertyImage>> mockImage = new();

            var img = new entity.PropertyImage { Enabled = true, File = Array.Empty<byte>(), IdProperty = Guid.NewGuid() };
            mockproperty.Setup(c => c.Entity.Find(img.IdProperty));

            PropertyImageDomainService service = new(mockImage.Object, mockproperty.Object);
            var result = await service.SaveImageAsync(img);

            Assert.IsTrue(!result.IsSuccessful, "Ocurrio un error al guaradar una imagen");

        }
    }
}

using Moq;
using System;
using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Api.Controllers;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace TestWeelo.Property
{
    [TestFixture]
    public class OwnerControllerUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test_Owner_Post_Valid()
        {
            var mock = new Mock<IOwnerAppService>();
            OwnerDto owner = new() { Address = "test adress", Birthday = DateTime.Now.AddYears(-20).ToString(), Document = "1010211", Name = "text", Photo = "" };
            mock.Setup(sp => sp.SaveAsync(owner)).Returns(Task.CompletedTask);

            OwnerController controller = new(mock.Object);
            var result = await controller.Post(owner);

            Assert.IsTrue(((StatusCodeResult)result).StatusCode == 200);
        }
    }
}

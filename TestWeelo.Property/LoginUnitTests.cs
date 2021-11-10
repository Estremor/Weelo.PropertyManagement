using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Api.Controllers;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace TestWeelo.Property
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test_Login_User_Not_Valid()
        {
            var mock = new Mock<ILoginAppService>();
            string userName = "test";
            string password = "123";
            mock.Setup(sp => sp.LoginUserAsync(userName, password)).Returns(Task.FromResult(new UserDto { Token = "", UserName = "test" }));

            LoginController controller = new LoginController(mock.Object);
            var dto = await controller.Get(userName, password);

            Assert.IsTrue(string.IsNullOrWhiteSpace(dto.Token), "usuario se pudo loguear con datos errados");
        }
        [Test]
        public async Task Test_Login_User_Valid()
        {
            var mock = new Mock<ILoginAppService>();
            string userName = "test";
            string password = "123";
            mock.Setup(sp => sp.LoginUserAsync(userName, password)).Returns(Task.FromResult(new UserDto { Token = "ste es mi token", UserName = "test" }));

            LoginController controller = new LoginController(mock.Object);
            var dto = await controller.Get(userName, password);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(dto.Token), "usuario no se pudo loguear verfificar login");
        }
    }
}
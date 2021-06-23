using Moq;
using NUnit;
using NUnit.Framework;
using Domain.Repositories;
using Infratructure.Repositories;
using Common.Config;
using Domain.Models;
using System.Linq;
using FluentAssertions;

namespace Tests.RepositoryTests
{
    [TestFixture]
    public class UserRepositoryTests {
        private IUserRepository _sut;
        private Mock<IAppConfig> _mockAppCofig;

        [SetUp]
        public void Setup () {
            _mockAppCofig = new Mock<IAppConfig>();

            _mockAppCofig.Setup(x => x.GetDbConnectionString()).Returns(Config.GetUnitTestConnectionString());

            _sut = new UserRepository(_mockAppCofig.Object);
        }

        [Test]
        public void GetUsers_Test() {
            //Arrange
            var user = new User {
                FullName = "Test Test",
                UserName = "Test",
                Email = "Email@Email.com"
            };
            var id = _sut.Add(user);

            //Act
            var result = _sut.GetUsers().ToList();

            //Assert
            result[0].Should().BeEquivalentTo(user);
            _mockAppCofig.VerifyAll();

            //Clean Up
            _sut.Delete(id);
        }

        [Test]
        public void Add_Test() {
            //Arrange
            var user = new User {
                FullName = "Test Test",
                UserName = "Test",
                Email = "Email@Email.com"
            };

            //Act
            var id = _sut.Add(user);
            var returnUser = _sut.FindById(id);

            //Assert
            returnUser.FullName.Should().BeEquivalentTo(user.FullName);
            returnUser.UserName.Should().BeEquivalentTo(user.UserName);
            returnUser.Email.Should().BeEquivalentTo(user.Email);

            //Clean Up
            _sut.Delete(id);
        }
    }   
}
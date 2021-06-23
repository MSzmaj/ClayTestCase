using NUnit;
using NUnit.Framework;
using Moq;
using FluentAssertions;
using Domain.Repositories;
using Application.Validators.Interfaces;
using AutoMapper;
using Application.Services.Interfaces;
using Application.Services;
using System.Collections.Generic;
using Application.Models;
using Domain.Models;

namespace Tests.ApplicationTests.Services {

    [TestFixture]
    public class UserServiceTests 
    {

        private Mock<IUserRepository> _mockUserRepository;
        private Mock<IUserValidator> _mockUserValidator;
        private Mock<IMapper> _mockMapper;
        private IUserService _sut;

        [SetUp]
        public void Setup() {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserValidator = new Mock<IUserValidator>();
            _mockMapper = new Mock<IMapper>();
            _sut = new UserService(_mockUserRepository.Object, _mockMapper.Object, _mockUserValidator.Object);
        }

        [Test]
        public void GetAllUsers_Test() {
            //Arrange
            var user = new User {
                UserName = "Test"
            };

            var userModel = new UserModel {
                UserName = "Test"
            };

            var users = new List<User> {
                user
            };

            var userModels = new List<UserModel> {
                userModel
            };

            _mockMapper.Setup(x => x.Map<UserModel>(user)).Returns(userModel);
            _mockUserRepository.Setup(x => x.GetUsers()).Returns(users);

            //Act
            var result = _sut.GetAllUsers();

            //Assert
            result.Should().BeEquivalentTo(userModels);
            _mockMapper.VerifyAll();
            _mockUserRepository.VerifyAll();
        }

        [Test]
        public void AddUser_Test() {
            //Arrange
            const string userName = "UserName";
            const string fullName = "Full Name";
            const string email = "Email";
            const int userId = 1;

            var userModel = new UserModel {
                UserName = userName,
                FullName = fullName,
                Email = email
            };

            var user = new User {
                UserName = userName,
                FullName = fullName,
                Email = email
            };

            _mockUserValidator.Setup(x => x.ValidateExistingUser(It.IsAny<UserModel>()));
            _mockMapper.Setup(x => x.Map<User>(userModel)).Returns(user);
            _mockUserRepository.Setup(x => x.Add(user)).Returns(userId);

            //Act
            var id = _sut.AddUser(userModel);

            //Assert
            _mockUserValidator.VerifyAll();
            _mockUserRepository.VerifyAll();
            _mockMapper.VerifyAll();
        }
    }
}
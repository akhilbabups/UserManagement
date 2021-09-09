using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Users.API.Controllers;
using Users.Domain.Interfaces.Services;
using Users.Test.MockResults;
using Xunit;

namespace Users.Test.Api
{
    public class UserControllerTest
    {
        private readonly UserController _userController;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<ILogger<UserController>> _loggerMock;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
            _loggerMock = new Mock<ILogger<UserController>>();
            _userController = new UserController(_userServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetUsersAsync_Success()
        {
            //Arrange
            _userServiceMock.Setup(m => m.GetUsersAsync()).ReturnsAsync(MockReturnResult.GetMockUsers());
            //Act
            var result = await _userController.GetUsersAsync();
            //Assert
            var res = result as OkObjectResult;
            Assert.Equal((result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
            Assert.NotEmpty(res.Value as IEnumerable<Domain.Models.User>);
            _userServiceMock.Verify(m => m.GetUsersAsync(), Times.Once);
        }

        [Fact]
        public async Task AddUserAsync_Success()
        {
            //Arrange
            var userPayload = MockReturnResult.GetNewUser();
            _userServiceMock.Setup(m => m.AddUserAsync(It.IsAny<Domain.Models.User>())).ReturnsAsync(MockReturnResult.GetNewUserResponse());
            //Act
            var result = await _userController.AddUserAsync(userPayload);
            //Assert
            var res = result as CreatedAtActionResult;
            Assert.Equal((result as CreatedAtActionResult).StatusCode, (int)System.Net.HttpStatusCode.Created);
            Assert.NotEmpty((res.Value as Domain.Models.User).Id);
            Assert.NotNull((res.Value as Domain.Models.User).Id);
            _userServiceMock.Verify(m => m.AddUserAsync(It.IsAny<Domain.Models.User>()), Times.Once);
        }

        [Fact]
        public async Task AddUserAsync_BadRequest_Failed()
        {
            //Arrange
            var userPayload = MockReturnResult.GetNewUser(false);
            _userServiceMock.Setup(m => m.AddUserAsync(It.IsAny<Domain.Models.User>())).ReturnsAsync(MockReturnResult.GetNewUserResponse());
            //Act
            var result = await _userController.AddUserAsync(userPayload);
            //Assert
            var res = result as BadRequestResult;
            Assert.Equal((result as BadRequestResult).StatusCode, (int)System.Net.HttpStatusCode.BadRequest);
            _userServiceMock.Verify(m => m.AddUserAsync(It.IsAny<Domain.Models.User>()), Times.Never);
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals(o.ToString(), "Invalid model")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once); ;
        }

        [Fact]
        public async Task AddUserAsync_ThrowsException_Failed()
        {
            //Arrange
            var userPayload = MockReturnResult.GetNewUser();
            _userServiceMock.Setup(m => m.AddUserAsync(It.IsAny<Domain.Models.User>())).ThrowsAsync(new Exception());

            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await _userController.AddUserAsync(userPayload));
            
            _userServiceMock.Verify(m => m.AddUserAsync(It.IsAny<Domain.Models.User>()), Times.Once);
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Add user failed")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once); ;
        }
    }
}

using Moq;
using System;
using System.Threading.Tasks;
using Users.Domain.Interfaces.Repository;
using Users.Domain.Services;
using Users.Test.MockResults;
using Xunit;

namespace Users.Test.Service
{
    public class UserServiceTest
    {
        private readonly UserService _userService;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetUsersAsync_Success_Test()
        {
            //Arrange
            var users = MockReturnResult.GetMockUsers();
            _userRepositoryMock.Setup(m => m.GetUsersAsync()).ReturnsAsync(users);
            //Act
            var result = await _userService.GetUsersAsync();
            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetUsersAsync_ReturnEmptyList_Test(bool isNull)
        {
            // Arrange
            _userRepositoryMock
                .Setup(m => m.GetUsersAsync())
                .ReturnsAsync(MockReturnResult.GetMockUsersNullOrEmptyList(isNull));

            // Act
            var result = await _userService.GetUsersAsync();

            // Assert
            if (isNull)
            {
                Assert.Null(result);
            }
            else
            {
                Assert.Empty(result);
            }
        }

        [Fact]
        public async Task GetUsersAsync_ThrowsException_Test()
        {
            //Arrange
            _userRepositoryMock.Setup(m => m.GetUsersAsync()).ThrowsAsync(It.IsAny<Exception>());
            //Act & Assert
            await Assert.ThrowsAnyAsync<Exception>(async () => await _userService.GetUsersAsync());
        }
    }
}
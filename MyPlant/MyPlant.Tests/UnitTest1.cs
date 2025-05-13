using Moq;
using MyPlant.Services;
using MyPlant.Services.Interfaces;

namespace MyPlant.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task NotifyUser_ShouldCallSendEmail()
        {
            // Arrange
            var emailSenderMock = new Mock<IEmailSenderService>();
            var service = new NotificationService(emailSenderMock.Object);
            var testEmail = "user@example.com";

            // Act
            await service.NotifyNewUser(testEmail);

            // Assert
            emailSenderMock.Verify(
                e => e.SendEmail(
                    testEmail,
                    It.Is<string>(s => s == "Welcome!"),
                    It.Is<string>(b => b.Contains("Thanks for signing up!"))),
                Times.Once);
        }
    }
}
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
            var emailSenderServiceMock = new Mock<IEmailSenderService>();
            var logServiceMock = new Mock<ILogService>();
            var service = new NotificationService(emailSenderServiceMock.Object, logServiceMock.Object);
            var testEmail = "user@example.com";

            // Act
            await service.NotifyNewUser(testEmail);

            // Assert
            emailSenderServiceMock.Verify(
                e => e.SendEmail(
                    testEmail,
                    It.Is<string>(s => s == "Welcome!"),
                    It.Is<string>(b => b.Contains("Thanks for signing up!"))),
                Times.Once);
        }

        [Fact]
        public async Task NotifyUser_ShouldLogSucessNewUser()
        {
            // Arrange
            var emailSenderServiceMock = new Mock<IEmailSenderService>();
            var logServiceMock = new Mock<ILogService>();
            var service = new NotificationService(emailSenderServiceMock.Object, logServiceMock.Object);
            var testEmail = "user@example.com";
            var testLog = "Envío email exitoso";

            // Act
            await service.NotifyNewUser(testEmail);

            // Assert
            logServiceMock.Verify(
                e => e.Log(
                    testLog),
                Times.Once);
        }

        [Fact]
        public async Task NotifyUser_ShouldLogFailedNewUser()
        {
            // Arrange
            var emailSenderServiceMock = new Mock<IEmailSenderService>();
            var logServiceMock = new Mock<ILogService>();
            var service = new NotificationService(emailSenderServiceMock.Object, logServiceMock.Object);
            var testEmail = "user@example.com";
            var testLog = "Ocurrió un error al enviar el email";

            // Simula error al enviar correo
            emailSenderServiceMock
                .Setup(x => x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("SMTP error"));

            // Act (capturando la excepción)
            await Assert.ThrowsAsync<Exception>(() => service.NotifyNewUser(testEmail));

            // Assert
            logServiceMock.Verify(
                e => e.Log(
                    testLog),
                Times.Once);
        }
    }
}
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ExecutionTime.Domain.Entities.ExecutionInformation;
using ExecutionTime.Domain.Manager;
using ExecutionTime.Domain.Repository.Interfaces;

namespace ExecutionTime.Domain.Tests.Manager
{
    [TestFixture]
    public class when_getting_application_ip
    {
        [Test]
        public void should_return_correct_ip()
        {
            //Arrange
            var executionInformationRepository = new Mock<IExecutionInformationRepository>();
            executionInformationRepository.Setup(e => e.GetApplicationIp("TestApplication"))
                .Returns(new ExecutionInformation() { ApplicationName = "TestApplication", IpAddress = "192.168.2.1" });
            ExecutionInformationManager executionInformationManager = new ExecutionInformationManager(executionInformationRepository.Object);

            //Act
            var ip = executionInformationManager.GetApplicationIp("TestApplication");

            //Assert
            ip.Should().Be("192.168.2.1");
        }

        [Test]
        public void should_return_null_with_no_application_name()
        {
            //Arrange
            var executionInformationRepository = new Mock<IExecutionInformationRepository>();
            executionInformationRepository.Setup(e => e.GetApplicationIp("TestApplication"));

            ExecutionInformationManager executionInformationManager = new ExecutionInformationManager(executionInformationRepository.Object);

            //Act
            var ip = executionInformationManager.GetApplicationIp("TestApplication");

            //Assert
            ip.Should().Be(null);
        }
    }
}

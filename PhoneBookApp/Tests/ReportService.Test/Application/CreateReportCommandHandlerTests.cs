using FluentAssertions;
using Moq;
using ReportService.Application.Features.Commands;
using ReportService.Application.Features.Handlers;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;

namespace ReportService.Test.Application
{
    public class CreateReportCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateReportCommandHandler _handler;

        public CreateReportCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateReportCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateReportSuccessfully()
        {
            // Arrange
            var command = new CreateReportCommand();

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            _unitOfWorkMock.Verify(x => x.ReportRepository.AddAsync(It.IsAny<Report>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}

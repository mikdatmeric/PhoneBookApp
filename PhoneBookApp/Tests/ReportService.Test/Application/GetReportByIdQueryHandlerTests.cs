using AutoMapper;
using FluentAssertions;
using Moq;
using ReportService.Application.DTOs;
using ReportService.Application.Features.Handlers;
using ReportService.Application.Features.Queries;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;

namespace ReportService.Test.Application
{
    public class GetReportByIdQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetReportByIdQueryHandler _handler;

        public GetReportByIdQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetReportByIdQueryHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnReportSuccessfully()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            _unitOfWorkMock.Setup(x => x.ReportRepository.GetByIdAsync(reportId))
                .ReturnsAsync(new Report());

            _mapperMock.Setup(x => x.Map<ReportDto>(It.IsAny<Report>()))
                .Returns(new ReportDto());

            var query = new GetReportByIdQuery(reportId);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }
    }
}

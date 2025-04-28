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
    public class GetAllReportsQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllReportsQueryHandler _handler;

        public GetAllReportsQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllReportsQueryHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnReportListSuccessfully()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.ReportRepository.GetAllAsync())
                .ReturnsAsync(new List<Report> { new Report() });

            _mapperMock.Setup(x => x.Map<List<ReportDto>>(It.IsAny<List<Report>>()))
                .Returns(new List<ReportDto> { new ReportDto() });

            var query = new GetAllReportsQuery();

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
        }
    }
}

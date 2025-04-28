using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using ReportService.Application.DTOs;
using ReportService.Application.Services.Concrete;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;

namespace ReportService.Test.Services
{
    public class ReportServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ReportManager _reportService;

        public ReportServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _reportService = new ReportManager(_mediatorMock.Object);
        }

        [Fact]
        public async Task CreateReportAsync_ShouldCreateReportSuccessfully()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.ReportRepository.AddAsync(It.IsAny<Report>())).Returns(Task.CompletedTask);

            // Act
            var result = await _reportService.CreateReportAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            _unitOfWorkMock.Verify(x => x.ReportRepository.AddAsync(It.IsAny<Report>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetReportByIdAsync_ShouldReturnReportSuccessfully()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            _unitOfWorkMock.Setup(x => x.ReportRepository.GetByIdAsync(reportId))
                .ReturnsAsync(new Report());

            _mapperMock.Setup(x => x.Map<ReportDto>(It.IsAny<Report>()))
                .Returns(new ReportDto());

            // Act
            var result = await _reportService.GetReportByIdAsync(reportId);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllReportsAsync_ShouldReturnReportListSuccessfully()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.ReportRepository.GetAllAsync())
                .ReturnsAsync(new List<Report> { new Report() });

            _mapperMock.Setup(x => x.Map<List<ReportDto>>(It.IsAny<List<Report>>()))
                .Returns(new List<ReportDto> { new ReportDto() });

            // Act
            var result = await _reportService.GetAllReportsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
        }
    }
}

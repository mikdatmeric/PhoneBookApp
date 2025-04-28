using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using ReportService.Application.DTOs;
using ReportService.Application.Features.Commands;
using ReportService.Application.Features.Queries;
using ReportService.Application.Services.Concrete;
using ReportService.Domain.Entities;
using ReportService.Infrastructure.Persistence.UnitOfWork.Abstract;
using Shared.BaseResponses.Response;

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
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateReportCommand>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new BaseResponse<Guid>(Guid.NewGuid()));

            // Act
            var result = await _reportService.CreateReportAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            // Sadece mediator'ın çalıştığını kontrol et
            _mediatorMock.Verify(m => m.Send(It.IsAny<CreateReportCommand>(), default), Times.Once);
        }

        [Fact]
        public async Task GetReportByIdAsync_ShouldReturnReportSuccessfully()
        {
            // Arrange
            var reportId = Guid.NewGuid();
            _unitOfWorkMock.Setup(x => x.ReportRepository.GetByIdAsync(reportId))
                .ReturnsAsync(new Report());

            _mediatorMock.Setup(x => x.Send(It.IsAny<GetReportByIdQuery>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new BaseResponse<ReportDto>(new ReportDto()));

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
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetAllReportsQuery>(), It.IsAny<CancellationToken>()))
                       .ReturnsAsync(new BaseResponse<List<ReportDto>>(
                           new List<ReportDto>
                           {
                               new ReportDto() // en az 1 öğe!
                           }));

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

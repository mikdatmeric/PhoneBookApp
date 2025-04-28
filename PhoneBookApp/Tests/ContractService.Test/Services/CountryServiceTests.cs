using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Services.Abstract;
using ContactService.Application.Services.Concrete;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using MediatR;
using Moq;
using Shared.BaseResponses.Response;

namespace ContactService.Test.Services
{
    public class CountryServiceTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ICountryService _countryService;

        public CountryServiceTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _countryService = new CountryService(_mediatorMock.Object, _unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetAllCountries_Should_Return_Success()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<List<CountryDto>>(new List<CountryDto>()));

            // Act
            var result = await _countryService.GetAllCountriesAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetCountryById_Should_Return_Success()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<CountryDto>(new CountryDto { Id = id }));

            // Act
            var result = await _countryService.GetCountryByIdAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public void CheckCountryExists_Should_Return_True()
        {
            // Arrange
            var countries = new List<Domain.Entities.Country>
            {
                new Domain.Entities.Country { Id = Guid.NewGuid(), Name = "Turkey", PhoneCode = "+90" }
            }.AsQueryable();

            _unitOfWorkMock.Setup(u => u.CountryRepository.GetAllQueryable())
                .Returns(countries);

            var existingId = countries.First().Id;

            // Act
            var exists = _countryService.CheckCountryExists(existingId);

            // Assert
            exists.Should().BeTrue();
        }
    }
}

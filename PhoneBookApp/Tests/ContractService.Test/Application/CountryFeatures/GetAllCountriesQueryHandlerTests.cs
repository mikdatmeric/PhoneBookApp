using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.CountryFeatures.Handlers;
using ContactService.Application.Features.CountryFeatures.Queries;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.Contexts;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ContactService.Test.Application.CountryFeatures
{
    public class GetAllCountriesQueryHandlerTests
    {
        private readonly Mock<ContactDbContext> _contextMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllCountriesQueryHandler _handler;

        public GetAllCountriesQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: "ContactDB")
                .Options;

            var context = new ContactDbContext(options);
            _contextMock = new Mock<ContactDbContext>(options);
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllCountriesQueryHandler(context, _mapperMock.Object);  // dikkat!
        }

        [Fact]
        public async Task Handle_ShouldReturnCountriesSuccessfully()
        {
            // Arrange
            var countries = new List<Country> { new Country { Id = Guid.NewGuid(), Name = "Turkey", PhoneCode = "+90" } };
            _mapperMock.Setup(x => x.Map<List<CountryDto>>(It.IsAny<List<Country>>()))
                .Returns(new List<CountryDto>());

            // Act
            var result = await _handler.Handle(new GetAllCountriesQuery(), default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }

}

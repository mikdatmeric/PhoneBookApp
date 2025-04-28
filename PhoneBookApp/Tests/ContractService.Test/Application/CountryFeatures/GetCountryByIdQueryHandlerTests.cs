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
    public class GetCountryByIdQueryHandlerTests
    {
        private readonly ContactDbContext _context;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetCountryByIdQueryHandler _handler;

        public GetCountryByIdQueryHandlerTests()
        {
            var options = new DbContextOptionsBuilder<ContactDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // her test için temiz db
                .Options;

            _context = new ContactDbContext(options);
            _mapperMock = new Mock<IMapper>();
            _handler = new GetCountryByIdQueryHandler(_context, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnCountrySuccessfully()
        {
            // Arrange
            var countryId = Guid.NewGuid();
            var country = new Country
            {
                Id = countryId,
                Name = "Turkey",
                PhoneCode = "+90"
            };

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            _mapperMock.Setup(x => x.Map<CountryDto>(It.IsAny<Country>()))
                       .Returns(new CountryDto { Id = countryId, Name = "Turkey", PhoneCode = "+90" });

            var query = new GetCountryByIdQuery(countryId);

            // Act
            var result = await _handler.Handle(query, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(countryId);
            result.Data.Name.Should().Be("Turkey");
        }
    }

}

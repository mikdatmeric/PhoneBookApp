using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Handlers;
using ContactService.Application.Features.PersonFeatures.Queries;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;

namespace ContactService.Test.Application.PersonFeatures
{
    public class GetAllPersonsQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetAllPersonsQueryHandler _handler;

        public GetAllPersonsQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllPersonsQueryHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfPersons()
        {
            // Arrange
            _unitOfWorkMock.Setup(x => x.PersonRepository.GetAllAsync())
                .ReturnsAsync(new List<Person> { new Person() });

            _mapperMock.Setup(x => x.Map<List<PersonDto>>(It.IsAny<List<Person>>()))
                .Returns(new List<PersonDto>());

            // Act
            var result = await _handler.Handle(new GetAllPersonsQuery(), default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

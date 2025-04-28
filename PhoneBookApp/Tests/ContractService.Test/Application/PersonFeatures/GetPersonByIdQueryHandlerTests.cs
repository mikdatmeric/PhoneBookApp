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
    public class GetPersonByIdQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetPersonByIdQueryHandler _handler;

        public GetPersonByIdQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetPersonByIdQueryHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnPerson()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var person = new Person { Id = personId };

            _unitOfWorkMock.Setup(x => x.PersonRepository.GetByIdAsync(personId)).ReturnsAsync(person);
            _mapperMock.Setup(x => x.Map<PersonDto>(It.IsAny<Person>())).Returns(new PersonDto { Id = personId });

            // Act
            var result = await _handler.Handle(new GetPersonByIdQuery(personId), default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

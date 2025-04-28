using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Features.PersonFeatures.Handlers;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;

namespace ContactService.Test.Application.PersonFeatures
{
    public class UpdatePersonCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdatePersonCommandHandler _handler;

        public UpdatePersonCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new UpdatePersonCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdatePersonSuccessfully()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var existingPerson = new Person { Id = personId };
            var command = new UpdatePersonCommand { Person = new UpdatePersonCommandDto { Id = personId, FirstName = "Updated", LastName = "User" } };

            _unitOfWorkMock.Setup(x => x.PersonRepository.GetByIdAsync(personId)).ReturnsAsync(existingPerson);
            _mapperMock.Setup(x => x.Map(It.IsAny<UpdatePersonCommand>(), It.IsAny<Person>()));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

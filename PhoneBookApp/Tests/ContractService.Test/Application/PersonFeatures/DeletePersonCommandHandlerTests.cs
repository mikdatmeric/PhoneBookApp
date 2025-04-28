using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Features.PersonFeatures.Handlers;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;

namespace ContactService.Test.Application.PersonFeatures
{
    public class DeletePersonCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeletePersonCommandHandler _handler;

        public DeletePersonCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeletePersonCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeletePersonSuccessfully()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var existingPerson = new Person { Id = personId };

            _unitOfWorkMock.Setup(x => x.PersonRepository.GetByIdAsync(personId)).ReturnsAsync(existingPerson);
            _unitOfWorkMock.Setup(x => x.PersonRepository.DeleteAsync(existingPerson));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(new DeletePersonCommand(personId), default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

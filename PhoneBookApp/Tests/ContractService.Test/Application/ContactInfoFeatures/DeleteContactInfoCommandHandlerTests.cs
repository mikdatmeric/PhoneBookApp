using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Features.ContactInfoFeatures.Handlers;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;

namespace ContactService.Test.Application.ContactInfoFeatures
{
    public class DeleteContactInfoCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly DeleteContactInfoCommandHandler _handler;

        public DeleteContactInfoCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new DeleteContactInfoCommandHandler(_unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteContactInfoSuccessfully()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            var existingContact = new ContactInfo { Id = contactId };

            _unitOfWorkMock.Setup(x => x.ContactInfoRepository.GetByIdAsync(contactId)).ReturnsAsync(existingContact);
            _unitOfWorkMock.Setup(x => x.ContactInfoRepository.DeleteAsync(existingContact));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(new DeleteContactInfoCommand(contactId), default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }


}

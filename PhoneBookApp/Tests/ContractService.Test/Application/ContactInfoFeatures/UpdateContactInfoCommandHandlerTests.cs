using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Features.ContactInfoFeatures.Handlers;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Test.Application.ContactInfoFeatures
{
    public class UpdateContactInfoCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateContactInfoCommandHandler _handler;

        public UpdateContactInfoCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new UpdateContactInfoCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateContactInfoSuccessfully()
        {
            // Arrange
            var contactId = Guid.NewGuid();
            var existingContact = new ContactInfo { Id = contactId };

            _unitOfWorkMock.Setup(x => x.ContactInfoRepository.GetByIdAsync(contactId)).ReturnsAsync(existingContact);
            _mapperMock.Setup(x => x.Map(It.IsAny<UpdateContactInfoCommand>(), existingContact));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            var command = new UpdateContactInfoCommand
            {
                ContactInfo = new UpdateContactInfoCommandDto
                {
                    Id = contactId,
                    Type = ContactType.PhoneNumber.ToString(),
                    Content = "+905444444444"
                }
            };

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }


}

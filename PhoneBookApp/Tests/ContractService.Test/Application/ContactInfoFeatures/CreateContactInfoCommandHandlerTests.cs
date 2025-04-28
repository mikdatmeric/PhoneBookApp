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
    public class CreateContactInfoCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateContactInfoCommandHandler _handler;

        public CreateContactInfoCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateContactInfoCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateContactInfoSuccessfully()
        {
            // Arrange
            var command = new CreateContactInfoCommand
            {
                ContactInfo = new CreateContactInfoCommandDto
                {
                    PersonId = Guid.NewGuid(),
                    Content = "test@example.com",
                    Type = ContactType.Email.ToString()
                }
            };

            _mapperMock.Setup(x => x.Map<ContactInfo>(It.IsAny<CreateContactInfoCommand>())).Returns(new ContactInfo());
            _unitOfWorkMock.Setup(x => x.ContactInfoRepository.AddAsync(It.IsAny<ContactInfo>()));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }

}

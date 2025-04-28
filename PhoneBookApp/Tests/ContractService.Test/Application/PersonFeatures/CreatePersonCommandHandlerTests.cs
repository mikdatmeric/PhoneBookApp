using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.PersonFeatures.Commands;
using ContactService.Application.Features.PersonFeatures.Handlers;
using ContactService.Domain.Entities;
using ContactService.Infrastructure.Persistence.UnitOfWork.Abstract;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Test.Application.PersonFeatures
{
    public class CreatePersonCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreatePersonCommandHandler _handler;

        public CreatePersonCommandHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreatePersonCommandHandler(_unitOfWorkMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreatePersonSuccessfully()
        {
            // Arrange
            var command = new CreatePersonCommand{
                    Person = new CreatePersonCommandDto
                    {
                        Company = "Test Company",
                        FirstName = "Mikdat",
                        LastName = "Meriç",
                    }
            };

            _mapperMock.Setup(x => x.Map<Person>(It.IsAny<CreatePersonCommand>())).Returns(new Person());
            _unitOfWorkMock.Setup(x => x.PersonRepository.AddAsync(It.IsAny<Person>()));
            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

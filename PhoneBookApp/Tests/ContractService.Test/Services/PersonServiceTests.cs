using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Services.Abstract;
using ContactService.Application.Services.Concrete;
using FluentAssertions;
using MediatR;
using Moq;
using Shared.BaseResponses.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactService.Test.Services
{
    public class PersonServiceTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IPersonService _personService;

        public PersonServiceTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _personService = new PersonService(_mediatorMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreatePerson_ShouldReturnSuccess()
        {
            // Arrange
            var personDto = new CreatePersonCommandDto { FirstName = "Mikdat", LastName = "Meriç", Company = "Test Company" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<Guid>(Guid.NewGuid()));

            // Act
            var result = await _personService.CreatePersonAsync(personDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task UpdatePerson_ShouldReturnSuccess()
        {
            // Arrange
            var updateDto = new UpdatePersonCommandDto { Id = Guid.NewGuid(), FirstName = "Updated", LastName = "Person", Company = "UpdatedCompany" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<Guid>(updateDto.Id));

            // Act
            var result = await _personService.UpdatePersonAsync(updateDto);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task DeletePerson_ShouldReturnSuccess()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<Guid>(id));

            // Act
            var result = await _personService.DeletePersonAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetAllPersons_ShouldReturnSuccess()
        {
            // Arrange
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<List<PersonDto>>(new List<PersonDto>()));

            // Act
            var result = await _personService.GetAllPersonsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetPersonById_ShouldReturnSuccess()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mediatorMock.Setup(x => x.Send(It.IsAny<object>(), default))
                .ReturnsAsync(new BaseResponse<PersonDto>(new PersonDto { Id = id }));

            // Act
            var result = await _personService.GetPersonByIdAsync(id);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }
}

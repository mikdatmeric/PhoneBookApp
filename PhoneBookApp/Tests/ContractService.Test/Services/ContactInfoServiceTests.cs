using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Application.Features.ContactInfoFeatures.Commands;
using ContactService.Application.Features.ContactInfoFeatures.Queries;
using ContactService.Application.Features.CountryFeatures.Queries;
using ContactService.Application.Services.Abstract;
using ContactService.Application.Services.Concrete;
using FluentAssertions;
using MediatR;
using Moq;
using Shared.BaseResponses.Response;

namespace ContactService.Test.Services
{
    public class ContactInfoServiceTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoServiceTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _mapperMock = new Mock<IMapper>();
            _contactInfoService = new ContactInfoManager(_mediatorMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task CreateContactInfo_Should_Return_Success()
        {
            var contactInfoDto = new CreateContactInfoCommandDto
            {
                Type = "Email",
                Content = "test@text.com",
                PersonId = Guid.NewGuid()
            };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateContactInfoCommandDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse<Guid>(Guid.NewGuid()));

            var result = await _contactInfoService.CreateContactInfoAsync(contactInfoDto);

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task UpdateContactInfo_Should_Return_Success()
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateContactInfoCommandDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse<Guid>(Guid.NewGuid()));

            var result = await _contactInfoService.UpdateContactInfoAsync(new UpdateContactInfoCommandDto{
                Content = "aa@aa.com",
                Type = "Email",
                Id = Guid.NewGuid()
            });

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task DeleteContactInfo_Should_Return_Success()
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteContactInfoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse<Guid>(Guid.NewGuid()));

            var result = await _contactInfoService.DeleteContactInfoAsync(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetContactInfosByPersonId_Should_Return_Success()
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetContactInfosByPersonIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse<List<ContactInfoDto>>(new List<ContactInfoDto>()));

            var result = await _contactInfoService.GetContactInfosByPersonIdAsync(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }

        [Fact]
        public async Task GetContactInfoById_Should_Return_Success()
        {
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetContactInfoByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaseResponse<ContactInfoDto>(new ContactInfoDto()));

            var result = await _contactInfoService.GetContactInfoByIdAsync(Guid.NewGuid());

            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
        }
    }

}

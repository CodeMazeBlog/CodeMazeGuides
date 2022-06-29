using AccountOwnerServer;
using AccountOwnerServer.Controllers;
using AccountOwnerServerTests.Mocks;
using AutoMapper;
using Entities.DataTransferObjects;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Xunit;

namespace AccountOwnerServerTests
{
    public class OwnerControllerTests
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void WhenGettingAllOwners_ThenAllOwnersReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new OwnerController(logger, repositoryWrapperMock.Object, mapper);

            var result = ownerController.GetAllOwners() as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<IEnumerable<OwnerDto>>(result.Value);
            Assert.NotEmpty(result.Value as IEnumerable<OwnerDto>);
        }

        [Fact]
        public void GivenAnIdOfAnExistingOwner_WhenGettingOwnerById_ThenOwnerReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new OwnerController(logger, repositoryWrapperMock.Object, mapper);

            var id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            var result = ownerController.GetOwnerById(id) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<OwnerDto>(result.Value);
            Assert.NotNull(result.Value as OwnerDto);
        }

        [Fact]
        public void GivenAnIdOfANonExistingOwner_WhenGettingOwnerById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new OwnerController(logger, repositoryWrapperMock.Object, mapper);

            var id = Guid.Parse("f4f4e3bf-afa6-4399-87b5-a3fe17572c4d");
            var result = ownerController.GetOwnerById(id) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public void GivenValidRequest_WhenCreatingOwner_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = GetMapper();
            var logger = new LoggerManager();
            var ownerController = new OwnerController(logger, repositoryWrapperMock.Object, mapper);

            var owner = new OwnerForCreationDto()
            {
                Address = "TestAddress",
                Name = "TestName",
                DateOfBirth = new DateTime(1994, 7, 25)
            };
            var result = ownerController.CreateOwner(owner) as ObjectResult;

            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("OwnerById", (result as CreatedAtRouteResult)!.RouteName);
        }
    } 
}




using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TelecomWebServices.Controllers;
using TelecomWebServices.Interface;
using TelecomWebServices.Models;
using Xunit;

namespace TelecomWebServices.Test
{
    public class PhoneNumberControllerTests
    {
        [Fact]
        public void GetPhoneNumber_FindNumbers_ReturnListOfPhoneNumber()
        {
            //Arrange
            var mockRepo = new Mock<IPhoneNumber>();

            var numbers = new List<PhoneNumber>()
            {
                new PhoneNumber() { TelePhoneNumber = "0411111111", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111112", IsActivate = true}
            };

            mockRepo.Setup(repo => repo.GetPhoneNumbers())
                .Returns(numbers);

            var controller = new PhoneNumberController(mockRepo.Object);

            //Act
            var result = controller.GetPhoneNumber();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var numberList = Assert.IsType<List<PhoneNumber>>(okObjectResult.Value);
            Assert.Equal("0411111111", numberList[0].TelePhoneNumber);
            Assert.True(numberList[0].IsActivate);
        }

        [Fact]
        public void GetPhoneNumber_CouldNotFindNumbers_ReturnNotFound()
        {
            //Arrange
            var mockRepo = new Mock<IPhoneNumber>();

            mockRepo.Setup(repo => repo.GetPhoneNumbers())
                .Returns((IList<PhoneNumber>)null);

            var controller = new PhoneNumberController(mockRepo.Object);

            //Act
            var result = controller.GetPhoneNumber();

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void ActivatePhoneNumber_CorrectNumber_ReturnTrue()
        {
            //Arrange
            var mockRepo = new Mock<IPhoneNumber>();

            mockRepo.Setup(repo => repo.ActivePhoneNumber(It.IsAny<string>()))
                .Returns(true);

            var controller = new PhoneNumberController(mockRepo.Object);

            //Act
            var result = controller.ActivatePhoneNumber("test");

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var isActivate = Assert.IsType<bool>(okObjectResult.Value);
            Assert.True(isActivate);
        }

        [Fact]
        public void ActivatePhoneNumber_InCorrectNumber_ReturnFalse()
        {
            //Arrange
            var mockRepo = new Mock<IPhoneNumber>();

            mockRepo.Setup(repo => repo.ActivePhoneNumber(It.IsAny<string>()))
                .Returns(false);

            var controller = new PhoneNumberController(mockRepo.Object);

            //Act
            var result = controller.ActivatePhoneNumber("test");

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var isActivate = Assert.IsType<bool>(okObjectResult.Value);
            Assert.False(isActivate);
        }
    }
}

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
    public class CustomerControllerTests
    {
        [Fact]
        public void GetPhoneNumberByCustomerId_CorrectId_ReturnListOfPhoneNumber()
        {
            //Arrange
            var mockRepo = new Mock<ICustomer>();

            var numbers = new List<PhoneNumber>()
            {
                new PhoneNumber() { TelePhoneNumber = "0411111111", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111112", IsActivate = true}
            };

            mockRepo.Setup(repo => repo.GetPhoneNumberByCustomerId(It.IsAny<int>()))
                .Returns(numbers);

            var controller = new CustomerController(mockRepo.Object);

            //Act
            var result = controller.GetPhoneNumberByCustomerId(1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var numberList = Assert.IsType<List<PhoneNumber>>(okObjectResult.Value);
            Assert.Equal("0411111111", numberList[0].TelePhoneNumber);
            Assert.True(numberList[0].IsActivate);
        }

        [Fact]
        public void GetPhoneNumberByCustomerId_InCorrectId_ReturnNotFound()
        {
            //Arrange
            var mockRepo = new Mock<ICustomer>();

            mockRepo.Setup(repo => repo.GetPhoneNumberByCustomerId(It.IsAny<int>()))
                .Returns((IList<PhoneNumber>)null);

            var controller = new CustomerController(mockRepo.Object);

            //Act
            var result = controller.GetPhoneNumberByCustomerId(1);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}

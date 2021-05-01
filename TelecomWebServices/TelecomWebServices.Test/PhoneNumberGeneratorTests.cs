using System;
using TelecomWebServices.Resource;
using Xunit;

namespace TelecomWebServices.Test
{
    public class PhoneNumberGeneratorTests
    {
        [Fact]
        public void ActivatePhoneNumber_NumberIsInList_ReturnTrue()
        {
            //Arrange
            var generator = new PhoneNumberGenerator();

            //Act
            var result = generator.ActivatePhoneNumber("0411111111");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ActivatePhoneNumber_NumberIsNotInList_ReturnFalse()
        {
            //Arrange
            var generator = new PhoneNumberGenerator();

            //Act
            var result = generator.ActivatePhoneNumber("04111");

            //Assert
            Assert.False(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelecomWebServices.Interface;
using TelecomWebServices.Models;

namespace TelecomWebServices.Resource
{
    public class PhoneNumberGenerator : IPhoneNumberGenerator
    {
        public IList<PhoneNumber> GetSingleCustomerPhoneNumber(int customerId)
        {
            var numbers = new List<PhoneNumber>()
            {
                new PhoneNumber() { TelePhoneNumber = "0411111111", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111112", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111113", IsActivate = false}
            };

            return numbers;
        }

        public IList<PhoneNumber> GetAllPhoneNumbers()
        {
            var numbers = new List<PhoneNumber>()
            {
                new PhoneNumber() { TelePhoneNumber = "0411111111", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111112", IsActivate = true},
                new PhoneNumber() { TelePhoneNumber = "0411111113", IsActivate = false},
                new PhoneNumber() { TelePhoneNumber = "0411111114", IsActivate = false},
                new PhoneNumber() { TelePhoneNumber = "0411111115", IsActivate = true},
            };

            return numbers;
        }

        public bool ActivatePhoneNumber(string phoneNumber)
        {
            var allNumbers = GetAllPhoneNumbers();

            foreach(var number in allNumbers)
            {
                if(number.TelePhoneNumber == phoneNumber)
                {
                    number.IsActivate = true;
                    return true;
                }
            }

            return false;
        }
    }
}

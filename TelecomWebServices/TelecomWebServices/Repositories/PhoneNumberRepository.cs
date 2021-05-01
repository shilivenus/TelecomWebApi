using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelecomWebServices.Interface;
using TelecomWebServices.Models;

namespace TelecomWebServices.Repositories
{
    public class PhoneNumberRepository : IPhoneNumber
    {
        private readonly IPhoneNumberGenerator _phoneNumberGenerator;

        public PhoneNumberRepository(IPhoneNumberGenerator phoneNumberGenerator)
        {
            _phoneNumberGenerator = phoneNumberGenerator;
        }

        public bool ActivePhoneNumber(string phoneNumber)
        {
            return _phoneNumberGenerator.ActivatePhoneNumber(phoneNumber);
        }

        public IList<PhoneNumber> GetPhoneNumbers()
        {
            return _phoneNumberGenerator.GetAllPhoneNumbers();
        }
    }
}

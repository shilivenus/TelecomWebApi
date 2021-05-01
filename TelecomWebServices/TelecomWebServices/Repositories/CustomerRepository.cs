using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelecomWebServices.Interface;
using TelecomWebServices.Models;

namespace TelecomWebServices.Repositories
{
    public class CustomerRepository : ICustomer
    {
        private readonly IPhoneNumberGenerator _phoneNumberGenerator;

        public CustomerRepository(IPhoneNumberGenerator phoneNumberGenerator)
        {
            _phoneNumberGenerator = phoneNumberGenerator;
        }

        public IList<PhoneNumber> GetPhoneNumberByCustomerId(int customerId)
        {
            return _phoneNumberGenerator.GetSingleCustomerPhoneNumber(customerId);    
        }
    }
}

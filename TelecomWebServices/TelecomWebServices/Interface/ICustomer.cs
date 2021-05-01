using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelecomWebServices.Models;

namespace TelecomWebServices.Interface
{
    public interface ICustomer
    {
        IList<PhoneNumber> GetPhoneNumberByCustomerId(int customerId); 
    }
}

using System.Collections.Generic;
using TelecomWebServices.Models;

namespace TelecomWebServices.Interface
{
    public interface IPhoneNumberGenerator
    {
        bool ActivatePhoneNumber(string phoneNumber);
        IList<PhoneNumber> GetAllPhoneNumbers();
        IList<PhoneNumber> GetSingleCustomerPhoneNumber(int customerId);
    }
}
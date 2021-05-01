using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TelecomWebServices.Interface;
using TelecomWebServices.Models;

namespace TelecomWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        // GET api/phoneNumbers
        [HttpGet]
        [Route("{customerId}/phoneNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhoneNumber>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IList<PhoneNumber>> GetPhoneNumberByCustomerId(int customerId)
        {
            var phoneNumbers = _customer.GetPhoneNumberByCustomerId(customerId);

            if (phoneNumbers == null)
                return NotFound();

            return Ok(phoneNumbers);
        }
    }
}

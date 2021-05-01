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
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumber _phoneNumber;

        public PhoneNumberController(IPhoneNumber phoneNumber)
        {
            _phoneNumber = phoneNumber;
        }

        // GET api/phoneNumbers
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PhoneNumber>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PhoneNumber>> GetPhoneNumber()
        {
            var phoneNumbers = _phoneNumber.GetPhoneNumbers();

            if (phoneNumbers == null)
                return NotFound();

            return Ok(phoneNumbers);
        }

        [HttpPatch]
        [Route("{phoneNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public ActionResult<bool> ActivatePhoneNumber(string phoneNumber)
        {
            var isSuccessed = _phoneNumber.ActivePhoneNumber(phoneNumber);

            return Ok(isSuccessed);
        }
    }
}

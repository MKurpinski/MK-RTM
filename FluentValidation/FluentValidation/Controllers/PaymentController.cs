using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationExample.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IValidator<PaymentDataDto> _paymentDataValidator;

        public PaymentController(IValidator<PaymentDataDto> paymentDataValidator)
        {
            _paymentDataValidator = paymentDataValidator;
        }
        [HttpPost]
        [Route("built-in")]
        public IActionResult BuiltIn([FromBody] PaymentDataDto paymentData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpPost]
        [Route("manual")]
        public async Task<IActionResult> Manual([FromBody] PaymentDataDto paymentData)
        {
            var validationResults = await _paymentDataValidator.ValidateAsync(paymentData);

            if (validationResults.IsValid)
            {
                return NoContent();
            }
            validationResults.AddToModelState(ModelState, default);
            return BadRequest(ModelState);
        }
    }
}

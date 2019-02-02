using System;
using FluentValidationExample.Enums;

namespace FluentValidationExample.Dtos
{
    public class PaymentDataDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        public DateTime BirthDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public string CreditCardNumber { get; set; }
    }
}

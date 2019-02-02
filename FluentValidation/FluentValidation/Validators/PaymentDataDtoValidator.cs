using System;
using FluentValidation;
using FluentValidationExample.Dtos;
using FluentValidationExample.Enums;
using FluentValidationExample.Services;

namespace FluentValidationExample.Validators
{
    public class PaymentDataDtoValidator: AbstractValidator<PaymentDataDto>
    {
        public PaymentDataDtoValidator(IEmailValidationService emailValidationService)
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(paymentData => paymentData.LastName).NotEmpty().MaximumLength(30);
            RuleFor(paymentData => paymentData.FirstName).NotEmpty().MaximumLength(30);
            RuleFor(paymentData => paymentData.BirthDate).NotEmpty().Must(BeOver18).WithMessage("You are too young");
            RuleFor(paymentData => paymentData.Email).NotEmpty().EmailAddress().MustAsync(emailValidationService.IsUnique)
                .WithMessage("Email must be unique");
            RuleFor(paymentData => paymentData.ConfirmEmail).Equal(paymentData => paymentData.Email);
            RuleFor(paymentData => paymentData.PaymentType);

            When(paymentData => paymentData.PaymentType == PaymentType.CreditCard,
                () => RuleFor(paymentData => paymentData.CreditCardNumber).NotEmpty().CreditCard()
            );
        }

        private bool BeOver18(DateTime date)
        {
            return date.AddYears(18) <= DateTime.UtcNow;
        }
    }
}

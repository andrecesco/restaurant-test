using FluentValidation;
using GFT.TechnicalTest.Domain.Dishes.Orders.Models;

namespace GFT.TechnicalTest.Domain.Dishes.Orders.Validations
{
    public sealed class CreateOrderValidator : AbstractValidator<CreateOrder>
    {
        #region Constructors
        public CreateOrderValidator()
        {
            #region Period
            this.RuleFor(m => m.Period)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.Period)

                .IsInEnum()
                .WithErrorCode(ErrorCodes.Period);
            #endregion

            #region Dishes Enumeration
            this.RuleFor(m => m.Dishes)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.Dishes)

                .NotNull()
                .WithErrorCode(ErrorCodes.Dishes);
            #endregion
        }
        #endregion
    }
}

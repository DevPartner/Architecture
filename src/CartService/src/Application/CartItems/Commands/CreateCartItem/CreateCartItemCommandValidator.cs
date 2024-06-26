﻿namespace CartService.Application.CartItems.Commands.CreateItem;

public class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.CartKey)
            .NotEmpty()
            .WithMessage("CartKey is required.");

        RuleFor(v => v.ProductKey)
            .NotEmpty()
            .WithMessage("ProductKey is required.");

        RuleFor(v => v.Price)
            .NotEmpty()
            .WithMessage("Price is required.");

        RuleFor(v => v.Quantity)
            .NotEmpty()
            .GreaterThanOrEqualTo(1).WithMessage("Quantity at least greater than or equal to 1.");

    }
}

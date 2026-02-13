using FluentValidation;
using ProductFlow.OnionTest.Server.Application.Features.Commands.ProductCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductFlow.OnionTest.Server.Application.Features.Validators.Product
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Ürün ID boş olamaz");

            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez.").MaximumLength(150).WithMessage("Ürün adı en fazla 150 karakter olabilir.");

            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategorisi Boş Olamaz");
        }
    }
}

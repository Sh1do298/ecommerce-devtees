using Ecommerce.Api.Dtos;
using FluentValidation;

namespace Ecommerce.Api.Validators;

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto> {
    public ProductCreateDtoValidator() {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres");

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Preço não pode ser negativo");

        RuleFor(p => p.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Estoque não pode ser negativo");
    }
}

public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto> {
    public CategoryCreateDtoValidator() {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Nome é obrigatório")
            .MaximumLength(50).WithMessage("Nome deve ter no máximo 50 caracteres");
    }
}

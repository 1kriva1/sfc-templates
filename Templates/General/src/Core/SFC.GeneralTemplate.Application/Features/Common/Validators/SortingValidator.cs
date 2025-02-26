using FluentValidation;

using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;

namespace SFC.GeneralTemplate.Application.Features.Common.Validators;

/// <summary>
/// Sorting validator.
/// </summary>
public class SortingValidator : AbstractValidator<SortingDto>
{
    public SortingValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithName(nameof(SortingDto.Name));

        RuleFor(p => p.Direction)
            .IsInEnum()
            .WithName(nameof(SortingDto.Direction));
    }
}

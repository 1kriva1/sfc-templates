using FluentValidation;

using SFC.GeneralTemplate.Application.Features.Common.Dto.Pagination;

namespace SFC.GeneralTemplate.Application.Features.Common.Validators;

/// <summary>
/// Pagination validator.
/// </summary>
public class PaginationValidator : AbstractValidator<PaginationDto>
{
    public PaginationValidator()
    {
        RuleFor(p => p.Page)
            .GreaterThanOrEqualTo(1)
            .WithName(nameof(PaginationDto.Page));

        RuleFor(p => p.Size)
            .GreaterThanOrEqualTo(1)
            .WithName(nameof(PaginationDto.Size));
    }
}

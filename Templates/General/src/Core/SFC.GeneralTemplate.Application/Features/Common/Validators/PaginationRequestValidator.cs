using FluentValidation;

using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.Common.Models.Find.Paging;

namespace SFC.GeneralTemplate.Application.Features.Common.Validators;

/// <summary>
/// Validation for pagination and sorting values.
/// </summary>
/// <typeparam name="TResponse">Pagination request response type.</typeparam>
/// <typeparam name="TFilter">Filter type.</typeparam>
public class PaginationRequestValidator<TResponse, TFilter> : AbstractValidator<BasePaginationRequest<TResponse, TFilter>>
{
    public PaginationRequestValidator()
    {
        // pagination
        RuleFor(command => command.Pagination)
            .NotNull()
            .SetValidator(new PaginationValidator())
            .WithName(nameof(Pagination));

        //sorting
        RuleForEach(command => command.Sorting)
            .SetValidator(new SortingValidator());
    }
}

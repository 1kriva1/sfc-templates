using FluentValidation;

using SFC.GeneralTemplate.Application.Features.Common.Validators;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Find;
public class GetGeneralTemplatesQueryValidator : AbstractValidator<GetGeneralTemplatesQuery>
{
    public GetGeneralTemplatesQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGeneralTemplatesViewModel, GetGeneralTemplatesFilterDto>());
    }
}
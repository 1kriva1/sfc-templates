using FluentValidation;

using SFC.GeneralTemplate.Application.Features.Common.Validators.Common;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Dto.Filters;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
public class GetGeneralTemplateMultipleQueryValidator : AbstractValidator<GetGeneralTemplateMultipleQuery>
{
    public GetGeneralTemplateMultipleQueryValidator()
    {
        // pagination request validation
        RuleFor(command => command)
            .SetValidator(new PaginationRequestValidator<GetGeneralTemplateMultipleViewModel, GetGeneralTemplateMultipleFilterDto>());
    }
}
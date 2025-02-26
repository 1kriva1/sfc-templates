using FluentValidation;

using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Common.Validators;
public class GeneralTemplateValidator<T> : AbstractValidator<T> where T : BaseGeneralTemplateDto
{
    public GeneralTemplateValidator()
    {

    }
}

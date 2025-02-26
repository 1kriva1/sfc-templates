using FluentValidation;

using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Common.Validators;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Create;
public class CreateGeneralTemplateCommandValidator : AbstractValidator<CreateGeneralTemplateCommand>
{
    public CreateGeneralTemplateCommandValidator()
    {
        RuleFor(command => command.GeneralTemplate)
            .SetValidator(new GeneralTemplateValidator<CreateGeneralTemplateDto>());
    }
}

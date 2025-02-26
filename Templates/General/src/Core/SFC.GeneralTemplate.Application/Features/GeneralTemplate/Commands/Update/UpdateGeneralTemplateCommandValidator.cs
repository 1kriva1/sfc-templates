using FluentValidation;

using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Common.Validators;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Update;
public class UpdateGeneralTemplateCommandValidator : AbstractValidator<UpdateGeneralTemplateCommand>
{
    public UpdateGeneralTemplateCommandValidator()
    {
        RuleFor(command => command.GeneralTemplate).SetValidator(new GeneralTemplateValidator<UpdateGeneralTemplateDto>());
    }
}

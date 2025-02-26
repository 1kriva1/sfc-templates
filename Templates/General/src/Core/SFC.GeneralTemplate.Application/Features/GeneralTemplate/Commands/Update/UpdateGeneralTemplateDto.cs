using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Commands.Update;
public class UpdateGeneralTemplateDto : BaseGeneralTemplateDto, IMapTo<GeneralTemplateEntity>
{
    public new void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGeneralTemplateDto, GeneralTemplateEntity>()
               .IncludeBase<BaseGeneralTemplateDto, GeneralTemplateEntity>();
    }
}

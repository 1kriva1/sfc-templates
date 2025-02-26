using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;
public class BaseGeneralTemplateDto : IMapToReverse<GeneralTemplateEntity>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BaseGeneralTemplateDto, GeneralTemplateEntity>()
               .ReverseMap();
    }
}

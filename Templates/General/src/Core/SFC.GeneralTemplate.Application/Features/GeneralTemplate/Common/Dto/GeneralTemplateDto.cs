using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;
public class GeneralTemplateDto: BaseGeneralTemplateDto, IMapFrom<GeneralTemplateEntity>
{
    public long Id { get; set; }

    public new void Mapping(Profile profile) => profile.CreateMap<GeneralTemplateEntity, GeneralTemplateDto>();
}

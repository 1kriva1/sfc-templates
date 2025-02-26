using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.Queries.Get;
public class GetGeneralTemplateViewModel : IMapFrom<GeneralTemplateEntity>
{
    public required GeneralTemplateDto GeneralTemplate { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GeneralTemplateEntity, GetGeneralTemplateViewModel>()
                                                   .ForMember(p => p.GeneralTemplate, d => d.MapFrom(z => z));
}

using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Common.Dto;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Create;
public class CreateGeneralTemplateViewModel : IMapFrom<GeneralTemplateEntity>
{
    public required GeneralTemplateDto GeneralTemplate { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GeneralTemplateEntity, CreateGeneralTemplateViewModel>()
                                                   .ForMember(p => p.GeneralTemplate, d => d.MapFrom(z => z));
}

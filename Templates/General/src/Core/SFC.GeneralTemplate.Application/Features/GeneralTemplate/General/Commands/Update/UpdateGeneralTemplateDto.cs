using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;

namespace SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Update;
public class UpdateGeneralTemplateDto : IMapTo<GeneralTemplateEntity>
{
    public long Id { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGeneralTemplateDto, GeneralTemplateEntity>();
}

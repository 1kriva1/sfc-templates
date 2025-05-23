﻿#if IncludeTeamInfrastructure
using AutoMapper;

using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Common.Mappings.Converters.File;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.Common.Dto.Common;
using SFC.GeneralTemplate.Domain.Entities.Team.General;

namespace SFC.GeneralTemplate.Application.Common.Dto.Team.General;
public class TeamLogoDto : FileDto, IMapFromReverse<TeamLogo>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamLogo, TeamLogoDto>();

        profile.CreateMap<string?, TeamLogoDto?>()
               .ConvertUsing<Base64StringToFileTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto?, string?>()
               .ConvertUsing<FileToBase64StringTypeConverter<TeamLogoDto>>();

        profile.CreateMap<TeamLogoDto, TeamLogo>()
               .IgnoreAllNonExisting();
    }
}
#endif
﻿#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Domain.Entities.Data;

namespace SFC.GeneralTemplate.Application.Features.Data.Common.Dto;
public class StatCategoryDto : DataDto, IMapTo<StatCategory> { }
#endif
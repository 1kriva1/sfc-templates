using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Application.Common.Mappings.Interfaces;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.Data.Common;

namespace SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.Data.GetAll;

/// <summary>
/// Contain all available generaltemplate **data types**.
/// </summary>
public class GetAllGeneralTemplateDataResponse : BaseErrorResponse, IMapFrom<GetAllGeneralTemplateDataViewModel>
{
}

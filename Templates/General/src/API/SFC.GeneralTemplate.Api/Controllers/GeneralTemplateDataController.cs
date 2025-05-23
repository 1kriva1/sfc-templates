#if IncludeDataInfrastructure
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.Data.GetAll;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.Data.Queries.GetAll;
using SFC.GeneralTemplate.Infrastructure.Constants;

namespace SFC.GeneralTemplate.Api.Controllers;

[Tags("GeneralTemplate Data")]
[Route("api/GeneralTemplateMultiple/Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class GeneralTemplateDataController : ApiControllerBase
{
    /// <summary>
    /// Return all available generaltemplate data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllGeneralTemplateDataResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllGeneralTemplateDataResponse>> GetAllAsync()
    {
        GetAllGeneralTemplateDataQuery query = new();

        GetAllGeneralTemplateDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllGeneralTemplateDataResponse>(model));
    }
}
#endif
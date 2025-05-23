using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.GeneralTemplate.Api.Infrastructure.Extensions;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Base;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Create;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Find;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Get;
using SFC.GeneralTemplate.Api.Infrastructure.Models.GeneralTemplate.General.Update;
using SFC.GeneralTemplate.Api.Infrastructure.Models.Pagination;
using SFC.GeneralTemplate.Application.Features.Common.Base;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Create;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Commands.Update;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Find.Dto.Filters;
using SFC.GeneralTemplate.Application.Features.GeneralTemplate.General.Queries.Get;
using SFC.GeneralTemplate.Infrastructure.Constants;

namespace SFC.GeneralTemplate.Api.Controllers;

[Tags("GeneralTemplateMultiple")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GeneralTemplateMultipleController : ApiControllerBase
{
    /// <summary>
    /// Create new generaltemplate.
    /// </summary>
    /// <param name="request">Create generaltemplate request.</param>
    /// <returns>An ActionResult of type CreateGeneralTemplateResponse</returns>
    /// <response code="201">Returns **new** created generaltemplate.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateGeneralTemplateResponse>> CreateGeneralTemplateAsync([FromBody] CreateGeneralTemplateRequest request)
    {
        CreateGeneralTemplateCommand command = Mapper.Map<CreateGeneralTemplateCommand>(request);

        CreateGeneralTemplateViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetGeneralTemplate", new { id = model.GeneralTemplate.Id }, Mapper.Map<CreateGeneralTemplateResponse>(model));
    }

    /// <summary>
    /// Update existing generaltemplate.
    /// </summary>
    /// <param name="id">GeneralTemplate unique identifier.</param>
    /// <param name="request">Update generaltemplate request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if generaltemplate updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpPut("{id}")]
    [Authorize(Policy.OwnGeneralTemplate)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateGeneralTemplateAsync([FromRoute] long id, [FromBody] UpdateGeneralTemplateRequest request)
    {
        UpdateGeneralTemplateCommand command = Mapper.Map<UpdateGeneralTemplateCommand>(request)
                                                     .SetGeneralTemplateId(id);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return generaltemplate model by unique identifier.
    /// </summary>
    /// <param name="id">GeneralTemplate unique identifier.</param>
    /// <returns>An ActionResult of type GetGeneralTemplateResponse</returns>
    /// <response code="200">Returns generaltemplate model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when generaltemplate **not found** by unique identifier.</response>
    [HttpGet("{id}", Name = "GetGeneralTemplate")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGeneralTemplateResponse>> GetGeneralTemplateAsync([FromRoute] long id)
    {
        GetGeneralTemplateQuery query = new() { Id = id };

        GetGeneralTemplateViewModel generaltemplate = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetGeneralTemplateResponse>(generaltemplate));
    }

    /// <summary>
    /// Return list of generaltemplatemultiple
    /// </summary>
    /// <param name="request">Get generaltemplatemultiple request.</param>
    /// <returns>An ActionResult of type GetGeneralTemplatesResponse</returns>
    /// <response code="200">Returns list of generaltemplatemultiple with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGeneralTemplateMultipleResponse>> GetGeneralTemplateMultipleAsync([FromQuery] GetGeneralTemplateMultipleRequest request)
    {
        BasePaginationRequest<GetGeneralTemplateMultipleViewModel, GetGeneralTemplateMultipleFilterDto> query = Mapper.Map<GetGeneralTemplateMultipleQuery>(request);

        GetGeneralTemplateMultipleViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGeneralTemplateMultipleResponse>(result));
    }
}

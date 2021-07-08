using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.CQRSResponse;
using REP_CRIME01.Police.Application.CaseFeatures.Queries;
using REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands;
using REP_CRIME01.Police.Application.LawEnforcementFeatures.Queries;
using REP_CRIME01.Police.Common.Models;
using System;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LawEnforcementsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<LawEnforcementVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAsync([FromQuery] LawEnforcementsQueryString query)
        {
            var response = await _mediator.Send(new GetLawEnforcements.Query { QueryString = query });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LawEnforcementVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetLawEnforcementById.Query { Id = id });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateLawEnforcementDto dto)
        {
            var response = await _mediator.Send(new CreateLawEnforcement.Command { CreateLawEnforcementDto = dto });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateLawEnforcementDto dto)
        {
            var response = await _mediator.Send(new UpdateLawEnforcement.Command { Id = id, UpdateLawEnforcementDto = dto });
            return response.IsSuccess ?
                Accepted()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsnc(Guid id)
        {
            var response = await _mediator.Send(new DeleteLawEnforcement.Command { Id = id });
            return response.IsSuccess ?
                NoContent()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpGet("{id:Guid}/Cases")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<CaseVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetCasesAsync(Guid id, [FromQuery] CasesQueryString queryString)
        {
            var response = await _mediator.Send(new GetCasesByLawEnforcementId.Query { LawEnforcementId = id, QueryString = queryString });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }
    }
}

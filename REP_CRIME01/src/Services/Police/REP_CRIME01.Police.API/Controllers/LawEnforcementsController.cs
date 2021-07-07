using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.CQRSResponse;
using REP_CRIME01.Police.Application.Commands;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Application.Queries;
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
        public async Task<ActionResult> GetAsync([FromQuery] GetLawEnforcements.Query query)
        {
            var response = await _mediator.Send(query);
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
        public async Task<ActionResult> CreateAsync([FromBody] CreateLawEnforcement.Command command)
        {
            var response = await _mediator.Send(command);
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateLawEnforcement.Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var response = await _mediator.Send(command);
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
    }
}

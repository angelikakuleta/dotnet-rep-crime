using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.CQRSResponse;
using REP_CRIME01.Crime.Application.EventFeatures.Commands;
using REP_CRIME01.Crime.Application.EventFeatures.Queries;
using REP_CRIME01.Crime.Application.Models;
using System;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResult<CrimeEventVM>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAsync([FromQuery] GetCrimeEvents.Query query)
        {
            var response = await _mediator.Send(query);
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CrimeEventVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetCrimeEventById.Query { EventId = id });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCrimeEvent.Command command)
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
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateCrimeEvent.Command command)
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
            var response = await _mediator.Send(new DeleteCrimeEvent.Command { EventId = id });
            return response.IsSuccess ?
                NoContent()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPost]
        [Route("{id:Guid}/assign")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AssignAsync(Guid id, [FromBody] AssignCrimeEventToPolice.Command command)
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
    }
}

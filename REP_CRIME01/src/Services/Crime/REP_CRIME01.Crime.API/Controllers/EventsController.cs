using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.CQRSResponse;
using REP_CRIME01.Crime.Application.EventFeatures.Commands;
using REP_CRIME01.Crime.Application.EventFeatures.Queries;
using REP_CRIME01.Crime.Common.Models;
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
        public async Task<ActionResult> GetAsync([FromQuery] CrimeEventsQueryString query)
        {
            var response = await _mediator.Send(new GetCrimeEvents.Query { CrimeEventsQueryString = query });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CrimeEventVM))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetCrimeEventById.Query { Id = id });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCrimeEventDto dto)
        {
            var response = await _mediator.Send(new CreateCrimeEvent.Command { CreateCrimeEventDto = dto });
            return response.IsSuccess ?
                Ok(response.Result)
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateCrimeEventDto dto)
        {
            var response = await _mediator.Send(new UpdateCrimeEvent.Command { Id = id, UpdateCrimeEventDto = dto });
            return response.IsSuccess ?
                Accepted()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<ActionResult> DeleteAsnc(Guid id)
        {
            var response = await _mediator.Send(new DeleteCrimeEvent.Command { Id = id });
            return response.IsSuccess ?
                NoContent()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }

        [HttpPost]
        [Route("{id:Guid}/assign")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AssignAsync(Guid id, [FromBody] AssignCrimeEventToPoliceDto dto)
        {

            var response = await _mediator.Send(new AssignCrimeEventToPolice.Command { Id = id, AssignCrimeEventToPoliceDto = dto });
            return response.IsSuccess ?
                Accepted()
                : StatusCode(response.GetStatusCode(), response.ErrorMessage);
        }
    }
}

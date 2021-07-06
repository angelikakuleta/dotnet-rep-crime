using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.Crime.API.Extensions;
using REP_CRIME01.Crime.Application.Commands;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IRepository<CrimeEvent> _repository;
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator, IRepository<CrimeEvent> repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _repository.FindAllAsync(x => 1 == 1, x => x.EventDate, false, 1, 10));
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _repository.FindByIdAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCrimeEvent.Command command)
        {
            var response = await _mediator.Send(command);
            if (!response.IsSuccess)
            {
                return StatusCode(response.GetStatusCode(), response.ErrorMessage);
            }

            return Ok(response.Result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync([FromBody] CrimeEvent entity)
        {
            await _repository.UpdateAsync(entity);
            return Accepted();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsnc(Guid id)
        {
            await _repository.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}

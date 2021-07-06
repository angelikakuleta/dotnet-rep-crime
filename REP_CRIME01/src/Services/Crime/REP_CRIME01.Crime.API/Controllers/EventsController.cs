using Microsoft.AspNetCore.Mvc;
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

        public EventsController(IRepository<CrimeEvent> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _repository.FindAllAsync(x => 1 == 1, x => x.EventDate, false, 1, 10));
        }


        [HttpGet("{id:Guid}", Name = nameof(GetByIdAsync))]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            return Ok(await _repository.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CrimeEvent entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetByIdAsync), entity);
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

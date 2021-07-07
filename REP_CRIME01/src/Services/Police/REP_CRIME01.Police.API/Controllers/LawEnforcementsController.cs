using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementsController : ControllerBase
    {
        private readonly IRepository<LawEnforcement> _repository;

        public LawEnforcementsController(IRepository<LawEnforcement> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LawEnforcement>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAsync()
        {
            var response = await _repository.FindAllAsync(x => 1 == 1, x => x.Code, true, 1, 10);
            return Ok(response);
        }
    }
}

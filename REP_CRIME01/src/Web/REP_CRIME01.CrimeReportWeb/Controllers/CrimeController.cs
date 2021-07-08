using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using REP_CRIME01.Crime.Common.Models;
using REP_CRIME01.CrimeReportWeb.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace REP_CRIME01.CrimeReportWeb.Controllers
{
    public class CrimeController : Controller
    {
        private readonly ILogger<CrimeController> _logger;
        private readonly ICrimeClient _client;
        private readonly IMapper _mapper;

        public CrimeController(ILogger<CrimeController> logger, ICrimeClient client, IMapper mapper)
        {
            _logger = logger;
            _client = client;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            CrimeViewModel model = new();
            return View(model);
        }

        public IActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Report(CreateCrimeEventVM model)
        {
            var dto = _mapper.Map<CreateCrimeEventVM, CreateCrimeEventDto>(model);
            _logger.LogInformation(dto.EventType);
            var result = await _client.ReportCrimeEvent(dto);
            if (result is not null)
            {
                return View(nameof(Index), new CrimeViewModel { Message = "Thank you for reporting" } );
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

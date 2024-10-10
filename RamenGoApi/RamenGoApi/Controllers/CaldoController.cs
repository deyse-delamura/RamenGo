using Microsoft.AspNetCore.Mvc;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CaldoController : ControllerBase
    {
        private readonly ICaldoRepository _caldoRepository;

        public CaldoController(ICaldoRepository caldoRepository)
        {
            _caldoRepository = caldoRepository;
        }

        [HttpGet]
        public IActionResult GetCaldos()
        {
            var caldos = _caldoRepository.GetAll();
            return Ok(caldos);
        }
    }
}
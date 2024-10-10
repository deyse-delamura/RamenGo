using Microsoft.AspNetCore.Mvc;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProteinaController : ControllerBase
    {
        private readonly IProteinaRepository _proteinaRepository;

        public ProteinaController(IProteinaRepository proteinaRepository)
        {
            _proteinaRepository = proteinaRepository;
        }

        [HttpGet]
        public IActionResult GetProteinas()
        {
            var proteinas = _proteinaRepository.GetAll();
            return Ok(proteinas);
        }
    }
}

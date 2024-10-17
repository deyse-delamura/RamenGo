using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RamenGoApi.Application.Commands;
using RamenGoApi.Application.Interfaces;
using RamenGoApi.DTOs;

namespace RamenGoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpPost("Realizar")]
        public async Task<IActionResult> RealizarPedido([FromBody] PedidoRequest request)
        {
            try
            {
                var command = _mapper.Map<CriarPedidoCommand>(request);
                var pedido = await _pedidoService.ProcessarPedidoAsync(command);
                var response = _mapper.Map<PedidoResponse>(pedido);

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using RamenGoApi.Application.DTOs;
using RamenGoApi.Application.Services;

namespace RamenGoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost("Realizar")]
        public async Task<IActionResult> RealizarPedido([FromBody] PedidoRequest request)
        {
            try
            {
                var pedido = await _pedidoService.ProcessarPedidoAsync(request);
                return Ok(new
                {
                    PedidoId = pedido.Id,
                    Descricao = $"{pedido.Caldo.Name} and {pedido.Proteina.Name}",
                    Total = pedido.GetTotalPrice()
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}

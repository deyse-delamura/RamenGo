using RamenGoApi.Application.Commands;
using RamenGoApi.Domain.Entities;

namespace RamenGoApi.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> ProcessarPedidoAsync(CriarPedidoCommand command);
    }
}

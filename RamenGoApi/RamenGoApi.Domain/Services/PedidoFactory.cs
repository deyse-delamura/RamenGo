using RamenGoApi.Domain.Entities;

namespace RamenGoApi.Domain.Services
{
    public class PedidoFactory
    {
        public Pedido CreatePedido(Caldo caldo, Proteina proteina, string orderId)
        {
            return new Pedido
            {
                Id = orderId, 
                Caldo = caldo,
                Proteina = proteina
            };
        }
    }
}

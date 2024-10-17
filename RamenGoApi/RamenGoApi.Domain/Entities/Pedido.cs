namespace RamenGoApi.Domain.Entities
{
    public class Pedido(Caldo caldo, Proteina proteina, string orderId)
    {
        public string Id { get; } = orderId;
        public Caldo Caldo { get; } = caldo;
        public Proteina Proteina { get; } = proteina;

        public decimal GetTotalPrice() => Caldo.Price + Proteina.Price;
    }
}
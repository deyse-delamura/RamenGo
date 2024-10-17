namespace RamenGoApi.Domain.Entities
{
    public class Pedido
    {
        public Pedido(Caldo caldo, Proteina proteina, string orderId)
        {
            Id = orderId;
            Caldo = caldo;
            Proteina = proteina;
        }

        public string Id { get; }
        public Caldo Caldo { get; }
        public Proteina Proteina { get; }

        public decimal GetTotalPrice() => Caldo.Price + Proteina.Price;
    }
}

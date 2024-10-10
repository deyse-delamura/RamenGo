namespace RamenGoApi.Domain.Entities
{
    public class Pedido
    {
        public string Id { get; set; }
        public Caldo Caldo { get; set; }
        public Proteina Proteina { get; set; }

        public decimal GetTotalPrice() => Caldo.Price + Proteina.Price;
    }
}

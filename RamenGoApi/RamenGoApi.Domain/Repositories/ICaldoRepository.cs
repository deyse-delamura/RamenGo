using RamenGoApi.Domain.Entities;

namespace RamenGoApi.Domain.Repositories
{
    public interface ICaldoRepository
    {
        IEnumerable<Caldo> GetAll();
        Caldo? GetById(string id);
    }
}

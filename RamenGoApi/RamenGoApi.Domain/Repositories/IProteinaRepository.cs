using RamenGoApi.Domain.Entities;

namespace RamenGoApi.Domain.Repositories
{
    public interface IProteinaRepository
    {
        IEnumerable<Proteina> GetAll();
        Proteina? GetById(string id);
    }
}

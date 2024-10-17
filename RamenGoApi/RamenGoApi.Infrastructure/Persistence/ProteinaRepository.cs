using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Infrastructure.Persistence
{
    public class ProteinaRepository : IProteinaRepository
    {
        const string location = "assets/icon/";
        private readonly Dictionary<string, Proteina> _proteina;

        public ProteinaRepository()
        {
            _proteina = new List<Proteina>
            {
                new() { Id = "1", Name = "Chasu", Description = "A sliced flavourful pork meat with a selection of season vegetables.", Price = 10, ImageActive = $"{location}pork/active.png", ImageInactive =  $"{location}pork/inactive.png" },
                new() { Id = "2", Name = "Yasai Vegetarian", Description = "A delicious vegetarian ramen with a selection of seasoned vegetables.", Price = 10 , ImageActive = $"{location}yasai/active.png", ImageInactive =  $"{location}yasai/inactive.png" },
                new() { Id = "3", Name = "Karaague", Description = "Three units of fried chicken, moyashi, ajitama egg and other vegetables.", Price = 12 , ImageActive = $"{location}chicken/active.png", ImageInactive =  $"{location}chicken/inactive.png"}

            }.ToDictionary(proteina => proteina.Id);
        }

        public IEnumerable<Proteina> GetAll()
        {
            return _proteina.Values;
        }

        public Proteina? GetById(string id)
        {
            _proteina.TryGetValue(id, out var proteina);
            return proteina;
        }
    }
}
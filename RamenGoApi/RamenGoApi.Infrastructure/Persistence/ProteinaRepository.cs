using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Infrastructure.Persistence
{
    public class ProteinaRepository : IProteinaRepository
    {
        const string location = "assets/icon/";

        public IEnumerable<Proteina> GetAll()
        {
            return
            [
                new Proteina { Id = "1", Name = "Chasu", Description = "A sliced flavourful pork meat with a selection of season vegetables.", Price = 10, ImageActive = $"{location}pork/active.png", ImageInactive =  $"{location}pork/inactive.png" },
                new Proteina { Id = "2", Name = "Yasai Vegetarian", Description = "A delicious vegetarian ramen with a selection of seasoned vegetables.", Price = 10 , ImageActive = $"{location}yasai/active.png", ImageInactive =  $"{location}yasai/inactive.png" },
                new Proteina { Id = "3", Name = "Karaague", Description = "Three units of fried chicken, moyashi, ajitama egg and other vegetables.", Price = 12 , ImageActive = $"{location}chicken/active.png", ImageInactive =  $"{location}chicken/inactive.png"}
            ];
        }
    }
}
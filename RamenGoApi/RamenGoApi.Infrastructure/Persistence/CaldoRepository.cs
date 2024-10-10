using RamenGoApi.Domain.Entities;
using RamenGoApi.Domain.Repositories;

namespace RamenGoApi.Infrastructure.Persistence
{
    public class CaldoRepository : ICaldoRepository
    {
        const string location = "assets/icon/";

        public IEnumerable<Caldo> GetAll()
        {            
            return
            [
                new Caldo { Id = "1", Name = "Salt", Description = "Simple like the seawater", Price = 10, ImageActive = $"{location}salt/active.png", ImageInactive = $"{location}salt/inactive.png" },
                new Caldo { Id = "2", Name = "Soy", Description = "Rich soy sauce flavor", Price = 10, ImageActive = $"{location}shoyu/active.png", ImageInactive = $"{location}shoyu/inactive.png"},
                new Caldo { Id = "3", Name = "Miso", Description = "Paste made of fermented soybeans", Price = 12, ImageActive = $"{location}miso/active.png", ImageInactive = $"{location}miso/inactive.png" }
            ];
        }
    }
}
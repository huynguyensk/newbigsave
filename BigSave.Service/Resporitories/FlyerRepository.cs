using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class FlyerRepository : Repository<Flyer>, IFlyerRepository
    {
        public FlyerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class FlyerCategoryRepository : Repository<FlyerCategory>, IFlyerCategoryRepository
    {
        public FlyerCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
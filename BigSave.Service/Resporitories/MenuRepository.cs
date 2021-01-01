using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class WishlistProductRepository : Repository<WishlistProduct>, IWishlistProductRepository
    {
        public WishlistProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
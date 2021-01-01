using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

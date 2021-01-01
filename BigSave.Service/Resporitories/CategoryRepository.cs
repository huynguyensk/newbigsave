using System.Collections.Generic;
using System.Linq;
using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<Category> GetCategoryByMerchant(Merchant merchant)
        {
            var categories = GetByCondition(c => c.Merchants.Contains(merchant));
            return categories;
        }
    }
}

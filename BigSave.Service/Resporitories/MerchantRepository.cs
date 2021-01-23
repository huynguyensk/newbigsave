using System.Collections.Generic;
using System.Linq;
using BigSave.Core.Entities;
using BigSave.Data.Data.Data;
using BigSave.Service.Interfaces;
using BigSave.Service.Resporitories.Base;

namespace BigSave.Service.Resporitories
{
    public class MerchantRepository : Repository<Merchant>, IMerchantRepository
    {

        public MerchantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public List<Merchant> GetMerchantsByCategory(Category category)
        {
            var merchants = GetByCondition(m => m.Categories.Contains(category));
            return merchants;
        }

        public Merchant GetProductMerchant(Product product)
        {
            return GetByCondition(m => m.Products.Contains(product)).FirstOrDefault();
        }
    }
}

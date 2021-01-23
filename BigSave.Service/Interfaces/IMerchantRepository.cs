using BigSave.Core.Entities;
using BigSave.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface IMerchantRepository : IRepository<Merchant>
    {
        List<Merchant> GetMerchantsByCategory(Category category);
        Merchant GetProductMerchant(Product product);
    }
}

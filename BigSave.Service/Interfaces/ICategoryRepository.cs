using BigSave.Core.Entities;
using BigSave.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetCategoryByMerchant(Merchant merchant);
        Category GetProductCategory(Product product);
    }
}

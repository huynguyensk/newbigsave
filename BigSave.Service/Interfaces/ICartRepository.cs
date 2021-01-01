using BigSave.Core.Entities;
using BigSave.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetByUserName(string userName);
        List<Product> GetProductInCart(string userName);
        int TotalProductInCart(string userName);
        Cart GetExistingOrCreateNewCart(string userName);
    }
}

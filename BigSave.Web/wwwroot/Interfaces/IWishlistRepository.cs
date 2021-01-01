using BigSave.Core.Entities;
using BigSave.Service.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BigSave.Service.Interfaces
{
    public interface IWishlistRepository : IRepository<Wishlist>
    {
        Wishlist GetByUserName(string userName);
        List<Product> GetProductInWishlist(string userName);
        int TotalProductInWishlist(string userName);
        void RemoveProductOutWishlist(int productId, string userName);
        void AddProductToWishlist(int productId, string userName);

    }
}

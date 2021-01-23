using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class Wishlist : BaseEntity
    {
        public Wishlist()
        {
            WishlistProducts = new List<WishlistProduct>();
        }
        public string UserName { get; set; }
        public virtual IList<WishlistProduct> WishlistProducts { get; set; }
        public void AddItem(int productId)
        {
            var existingItem = WishlistProducts.FirstOrDefault(x => x.ProductId == productId);
            if (existingItem != null)
                return;

            WishlistProducts.Add(new WishlistProduct
            {
                ProductId = productId,
                WishlistId = this.Id
            });
        }
        public void RemoveItem(int productId)
        {
            var removedItem = WishlistProducts.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                WishlistProducts.Remove(removedItem);
            }
        }
        public void ClearWishlist()
        {
            WishlistProducts.Clear();
        }
    }
}
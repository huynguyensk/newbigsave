using System.ComponentModel.DataAnnotations.Schema;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class WishlistProduct : BaseEntity
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("Wishlist")]
        public int WishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

    }
}
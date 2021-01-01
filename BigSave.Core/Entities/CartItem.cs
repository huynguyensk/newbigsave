using System.ComponentModel.DataAnnotations.Schema;
using BigSave.Core.Entities.Base;

namespace BigSave.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.CurrentPrice; } }
        public decimal TotalCartItem { get { return Quantity * UnitPrice; } }
        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
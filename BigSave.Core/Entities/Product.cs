using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            CartItems = new List<CartItem>();
            WishlistProducts = new List<WishlistProduct>();
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Slug { get; set; }
        public string Brand { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Discount_percent { get; set; }
        public string Image_ProDiscount { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public bool InStoreOnly { get; set; }
        public string Pre_price_text { get; set; }
        public string Price_Text { get; set; }
        public DateTime Valid_to { get; set; }
        public DateTime Valid_from { get; set; }
        public string Large_image_url { get; set; }
        public string X_large_image_url { get; set; }
        public string Dist_coupon_image_url { get; set; }
        public string Sale_Story { get; set; }
        public long Flyer_Item_Id { get; set; }
        public string SKU { get; set; }
        //-------------
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int FlyerId { get; set; }
        public Flyer Flyer { get; set; }
        public virtual IList<CartItem> CartItems { get; set; }
        public virtual IList<WishlistProduct> WishlistProducts { get; set; }
        public int MyProperty { get; set; }
    }
}
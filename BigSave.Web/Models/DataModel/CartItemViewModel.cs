namespace BigSave.Web.Models.DataModel
{
    public class CartItemViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public int CartId { get; set; }
        public virtual CartViewModel Cart { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.CurrentPrice; } }
        public decimal TotalCartItem { get { return Quantity * UnitPrice; } }
    }
}
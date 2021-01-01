namespace BigSave.Web.Models.DataModel
{
    public class WishlistProductViewModel : BaseViewModel
    {
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        public int WishlistId { get; set; }
        public WishlistViewModel Wishlist { get; set; }
    }
}
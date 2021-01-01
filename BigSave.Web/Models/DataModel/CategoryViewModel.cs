using System.Collections.Generic;
namespace BigSave.Web.Models.DataModel
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public MerchantViewModel Merchant { get; set; }
    }
}
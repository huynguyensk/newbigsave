using System.Collections.Generic;
namespace BigSave.Web.Models.DataModel
{
    public class MerchantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; } = true;
        //-------------------------

        public List<ProductViewModel> Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
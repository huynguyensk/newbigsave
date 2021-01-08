using System.Collections.Generic;
namespace BigSave.Web.Models.DataModel
{
    public class MerchantViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string MerchantCode{get;set;}
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; } = true;
        //-------------------------
        
        public List<ProductViewModel> Products { get; set; }
        //public virtual List<CategoryInMerchant> CategoryInMerchants { get; set; }
        public List<FlyerViewModel> Flyers { get; set; }

        public virtual List<CategoryViewModel> Categories { get; set; }
    }
}
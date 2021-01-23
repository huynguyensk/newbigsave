using System.Collections.Generic;
using BigSave.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigSave.Core.Entities
{
    public class Merchant : BaseEntity
    {
        public Merchant()
        {
            Stores = new List<Store>();
            Products = new List<Product>();
            this.Categories = new List<Category>();
            Flyers = new List<Flyer>();
        }
        public string Name { get; set; }
        public string MerchantCode { get; set; }
        public string LogoFile { get; set; }
        public string Url { get; set; }
        public bool ShowInHome { get; set; } = true;
        //-------------------------
        public IList<Store> Stores { get; set; }
        public IList<Product> Products { get; set; }
        //public virtual List<CategoryInMerchant> CategoryInMerchants { get; set; }
        public IList<Flyer> Flyers { get; set; }

        public virtual List<Category> Categories { get; set; }

    }
}
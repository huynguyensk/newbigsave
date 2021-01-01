using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BigSave.Core.Entities.Base;

namespace BigSave.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
            this.Merchants = new List<Merchant>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }
        public List<Product> Products { get; set; }
        //public virtual List<CategoryInMerchant> CategoryInMerchants { get; set; }
        public virtual List<Merchant> Merchants { get; set; }

    }
}
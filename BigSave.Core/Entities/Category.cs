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
            Merchants = new List<Merchant>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageFile { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Merchant> Merchants { get; set; }

    }
}
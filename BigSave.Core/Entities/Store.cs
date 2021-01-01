using System.ComponentModel.DataAnnotations.Schema;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Description { get; set; }
        [ForeignKey("Merchant")]
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
    }
}

using System;
using BigSave.Core.Entities.Base;
namespace BigSave.Core.Entities
{
    public class Coupon : BaseEntity
    {
        public string CouponNo { get; set; }
        public int CouponNumber { get; set; }
        public string Name { get; set; }
        public string OrderId { get; set; }
        //public Order Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ForStoreId { get; set; }
        public Store ForStore { get; set; }
        public decimal MinTotalPrice { get; set; }
        public decimal Discount { get; set; }
        public string Conditions { get; set; }
    }
}
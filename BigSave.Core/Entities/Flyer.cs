﻿using System;
using System.Collections.Generic;
using BigSave.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigSave.Core.Entities
{
    public class Flyer : BaseEntity
    {
        public Flyer()
        {
            Products = new List<Product>();
        }
        public long Flyer_Id { get; set; }
        [UrlAttribute]
        public string Url { get; set; }
        public DateTime Valid_from { get; set; }
        public DateTime Valid_to { get; set; }
        public List<Product> Products { get; set; }   
        public int FlyerCategoryId{get;set;}
        public FlyerCategory FlyerCategory { get; set; } 
        public int MerchantId{get;set;}          
        public Merchant Merchant { get; set; }
    }
}

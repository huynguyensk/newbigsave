using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BigSave.Web.Models.DataModel
{
    public class FlyerViewModel : BaseViewModel
    {
        public string Url { get; set; }
        public DateTime Valid_from { get; set; }
        public DateTime Valid_to { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public FlyerCategoryViewModel FlyerCategory { get; set; }
        public bool IsActive { get; set; }
    }
}
using System.Collections.Generic;

namespace BigSave.Web.Models.DataModel
{
    public class FlyerCategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public List<FlyerViewModel> Flyers { get; set; }
    }
}
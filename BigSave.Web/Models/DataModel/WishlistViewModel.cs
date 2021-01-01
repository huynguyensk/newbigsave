using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace BigSave.Web.Models.DataModel
{
    public class WishlistViewModel : BaseViewModel
    {
        public WishlistViewModel()
        {
            ProductViewModels = new List<ProductViewModel>();
        }
        public string UserName { get; set; }
        public virtual ICollection<ProductViewModel> ProductViewModels { get; set; }

    }
}
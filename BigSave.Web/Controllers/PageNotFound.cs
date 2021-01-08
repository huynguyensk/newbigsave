using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.Controllers
{
    public class PageNotFound : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
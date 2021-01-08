using Microsoft.AspNetCore.Mvc;

namespace BigSave.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Auth()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
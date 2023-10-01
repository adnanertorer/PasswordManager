using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

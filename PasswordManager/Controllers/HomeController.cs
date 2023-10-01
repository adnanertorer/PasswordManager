using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PasswordManager.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [System.Web.Mvc.Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
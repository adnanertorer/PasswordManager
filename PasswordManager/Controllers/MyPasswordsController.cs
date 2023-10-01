using AutoMapper;
using Microsoft.AspNet.Identity;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Domain.Services.UserAccountServices;
using PasswordManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class MyPasswordsController : Controller
    {
        private readonly IUserAccountService _service;

        public MyPasswordsController(IUserAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? page, int? size)
        {
            var userId = User.Identity.GetUserId();
            var response = await _service.GetList(page: page.HasValue ? page.Value : 0, size: size.HasValue ? size.Value : 10, 
                predicate: i => i.UserId == userId, orderBy: p => p.OrderBy(x => x.AccountTitle));
            return View(Mapper.Map<IList<UserAccountEntity>>(response.DataObj.Items));
        }

        [HttpPost]
        public async Task<ActionResult> Index(AccountSearchModel model)
        {
            var userId = User.Identity.GetUserId();
            var response = await _service.GetList(page: 0, size: 100,
                predicate: i => i.UserId == userId,
                orderBy: p => p.OrderBy(x => x.AccountTitle));
            var list = response.DataObj.Items;
            if (model.SearchValue != null)
            {
                list = list.Where(i => (i.AccountTitle.Contains(model.SearchValue) || i.Username.Contains(model.SearchValue))).ToList();
            }
            
            if(model.SelectedCategory != 0)
            {
                list = list.Where(i => i.CategoryId == model.SelectedCategory).ToList();
            }
            return View(Mapper.Map<IList<UserAccountEntity>>(list));
        }
    }
}
using AutoMapper;
using Microsoft.AspNet.Identity;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Domain.Services.UserNotesServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class UserNotesController : Controller
    {
        private readonly IUserNoteService _service;

        public UserNotesController(IUserNoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var response = await _service.GetList(page: 0, size: 100, predicate: x => x.UserId == userId, orderBy: p => p.OrderBy(i => i.CreatedAt));
            return View(Mapper.Map<IList<UserNotesEntity>>(response.DataObj.Items));
        } 
    }
}
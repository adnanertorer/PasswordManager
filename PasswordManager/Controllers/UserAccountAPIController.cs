using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Services.UserAccountServices;
using PasswordManager.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
namespace PasswordManager.Controllers
{
    [Authorize]
    public class UserAccountAPIController : ApiController
    {
        private readonly IUserAccountService _service;

        public UserAccountAPIController(IUserAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetList([FromUri] int page, [FromUri] int size)
        {
            var userId = User.Identity.GetUserId();
            return Ok(await _service.GetList(page: page, size: size, predicate: i => i.UserId == userId, orderBy: p => p.OrderBy(x => x.AccountTitle)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            return Ok(await _service.Get(predicate: categories => categories.Id == id));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] UserAccounts account)
        {
            account.UserId = User.Identity.GetUserId();
            return Ok(await _service.Add(account));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] UserAccounts account)
        {
            account.UserId = User.Identity.GetUserId();
            return Ok(await _service.Update(account));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] UserAccounts account)
        {
            return Ok(await _service.Remove(account));
        }
    }
}
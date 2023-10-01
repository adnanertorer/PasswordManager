using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Services.UserNotesServices;
using PasswordManager.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class UserNotesAPIController : ApiController
    {
        private readonly IUserNoteService _service;

        public UserNotesAPIController(IUserNoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetList([FromUri] int page, [FromUri] int size)
        {
            var userId = User.Identity.GetUserId();
            return Ok(await _service.GetList(page: page, size: size, predicate: i => i.UserId == userId, orderBy: p => p.OrderBy(x => x.CreatedAt)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            return Ok(await _service.Get(predicate: categories => categories.Id == id));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] UserNotes note)
        {
            note.UserId = User.Identity.GetUserId();
            return Ok(await _service.Add(note));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] UserNotes note)
        {
            note.UserId = User.Identity.GetUserId();
            return Ok(await _service.Update(note));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] UserNotes note)
        {
            return Ok(await _service.Remove(note));
        }
    }
}

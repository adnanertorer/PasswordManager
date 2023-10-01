using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using PasswordManager.Domain.Services.CategoryServices;
using PasswordManager.Models;

namespace PasswordManager.Controllers
{
    [System.Web.Mvc.Authorize]
    public class CategoryAPIController : ApiController
    {
        private readonly ICategoryService _service;

        public CategoryAPIController(ICategoryService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> GetList([FromUri] int page, [FromUri] int size)
        {
            var userId = User.Identity.GetUserId();
            return Ok(await _service.GetList(page: page, size: size, predicate: i=>i.UserId == userId, orderBy: p=>p.OrderBy(x=>x.CategoryName)));
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            return Ok(await _service.Get(predicate: categories => categories.Id == id ));
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] Categories category)
        {
            category.UserId = User.Identity.GetUserId();
            return Ok(await _service.Add(category));
        }
        
        [HttpPut]
        public async Task<IHttpActionResult> Update([FromBody] Categories category)
        {
            category.UserId = User.Identity.GetUserId();
            return Ok(await _service.Update(category));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromBody] Categories category)
        {
            return Ok(await _service.Remove(category));
        }
    }
}
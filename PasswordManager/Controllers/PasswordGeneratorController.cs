using PasswordManager.ReqRes;
using PasswordManager.Tools;
using System.Web.Http;
using Unity;

namespace PasswordManager.Controllers
{
    public class PasswordGeneratorController : ApiController
    {
        private readonly IPasswordGenerator _passwordGenerator;

        public PasswordGeneratorController(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }

        [HttpPost]
        public IHttpActionResult CreatePassword([FromBody] PasswordRequest passwordRequest)
        {
            var password = _passwordGenerator.GeneratePassword(passwordRequest);
            return Ok(password);
        }
    }
}

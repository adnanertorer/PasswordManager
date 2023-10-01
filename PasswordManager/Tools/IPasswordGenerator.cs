using PasswordManager.ReqRes;

namespace PasswordManager.Tools
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(PasswordRequest passwordRequest);
    }
}

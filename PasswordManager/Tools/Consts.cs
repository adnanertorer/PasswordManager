using System.Text;

namespace PasswordManager.Tools
{
    public static class Consts
    {
        public static readonly string CHARS_LCASE = "abcdefgijkmnopqrstwxyz";
        public static readonly string CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
        public static readonly string CHARS_NUMERIC = "0123456789";
        public static readonly string CHARS_SPECIAL = "*$-+?_&=!%{}/";
        public static readonly string SecurityKey = System.Configuration.ConfigurationManager.AppSettings["SecuritKey"];
        public static byte[] Salt = Encoding.UTF8.GetBytes(SecurityKey);
        public static byte[] IV = Encoding.UTF8.GetBytes("HR$2pIjHR$2pIj12");
    }
}
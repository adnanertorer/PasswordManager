namespace PasswordManager.ReqRes
{
    public class PasswordRequest
    {
        public int MinLength { get; set; }
        public bool Numeric { get; set; }
        public bool UpperCase { get; set; }
        public bool LowerCase { get; set; }
        public bool SpecialChars { get; set; }
    }
}
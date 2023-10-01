using PasswordManager.ReqRes;
using System;
using System.Text;

namespace PasswordManager.Tools
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(PasswordRequest passwordRequest)
        {
            var sb = new StringBuilder();
            var random =  new Random();
            var counter = 1;
            while (true)
            {
                if (passwordRequest.Numeric)
                {
                    if(counter>passwordRequest.MinLength)
                        break;
                    sb.Insert(
                        random.Next(sb.Length),
                        Consts.CHARS_NUMERIC.ToCharArray()[random.Next(Consts.CHARS_NUMERIC.ToCharArray().Length - 1)].ToString()
                    );
                    
                    counter++;
                }
                if(passwordRequest.UpperCase)
                {
                    if(counter>passwordRequest.MinLength)
                        break;
                    sb.Insert(
                        random.Next(sb.Length),
                        Consts.CHARS_UCASE.ToCharArray()[random.Next(Consts.CHARS_UCASE.ToCharArray().Length - 1)].ToString()
                    );
                   
                    counter++;
                }
                if (passwordRequest.LowerCase)
                {
                    if(counter>passwordRequest.MinLength)
                        break;
                    sb.Insert(
                        random.Next(sb.Length),
                        Consts.CHARS_LCASE.ToCharArray()[random.Next(Consts.CHARS_LCASE.ToCharArray().Length - 1)].ToString()
                    );
                    
                    counter++;
                }

                if (passwordRequest.SpecialChars)
                {
                    if(counter>passwordRequest.MinLength)
                        break;
                    sb.Insert(
                        random.Next(sb.Length),
                        Consts.CHARS_SPECIAL.ToCharArray()[random.Next(Consts.CHARS_SPECIAL.ToCharArray().Length - 1)].ToString()
                    );
                    
                    counter++;
                }
            }
            


            return sb.ToString();
        }
    }
}
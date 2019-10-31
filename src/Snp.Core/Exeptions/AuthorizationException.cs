using System;

namespace Snp.Core.Exeptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string msg) : base(msg)
        {
        }
    }
}
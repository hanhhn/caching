using System;

namespace Snp.ePort.Core.Exeptions
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException(string msg) : base(msg)
        {
        }
    }
}
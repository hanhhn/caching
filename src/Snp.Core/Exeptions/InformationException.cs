using System;

namespace Snp.Core.Exeptions
{
    public class InformationException : Exception
    {
        public InformationException(string msg) : base(msg)
        {
        }
    }
}
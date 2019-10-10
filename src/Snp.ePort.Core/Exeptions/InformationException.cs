using System;

namespace Snp.ePort.Core.Exeptions
{
    public class InformationException : Exception
    {
        public InformationException(string msg) : base(msg)
        {
        }
    }
}
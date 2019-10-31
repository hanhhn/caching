using System;
using System.Collections.Generic;

namespace Snp.Core.Infrastructure.File
{
    public interface IFileReader : IDisposable
    {
        bool EndOfStream { get; }
        string ReadLine();
        List<string> ReadAll();
    }
}

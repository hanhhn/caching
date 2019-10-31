using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Snp.Core.Infrastructure.File
{
    public class FileReader : IFileReader
    {
        private readonly string _path;
        private readonly StreamReader _streamReader;

        public FileReader(string path)
        {
            _path = path;
            _streamReader = new StreamReader(_path, Encoding.UTF8);
        }

        public bool EndOfStream => _streamReader.EndOfStream;

        public List<string> ReadAll()
        {
            List<string> content = new List<string>();
            while(!EndOfStream)
            {
                string line = _streamReader.ReadLine();
                content.Add(line);
            }

            return content;
        }

        public string ReadLine()
        {
            return _streamReader.ReadLine();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _streamReader.Dispose();
            }
        }
    }
}

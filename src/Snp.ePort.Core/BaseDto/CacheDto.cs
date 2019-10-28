using System.Threading;

namespace Snp.ePort.Core.BaseDto
{
    public class CacheDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int ExpireTime { get; set; }
        public CancellationToken Token { get; set; } = default;
    }
}
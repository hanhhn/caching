using System;
using System.Collections.Generic;
using System.Text;

namespace Snp.ePort.Service.RedisCaching
{
    public enum RedisDatabaseNumber : int
    {
        /// <summary>
        /// Database for caching
        /// </summary>
        Cache = 1,
        /// <summary>
        /// Database for plugins
        /// </summary>
        Plugin = 2,
        /// <summary>
        /// Database for data protection keys
        /// </summary>
        DataProtectionKeys = 3
    }
}

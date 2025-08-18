using System;

namespace Rcbi.Framework.Version
{
    public interface IVersion
    {
        /// <summary>
        /// the application version
        /// </summary>
        string Version { get; }
        /// <summary>
        /// the static url version 
        /// </summary>
        string StaticUrlVersion { get; }
    }
}

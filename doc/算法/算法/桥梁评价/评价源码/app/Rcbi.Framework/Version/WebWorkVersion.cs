using System;

namespace Rcbi.Framework.Version
{
    public partial class WebWorkVersion : IVersion
    {
        private readonly string _staticUrlVersion;

        public WebWorkVersion() 
        {
            _staticUrlVersion = DateTime.Now.ToString("yyyyMMddHHmm");
        }
        public string Version
        {
            get {
                return "1.0.0";
            }
        }

        public string StaticUrlVersion
        {
            get {
                return _staticUrlVersion;
            }
        }
    }
}

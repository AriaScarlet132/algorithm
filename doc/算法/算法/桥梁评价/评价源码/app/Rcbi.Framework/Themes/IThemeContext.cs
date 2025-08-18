using System;

namespace Rcbi.Framework.Themes
{
    public interface IThemeContext
    {
        /// <summary>
        /// Get or set current theme system name
        /// </summary>
        string WorkingThemeName { get; set; }
        /// <summary>
        /// Get or set current static resource base path
        /// </summary>
        string ResourceBasePath { get; }
    }
}

using System;
using System.Collections.Generic;

namespace Rcbi.Framework.Themes
{
    public interface IThemeProvider
    {
        ThemeConfiguration GetThemeConfiguration(string themeName);

        IList<ThemeConfiguration> GetThemeConfigurations();

        bool ThemeConfigurationExists(string themeName);

        string GetResourceBasePath();
    }
}

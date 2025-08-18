using System;
using System.Linq;

namespace Rcbi.Framework.Themes
{
    public partial class ThemeContext : IThemeContext
    {
        private readonly IWorkContext _workContext;
        private readonly IThemeProvider _themeProvider;

        private string _cachedThemeName;

        public ThemeContext(IWorkContext workContext,
            IThemeProvider themeProvider)
        {
            this._workContext = workContext;
            this._themeProvider = themeProvider;
        }
        public virtual string WorkingThemeName
        {
            get
            {
                if (!string.IsNullOrEmpty(_cachedThemeName))
                    return _cachedThemeName;

                string theme = string.Empty;

                //ensure that theme exists
                if (!_themeProvider.ThemeConfigurationExists(theme))
                {
                    var themeInstance = _themeProvider.GetThemeConfigurations()
                        .FirstOrDefault();
                    if (themeInstance == null)
                        throw new Exception("No theme could be loaded");
                    theme = themeInstance.ThemeName;
                }

                _cachedThemeName = theme;

                return _cachedThemeName;
            }
            set
            {
                if (_workContext.CurrentUser == null)
                    return;

                //to do set theme
                _cachedThemeName = value;
            }
        }

        public virtual string ResourceBasePath
        {
            get
            {
                return this._themeProvider.GetResourceBasePath();
            }
        }
    }
}

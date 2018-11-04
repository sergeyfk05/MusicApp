using MusicApp.Resources.Themes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxThemeChangerProvider : IThemeChangerProvider
    {
        public ResxThemeChangerProvider(CultureInfo current)
        {
            CurrentTheme = current;
        }

        private IEnumerable<CultureInfo> _themes;
        private CultureInfo _currentTheme;
  

        public object Localize(string key)
        {
            return Theme.ResourceManager.GetObject(key);
        }

        public IEnumerable<CultureInfo> Themes => _themes ?? (_themes = new List<CultureInfo>
        {
            new CultureInfo("light"),
            new CultureInfo("dark"),
        });
        public CultureInfo CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                if (Equals(value, _currentTheme))
                    return;
                if (!Themes.Contains(value))
                    throw new ArgumentException("There is no such theme in the list of themes.");

                _currentTheme = value;
            }
        }
    }
}

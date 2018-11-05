using MusicApp.Models;
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
        public ResxThemeChangerProvider(string keyTheme)
        {
            _currentTheme = Themes.First<ThemeInfo>(x => x.Name == keyTheme);
        }

        private IEnumerable<ThemeInfo> _themes;
        private ThemeInfo _currentTheme;
  

        public object Localize(string key)
        {
            return Theme.ResourceManager.GetObject(key);
        }

        public IEnumerable<ThemeInfo> Themes => _themes ?? (_themes = new List<ThemeInfo>
        {
            new ThemeInfo("light"),
            new ThemeInfo("dark"),
        });
        public ThemeInfo CurrentTheme
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

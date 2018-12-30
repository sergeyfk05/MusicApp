using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MusicApp.DynamicResource.Themes
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxThemeChangerProvider : IDynamicResourceProvider<ThemeInfo>
    {
        public ResxThemeChangerProvider(string keyTheme)
        {
            _currentCulture = Cultures.First<ThemeInfo>(x => x.Name == keyTheme);
        }

        private IEnumerable<ThemeInfo> _cultures;
        private ThemeInfo _currentCulture;
  

        public object GetResource(string key)
        {
            return "aaaa";//Theme.ResourceManager.GetObject(key);
        }

        public IEnumerable<ThemeInfo> Cultures => _cultures ?? (_cultures = new List<ThemeInfo>()
        {
            new ThemeInfo("ru")
        });
        public ThemeInfo CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                if (Equals(value, _currentCulture))
                    return;

                if (!Cultures.Contains(value))
                    throw new ArgumentException("There is no such theme in the list of themes.");

                _currentCulture = value;
            }
        }
    }
}

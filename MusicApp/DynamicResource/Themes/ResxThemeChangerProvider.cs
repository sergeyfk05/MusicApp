using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace MusicApp.DynamicResource.Themes
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxThemeChangerProvider : BaseProvider<ThemeInfo>, IDynamicResourceProvider<ThemeInfo>
    {
        public ResxThemeChangerProvider(string keyTheme)
        {
            ThemeInfo buffer = Cultures.FirstOrDefault<ThemeInfo>(x => x.Name == keyTheme);
            CurrentCulture = buffer != null ? buffer : Cultures.First();
        }

        public override object GetResource(string key)
        {
            return CurrentCulture.Name == "ru" ? "ru" : "en";
            //return CurrentCulture.Name;
            //throw new NotImplementedException();
            //return "aaaa";//Theme.ResourceManager.GetObject(key);
        }

        public override IEnumerable<ThemeInfo> Cultures => _cultures ?? (_cultures = new List<ThemeInfo>()
        {
            new ThemeInfo("ru"),
            new ThemeInfo("en")
        });
        private IEnumerable<ThemeInfo> _cultures;
    }
}

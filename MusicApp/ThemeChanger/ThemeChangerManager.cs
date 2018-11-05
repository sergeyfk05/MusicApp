using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MusicApp.Models;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Основной класс для работы с локализацией
    /// </summary>
    public class ThemeManager
    {
        private ThemeManager()
        {
        }

        private static ThemeManager _themeManager;

        public static ThemeManager Instance => _themeManager ?? (_themeManager = new ThemeManager());

        public event EventHandler ThemeChanged;

        public ThemeInfo CurrentTheme
        {
            get { return ThemeChangerProvider?.CurrentTheme ?? ThemeChangerProvider?.Themes.FirstOrDefault(); }
            set
            {
                if (Equals(value, ThemeChangerProvider?.CurrentTheme))
                    return;

                if(ThemeChangerProvider != null)
                    ThemeChangerProvider.CurrentTheme = value;
                
                OnThemeChanged();
            }
        }

        public IEnumerable<ThemeInfo> Themes => ThemeChangerProvider?.Themes ?? Enumerable.Empty<ThemeInfo>();

        public IThemeChangerProvider ThemeChangerProvider { get; set; }

        private void OnThemeChanged()
        {
            ThemeChanged?.Invoke(this, EventArgs.Empty);
        }

        public object Theme(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "[NULL]";
            var localizedValue = ThemeChangerProvider?.Localize(key);
            return localizedValue ?? $"[{key}]";
        }
    }
}

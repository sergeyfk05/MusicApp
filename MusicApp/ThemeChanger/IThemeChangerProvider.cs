using System.Collections.Generic;
using System.Globalization;
using MusicApp.Models;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Интерфейс для реализации поставщика локализованных строк
    /// </summary>
    public interface IThemeChangerProvider
    {
        /// <summary>
        /// Возвращает локализованный объект по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        object Localize(string key);

        /// <summary>
        /// Доступные культуры
        /// </summary>
        IEnumerable<ThemeInfo> Themes { get; }

        /// <summary>
        /// Текущяя культура
        /// </summary>
        ThemeInfo CurrentTheme { get; set; }
    }
}

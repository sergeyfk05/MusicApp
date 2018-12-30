using System.Collections.Generic;
using System.Globalization;
using MusicApp.Models;

namespace MusicApp.DynamicResource.Base
{
    /// <summary>
    /// Интерфейс для реализации поставщика локализованных строк
    /// </summary>
    public interface IDynamicResourceProvider<T>
    {
        /// <summary>
        /// Возвращает локализованный объект по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns></returns>
        object GetResource(string key);

        /// <summary>
        /// Доступные культуры
        /// </summary>
        IEnumerable<T> Cultures { get; }

        /// <summary>
        /// Текущяя культура
        /// </summary>
        T CurrentCulture{ get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using MusicApp.Models;

namespace MusicApp.ThemeChanger
{
    /// <summary>
    /// Конвертер для получения значения выражения привязки в локализации
    /// </summary>
    public class BindingThemeChangerConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo themeCulture)
        {
            if (values == null || values.Length < 2)
                return null;
            var key = System.Convert.ToString(values[1] ?? "");
            var value = ThemeManager.Instance.Theme(key);
            if (value is string)
            {
                var args = (parameter as IEnumerable<object> ?? values.Skip(2)).ToArray();
                if (args.Length == 1 && !(args[0] is string) && args[0] is IEnumerable)
                    args = ((IEnumerable) args[0]).Cast<object>().ToArray();
                if (args.Any())
                    return string.Format(value.ToString(), args);
            }
            return value;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo themeCulture)
        {
            throw new NotSupportedException();
        }
    }
}

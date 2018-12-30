using MusicApp.DynamicResource.Base;
using MusicApp.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace MusicApp.DynamicResource.Languages
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxLanguagesProvider : IDynamicResourceProvider
    {
        public ResxLanguagesProvider(CultureInfo culture = null)
        {
            //если ничего не передано
            if (culture == null)
                culture = Thread.CurrentThread.CurrentUICulture;

            //если вдруг передана ссылка на културу из списка
            if (!Cultures.Contains(culture))
            {
                Init(culture.Name);
            }
            else
                CurrentCulture = culture;
        }
        public ResxLanguagesProvider(string language)
        {
            Init(language);
        }
        private void Init(string language)
        {
            language.ToLower();

            //ищем полное совпадение
            CultureInfo c = Cultures.FirstOrDefault<CultureInfo>(x => x.Name.ToLower() == language);
            if (c != null)
            {
                CurrentCulture = c;
                return;
            }

            //если не находим полное совпадение культуры, то ищем совпадение с более общей культурой
            if (language.IndexOf('-') != -1)
                language = language.Remove(language.IndexOf('-'));

            c = Cultures.FirstOrDefault<CultureInfo>(x => x.Name.ToLower() == language);
            if (c != null)
                CurrentCulture = c;
            else
                //если не нашли ни одного совпадение - назначаем дефолтную культуру(первую)
                CurrentCulture = Cultures.First();
        }

        private IEnumerable<CultureInfo> _cultures;

        public object GetResource(string key)
        {
            return Language.ResourceManager.GetObject(key);
        }

        public IEnumerable<CultureInfo> Cultures => _cultures ?? (_cultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("ru"),
        });

        public CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
            set
            {
                if (Equals(value, Thread.CurrentThread.CurrentUICulture))
                    return;

                if (!Cultures.Contains(value))
                    throw new ArgumentException("There is no such theme in the list of themes.");

                Thread.CurrentThread.CurrentUICulture = value;
                CultureInfo.DefaultThreadCurrentUICulture = value;
            }
        }
    }
}

using MusicApp.DynamicResource.Base;
using MusicApp.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicApp.DynamicResource.Languages
{
    /// <summary>
    /// Реализация поставщика локализованных строк через ресурсы приложения
    /// </summary>
    public class ResxLanguagesProvider : Provider<CultureInfo>
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
            language = language.ToLower();

            //ищем полное совпадение
            CultureInfo selectedCulture = Cultures.FirstOrDefault<CultureInfo>(x => x.Name.ToLower() == language);
            if (selectedCulture != null)
            {
                CurrentCulture = selectedCulture;
                return;
            }

            //если не находим полное совпадение культуры, то ищем совпадение с более общей культурой
            if (language.IndexOf('-') != -1)
                language = language.Remove(language.IndexOf('-'));

            selectedCulture = Cultures.FirstOrDefault<CultureInfo>(x => x.Name.ToLower() == language);
            if (selectedCulture != null)
                CurrentCulture = selectedCulture;
            else
                //если не нашли ни одного совпадение - назначаем дефолтную культуру(первую)
                CurrentCulture = Cultures.First();
        }

        private IEnumerable<CultureInfo> _cultures;

        public override object GetResource(string key)
        {
            return CurrentCulture.Name == "ru" ? "ru" : "en";
            //return Language.ResourceManager.GetObject(key);
        }

        public override IEnumerable<CultureInfo> Cultures => _cultures ?? (_cultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("ru")
        });
    }
}

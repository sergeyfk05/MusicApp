using MusicApp.DynamicResource.Base;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MusicApp.DynamicResource.Themes
{
    class XMLThemeChangerProvider : Provider<ThemeInfo>
    {
        public XMLThemeChangerProvider(ThemeInfo culture = null)
        {
            //если ничего не передано
            if (culture == null)
                culture = Cultures.ElementAt(0);

            //если вдруг передана ссылка на културу из списка
            if (!Cultures.Contains(culture))
            {
                Init(culture.Name);
            }
            else
                CurrentCulture = culture;
        }
        public XMLThemeChangerProvider(string language)
        {
            Init(language);
        }
        private void Init(string language)
        {
            language = language.ToLower();

            //ищем полное совпадение
            ThemeInfo selectedCulture = Cultures.FirstOrDefault<ThemeInfo>(x => x.Name.ToLower() == language);
            if (selectedCulture != null)
            {
                CurrentCulture = selectedCulture;
                return;
            }

            //если не находим полное совпадение культуры, то ищем совпадение с более общей культурой
            if (language.IndexOf('-') != -1)
                language = language.Remove(language.IndexOf('-'));

            selectedCulture = Cultures.FirstOrDefault<ThemeInfo>(x => x.Name.ToLower() == language);
            if (selectedCulture != null)
                CurrentCulture = selectedCulture;
            else
                //если не нашли ни одного совпадение - назначаем дефолтную культуру(первую)
                CurrentCulture = Cultures.First();
        }

        private IEnumerable<ThemeInfo> _cultures;
        private XElement _languages = XDocument.Load("../../Resources/Themes/Themes.xml").Element("recordings");

        public override object GetResource(string key)
        {
            IEnumerable<XElement> record = _languages.Elements("record").Where(x => x.Attributes("name").ElementAt(0).Value == key);
            return record.Count() > 0 ? record.ElementAt(0).Element(CurrentCulture.Name).Value : "null string";
        }

        public override IEnumerable<ThemeInfo> Cultures => _cultures ?? (_cultures = new List<ThemeInfo>
        {
            new ThemeInfo("dark"),
            new ThemeInfo("white")
        });
    }
}

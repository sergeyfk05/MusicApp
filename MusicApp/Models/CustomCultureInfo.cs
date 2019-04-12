using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class CustomCultureInfo
    {
        public CustomCultureInfo(string name)
        {
            if (CustomCulturesInfo.FirstOrDefault(x => x.Name == name) != null)
                throw new ArgumentException($"ThemeInfo instance with {name} already created.");

            Name = name;
            CustomCulturesInfo.Add(this);
        }

        public string Name { get; private set; }


        public static List<CustomCultureInfo> CustomCulturesInfo => _customCulturesInfo ?? (_customCulturesInfo = new List<CustomCultureInfo>());
        private static List<CustomCultureInfo> _customCulturesInfo;
    }
}

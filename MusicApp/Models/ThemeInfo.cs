using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class ThemeInfo
    {
        public ThemeInfo(string name)
        {
            if (ThemesInfo.FirstOrDefault(x => x.Name == name) != null)
                throw new ArgumentException($"ThemeInfo instance with {name} already created.");

            Name = name;
            ThemesInfo.Add(this);
        }

        public string Name { get; private set; }


        public static List<ThemeInfo> ThemesInfo => _themeInfos ?? (_themeInfos = new List<ThemeInfo>());
        private static List<ThemeInfo> _themeInfos;
    }
}

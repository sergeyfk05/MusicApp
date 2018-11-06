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
            if (_themeInfos.FirstOrDefault(x => x.Name == name) != null)
                throw new ArgumentException($"ThemeInfo instance with {name} already created.");

            //_themeInfos.Add(new ThemeInfo(name));
            Name = name;
        }

        public string Name { get; private set; }

        private static List<ThemeInfo> _themeInfos = new List<ThemeInfo>();
    }
}

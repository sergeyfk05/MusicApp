using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class MenuItem
    {
        public MenuItem(string label)
        {
            LabelText = label;
        }
        public string IconText { get; internal set; }
        public string LabelText { get; internal set; }
        public string Name { get; internal set; }
    }
}

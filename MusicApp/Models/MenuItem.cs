using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MusicApp.Models
{
    public class MenuItem
    {
        public MenuItem(string iconText, string labelText, string name, Page content)
        {
            IconText = iconText;
            LabelText = labelText;
            Name = name;
            Content = content;
        }
        public string IconText { get; internal set; }
        public string LabelText { get; internal set; }
        public string Name { get; internal set; }
        public Page Content { get; internal set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.ViewModels;
using MusicApp.Resources.DataTemplates;
using System.Collections.ObjectModel;
using MusicApp.Models;
using System.Windows;

namespace MusicApp.Configs
{
    internal static class ViewConfig
    {
        internal static List<ViewInfo> GetAllViewInfo()
        {
            return _viewsInfo;
        }
        internal static ViewInfo GetViewInfoByName(string name)
        {
            return _viewsInfo.Single(x => x.Name.ToLower() == name.ToLower());
        }
        private static readonly List<ViewInfo> _viewsInfo = new List<ViewInfo>()
        {
            new ViewInfo("Base", typeof(MusicApp.Views.MainWindow), new BaseViewModel()),
            new ViewInfo("Menu", typeof(Views.HamburgerMenu), new HumburgerMenuViewModel()),
            new ViewInfo("Home", typeof(MusicApp.Views.HamburgerMenu), new HumburgerMenuViewModel()),
            new ViewInfo("Performers", typeof(MusicApp.Views.HamburgerMenu), new HumburgerMenuViewModel()),
            new ViewInfo("Settings", typeof(MusicApp.Views.HamburgerMenu), new HumburgerMenuViewModel())
        };

        internal static IEnumerable<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>()
        {
            new MenuItem{ IconText = (string)StaticResources["Menu_MainPageIcon"], LabelText = (string)StaticResources["Menu_MainPage"], Name="Home" },
            new MenuItem{ IconText = (string)StaticResources["Menu_PerformersIcon"], LabelText = (string)StaticResources["Menu_Performers"], Name="Performers" },
            new MenuItem{ IconText = (string)StaticResources["Menu_SettingsIcon"], LabelText = (string)StaticResources["Menu_Settings"], Name="Settings" },
        };
        }


        internal static ResourceDictionary StaticResources { get; set; } = Application.Current.Resources;

    }
}

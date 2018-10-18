using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicApp.ViewModels;
using System.Collections.ObjectModel;
using MusicApp.Models;
using System.Windows;

namespace MusicApp.Configs
{
    internal static class ViewConfig
    {
        internal static List<ViewInfo> GetAllViewInfo()
        {
            return viewsInfo;
        }
        internal static ViewInfo GetViewInfoByName(string name)
        {
            return viewsInfo.Single(x => x.Name.ToLower() == name.ToLower());
        }
        private static readonly List<ViewInfo> viewsInfo = new List<ViewInfo>()
        { 
        };

    }
}

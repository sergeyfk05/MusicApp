﻿using System;
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
            new ViewInfo("Base", typeof(MusicApp.Views.MainWindow), new BaseViewModel()),
            new ViewInfo("Menu", typeof(Views.MainWindow), new MenuViewModel()),
            new ViewInfo("Home", typeof(MusicApp.Views.MainWindow), new MenuViewModel()),
            new ViewInfo("Performers", typeof(MusicApp.Views.MainWindow), new MenuViewModel()),
            new ViewInfo("Settings", typeof(MusicApp.Views.MainWindow), new MenuViewModel())
        };

    }
}

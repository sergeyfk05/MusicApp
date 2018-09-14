using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.ViewModels
{
    internal interface IMenuViewModel
    {
        bool Menu_IsOpen { get; set; }

        void CloseMenu();
        List<MenuItem> MenuList { get; }
    }
}

using MusicApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    internal interface IMenuViewModel
    {
        bool Menu_IsOpen { get; set; }
        bool BaseWindowContent_IsBlur { get; set; }

        ICommand CloseMenu { get; }
        List<MenuItem> MenuList { get; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}

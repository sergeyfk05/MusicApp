using System.ComponentModel;
using System.Windows;

namespace MusicApp.ViewModels
{
    public interface IBaseViewModel : IViewModel
    {
        bool IsBlur { get; set; }
    }
}


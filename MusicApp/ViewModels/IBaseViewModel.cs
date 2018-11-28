using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public interface IBaseViewModel : IViewModel
    {
        bool IsOpen { get; set; }
        ICommand ClickContent { get; }
    }
}


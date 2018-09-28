using NLog;

namespace MusicApp.ViewModels
{
    public interface IViewModel
    {
        Logger logger { get; set; }
    }
}

using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    public interface IEventManager
    {
        void AddListener(Manager source, IWeakEventListener listener);

        void RemoveListener(Manager source, IWeakEventListener listener);
    }
}

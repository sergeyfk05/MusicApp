using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    public interface IEventManager
    {
        void AddListener(BaseManager source, IWeakEventListener listener);

        void RemoveListener(BaseManager source, IWeakEventListener listener);
    }
}

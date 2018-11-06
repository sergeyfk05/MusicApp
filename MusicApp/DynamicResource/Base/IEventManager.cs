using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    public interface IEventManager
    {
        void AddListener(IDynamicResourceManager source, IWeakEventListener listener);

        void RemoveListener(IDynamicResourceManager source, IWeakEventListener listener);
    }
}

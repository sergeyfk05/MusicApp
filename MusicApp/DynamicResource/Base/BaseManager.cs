using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DynamicResource.Base
{
    public abstract class BaseManager<T>
    {
        public event EventHandler CultureChanged;

        public T CurrentCulture
        {
            get
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                return Provider.CurrentCulture;
            }
            set
            {
                if (Provider == null)
                    throw new NullReferenceException("Provider is null");

                if (Equals(value, Provider.CurrentCulture))
                    return;

                Provider.CurrentCulture = value;
                OnCultureChanged();
            }
        }

        public IEnumerable<T> Cultures => Provider?.Cultures ?? Enumerable.Empty<T>();

        public IDynamicResourceProvider<T> Provider { protected get; set; }

        private void OnCultureChanged()
        {
            CultureChanged?.Invoke(this, EventArgs.Empty);
        }

        public abstract object GetResource(string key);
    }
}

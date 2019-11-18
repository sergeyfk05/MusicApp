using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.DynamicResource
{
    public abstract class Provider<T>
    {
        public abstract object GetResource(string key);
        public abstract IEnumerable<T> Cultures { get; }

        public T CurrentCulture
        {
            get { return _currentCulture; }
            set
            {
                if (Equals(value, _currentCulture))
                    return;

                if (!Cultures.Contains(value))
                    throw new ArgumentException("There is no such culture in the list of cultures.");

                _currentCulture = value;
            }
        }
        private T _currentCulture;
    }
}

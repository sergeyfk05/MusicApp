using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApp.DynamicResource.Base
{
    public abstract class BaseProvider<T>
    {
        //ResourceDictionary RD = new ResourceDictionary();

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
                //rd.Source = new Uri("ms-appx:///Dictionary1.xaml");
            }
        }
        private T _currentCulture;
    }
}

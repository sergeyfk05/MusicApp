using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MusicApp.Configs;
using MusicApp.Models;

namespace MusicApp.ViewModels
{
    internal class BaseViewModel : IViewModel, INotifyPropertyChanged, IBaseViewModel
    {
        public ResourceDictionary ViewResources
        {
            get { return _resources; }
            set
            {
                if (_resources != value)
                {
                    _resources = value;
                }
            }
        }
        private ResourceDictionary _resources;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
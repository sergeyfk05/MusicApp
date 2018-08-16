using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MusicApp.Configs;
using MusicApp.Models;

namespace MusicApp.ViewModels
{
    internal class BaseViewModel : IViewModel, INotifyPropertyChanged, IBaseViewModel
    {
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private string title = "";

        public string ActivePageText
        {
            get { return String.IsNullOrEmpty(activePageText) ? ViewConfig.StaticResources?["Menu_MainPage"] as string : activePageText; }
            set
            {
                activePageText = value;
                OnPropertyChanged("ActivePageText");
            }
        }
        private string activePageText = "";

        public void Loaded_Execute(object obj) { }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
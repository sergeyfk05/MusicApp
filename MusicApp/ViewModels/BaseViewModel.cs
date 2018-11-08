using MusicApp.Models.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections;
using MusicApp.Models;
using System.Collections.Generic;
using MusicApp.Views;
using MusicApp.DynamicResource.Languages;

namespace MusicApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IBaseViewModel
    {
        public bool IsBlur
        {
            get => isBlur;
            set
            {
                if (isBlur != value)
                {
                    isBlur = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isBlur;

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                if(value != isOpen)
                {
                    isOpen = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isOpen;

        public IEnumerable<MenuItem> ItemsSource
        {
            get
            {
                return new List<MenuItem>()
                {
                    new MenuItem("", "dsfdsfddddddddddddddddddddddddd", "menu"),
                    new MenuItem("", "settings", "settings")
                };
            }
            set
            {

            }
        }


        private ICommand clickContent;
        public ICommand ClickContent
        {
            get
            {
                if (clickContent == null)
                    clickContent = new RelayCommand(this.ClickContent_Execute, () => IsOpen);

                return clickContent;
            }
        }
        private void ClickContent_Execute()
        {
            //foreach (var i in LanguagesManager.Instance.Cultures)
            //{
            //    if (i != LanguagesManager.Instance.CurrentCulture)
            //    {
            //        LanguagesManager.Instance.CurrentCulture = i;
            //        break;
            //    }
            //}
            IsOpen = false;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
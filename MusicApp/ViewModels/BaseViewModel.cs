using MusicApp.Models.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections;
using MusicApp.Models;
using System.Collections.Generic;
using MusicApp.Views;
using MusicApp.DynamicResource.Languages;
using System.Threading.Tasks;
using System.Linq;

namespace MusicApp.ViewModels
{
    public class BaseViewModel : ViewModel
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

        public MenuItem ActiveMenuItem
        {
            get { return activeMenuItem; }
            set
            {
                if(!Equals(value, activeMenuItem))
                {
                    activeMenuItem = value;
                    OnPropertyChanged();
                }
            }
        }
        private MenuItem activeMenuItem;

        public IEnumerable<MenuItem> ItemsSource
        {
            get
            {
                return new List<MenuItem>()
                {
                    new MenuItem("", "dsfdsfddddddddddddddddddddddddd", "Home", new HomeView()),
                    new MenuItem("", "settings", "settings", new SettingsView())
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
            IsOpen = false;
        }


    }
}
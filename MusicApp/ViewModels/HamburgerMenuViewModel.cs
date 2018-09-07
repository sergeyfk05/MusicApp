using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicApp.Configs;
using MusicApp.Views;
using System.Windows;
using System.Windows.Media.Animation;
using MusicApp.Logic;
using System.Windows.Media.Effects;

namespace MusicApp.ViewModels
{
    internal sealed class HamburgerMenuViewModel : INotifyPropertyChanged, IViewModel
    {
        public bool HamburgerMenu_IsOpen
        {
            get { return _hamburgerMenu_IsOpen; }
            set
            {
                if(_hamburgerMenu_IsOpen != value)
                {
                    _hamburgerMenu_IsOpen = value;
                    OnPropertyChanged("HamburgerMenu_IsOpen");
                }
            }
        }
        private bool _hamburgerMenu_IsOpen = false;


        private ICommand _clickHumburgerButton;
        public ICommand ClickHumburgerButton
        {
            get
            {
                if (_clickHumburgerButton == null)
                    _clickHumburgerButton = new RelayCommand<object>(this.ClickHumburgerButton_Execute); 

                return _clickHumburgerButton;
            }
        }
        private void ClickHumburgerButton_Execute()
        {
            if (ViewConfig.GetViewInfoByName("Base").ViewModel is BaseViewModel baseVM)
                baseVM.IsBlur = !baseVM.IsBlur;
            HamburgerMenu_IsOpen = !HamburgerMenu_IsOpen;        
        }
        internal void CloseHamburgerMenu()
        {
            if (ViewConfig.GetViewInfoByName("Base").ViewModel is BaseViewModel baseVM)
                baseVM.IsBlur = false;
            HamburgerMenu_IsOpen = false;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public List<MenuItem> list
        {
            get { return new List<MenuItem>()
            {
                new MenuItem("\xE80F", "sdsadas", "Base"),
                new MenuItem("\xE713", "sdsadassdasdasdass", "Settings"),
                new MenuItem("\xE72D", "sdsadasytjhyfgffhf", ""),

            };
            }
            set { }
        }
    }
}

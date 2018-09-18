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
    public sealed class HamburgerMenuViewModel : INotifyPropertyChanged, IViewModel, IMenuViewModel
    {
        public bool Menu_IsOpen
        {
            get { return _menu_IsOpen; }
            set
            {
                if (_menu_IsOpen != value)
                {
                    _menu_IsOpen = value;
                    OnPropertyChanged("Menu_IsOpen");
                }
            }
        }
        private bool _menu_IsOpen = false;
        public bool BaseWindowContent_IsBlur
        {
            get { return _baseWindowContent_IsBlur; }
            set
            {
                if(_baseWindowContent_IsBlur != value)
                {
                    _baseWindowContent_IsBlur = value;
                    OnPropertyChanged("BaseWindowContent_IsBlur");
                }
            }
        }
        private bool _baseWindowContent_IsBlur = false;

        private ICommand _clickMenuButton;
        public ICommand ClickMenuButton
        {
            get
            {
                if (_clickMenuButton == null)
                    _clickMenuButton = new RelayCommand<object>(this.ClickMenuButton_Execute);

                return _clickMenuButton;
            }
        }
        private void ClickMenuButton_Execute()
        {
            Menu_IsOpen = !Menu_IsOpen;
            BaseWindowContent_IsBlur = Menu_IsOpen;
        }
        public void CloseMenu()
        {
            Menu_IsOpen = false;
            BaseWindowContent_IsBlur = false;
        }


        public List<MenuItem> MenuList
        {
            get { return _menuList; }
        }
        private List<MenuItem> _menuList = new List<MenuItem>()
            {
                new MenuItem("\xE80F", "sdsadas", "Base"),
                new MenuItem("\xE713", "sdsadassdasdasdass", "Settings"),
                new MenuItem("\xE72D", "sdsadasytjhyfgffhf", "")
            };

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

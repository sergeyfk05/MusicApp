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
        //public bool Animate
        //{
        //    get { return animate; }
        //    set
        //    {
        //        if(animate != value)
        //        {
        //            animate = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        //private bool animate = false;


        public bool Menu_IsOpen
        {
            get { return menu_IsOpen; }
            set
            {
                if (menu_IsOpen != value)
                {
                    menu_IsOpen = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool menu_IsOpen = false;
        public bool BaseWindowContent_IsBlur
        {
            get { return baseWindowContent_IsBlur; }
            set
            {
                if(baseWindowContent_IsBlur != value)
                {
                    baseWindowContent_IsBlur = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool baseWindowContent_IsBlur = false;

        private ICommand clickMenuButton;
        public ICommand ClickMenuButton
        {
            get
            {
                if (clickMenuButton == null)
                    clickMenuButton = new RelayCommand<object>(this.ClickMenuButton_Execute);

                return clickMenuButton;
            }
        }
        private void ClickMenuButton_Execute()
        {
            Animate = true;
            Menu_IsOpen = !Menu_IsOpen;
            BaseWindowContent_IsBlur = Menu_IsOpen;
        }
        public void CloseMenu()
        {
            Animate = true;
            Menu_IsOpen = false;
            BaseWindowContent_IsBlur = false;
        }


        public List<MenuItem> MenuList
        {
            get { return menuList; }
        }
        private List<MenuItem> menuList = new List<MenuItem>()
            {
                new MenuItem("\xE80F", "sdsadas", "Base"),
                new MenuItem("\xE713", "sdsadassdasdasdass", "Settings"),
                new MenuItem("\xE72D", "sdsadasytjhyfgffhf", "")
            };

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

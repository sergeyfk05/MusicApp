using MusicApp.Models;
using MusicApp.Models.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MusicApp.ViewModels
{
    public sealed class MenuViewModel : INotifyPropertyChanged, IMenuViewModel
    {
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
                    clickMenuButton = new RelayCommand(this.ClickMenuButton_Execute);

                return clickMenuButton;
            }
        }
        private void ClickMenuButton_Execute()
        {
            Menu_IsOpen = !Menu_IsOpen;
            BaseWindowContent_IsBlur = Menu_IsOpen;
        }

        private ICommand closeMenu;
        public ICommand CloseMenu
        {
            get
            {
                if (closeMenu == null)
                    closeMenu = new RelayCommand(this.CloseMenu_Execute, () => menu_IsOpen);

                return closeMenu;
            }
        }       
        public void CloseMenu_Execute()
        {
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

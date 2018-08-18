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
using MusicApp.Resources.DataTemplates;
using MusicApp.Views;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;

namespace MusicApp.ViewModels
{
    public sealed class HumburgerMenuViewModel : INotifyPropertyChanged, IViewModel
    {
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
            string sbName = IsOpen ? "HamburgerMenu_CloseMenu" : "HamburgerMenu_OpenMenu";
            (Application.Current.TryFindResource(sbName) as Storyboard).Begin();
            IsOpen = !IsOpen;
        }
        private bool IsOpen = false;


        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

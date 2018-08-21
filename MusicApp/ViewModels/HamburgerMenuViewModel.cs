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
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;
using MusicApp.Logic;

namespace MusicApp.ViewModels
{
    internal sealed class HamburgerMenuViewModel : INotifyPropertyChanged, IViewModel
    {
        /// <summary>
        /// turn on/off animations
        /// </summary>
        public bool HamburgerMenu_IsAnimate
        {
            get { return _hamburgerMenu_IsAnimate; }
            set
            {
                if(_hamburgerMenu_IsAnimate != value)
                {
                    _hamburgerMenu_IsAnimate = value;
                    OnPropertyChanged("HamburgerMenu_IsLoaded");
                }
            }
        }
        private bool _hamburgerMenu_IsAnimate;

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
            HamburgerMenu_IsAnimate = true;
            HamburgerMenu_IsOpen = !HamburgerMenu_IsOpen;
        }


        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

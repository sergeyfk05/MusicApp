﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp.Resources.Controls
{
    /// <summary>
    /// Логика взаимодействия для HamburgerMenu.xaml
    /// </summary>
    public partial class HamburgerMenu : UserControl
    {
        public HamburgerMenu()
        {
            InitializeComponent();
        }

        #region Main properties

        /// <summary>
        /// Получает или задает в каком состоянии находится меню(открыто/закрыто).
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set
            {
                if(value != IsOpen)
                    if (!IsOpen)
                        OnOpened();
                    else
                        OnClosed();
                SetValue(IsOpenProperty, value);                
            }
        }
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(HamburgerMenu), new PropertyMetadata(false));

        /// <summary>
        /// Ширина в закрытом состоянии.
        /// </summary>
        public double ClosedWidth
        {
            get { return (double)GetValue(ClosedWidthProperty); }
            set { SetValue(ClosedWidthProperty, value); }
        }
        public static readonly DependencyProperty ClosedWidthProperty =
            DependencyProperty.Register("ClosedWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)72));

        /// <summary>
        /// Максимальная ширина в открытом состоянии.
        /// </summary>
        public double MaxOpenWidth
        {
            get { return (double)GetValue(MaxOpenWidthProperty); }
            set { SetValue(MaxOpenWidthProperty, value); }
        }
        public static readonly DependencyProperty MaxOpenWidthProperty =
            DependencyProperty.Register("MaxOpenWidth", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)300));

        /// <summary>
        /// Основной цвет фона меню.
        /// </summary>
        public SolidColorBrush Background
        {
            get { return (SolidColorBrush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Blue)));

        #endregion

        #region TopPanel properties

        /// <summary>
        /// Цвет заливки кнопки открытия/закрытия.
        /// </summary>
        public SolidColorBrush ToggleButtonColor
        {
            get { return (SolidColorBrush)GetValue(ToggleButtonColorProperty); }
            set { SetValue(ToggleButtonColorProperty, value); }
        }
        public static readonly DependencyProperty ToggleButtonColorProperty =
            DependencyProperty.Register("ToggleButtonColor", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

        /// <summary>
        /// Фон верхней панели меню.
        /// </summary>
        public SolidColorBrush TopPanelBackgroundColor
        {
            get { return (SolidColorBrush)GetValue(TopPanelBackgroundColorProperty); }
            set { SetValue(TopPanelBackgroundColorProperty, value); }
        }
        public static readonly DependencyProperty TopPanelBackgroundColorProperty =
            DependencyProperty.Register("TopPanelBackgroundColor", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        /// <summary>
        /// Высота верхней панели меню.
        /// </summary>
        public double TopPanelHeight
        {
            get { return (double)GetValue(TopPanelHeightProperty); }
            set { SetValue(TopPanelHeightProperty, value); }
        }
        public static readonly DependencyProperty TopPanelHeightProperty =
            DependencyProperty.Register("TopPanelHeight", typeof(double), typeof(HamburgerMenu), new PropertyMetadata((double)60));

        /// <summary>
        /// Цвет фона кнопки открытия/закрытия меню.
        /// </summary>
        public SolidColorBrush ToggleButtonBackground
        {
            get { return (SolidColorBrush)GetValue(ToggleButtonBackgroundProperty); }
            set { SetValue(ToggleButtonBackgroundProperty, value); }
        }
        public static readonly DependencyProperty ToggleButtonBackgroundProperty =
            DependencyProperty.Register("ToggleButtonBackground", typeof(SolidColorBrush), typeof(HamburgerMenu), new PropertyMetadata(new SolidColorBrush(Colors.White)));

        #endregion

        #region routed events

        /// <summary>
        /// Событие, вызываемое при открытии меню.
        /// </summary>
        public static readonly RoutedEvent OpenedEvent =
            EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HamburgerMenu));
        public event RoutedEventHandler Opened
        {
            add { AddHandler(OpenedEvent, value); }
            remove { RemoveHandler(OpenedEvent, value); }
        }
        public void OnOpened()
        {
            RaiseEvent(new RoutedEventArgs(HamburgerMenu.OpenedEvent));
        }

        /// <summary>
        /// Событие, вызываемое при закрытиии меню.
        /// </summary>
        public static readonly RoutedEvent ClosedEvent =
            EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HamburgerMenu));
        public event RoutedEventHandler Closed
        {
            add { AddHandler(ClosedEvent, value); }
            remove { RemoveHandler(ClosedEvent, value); }
        }
        public void OnClosed()
        {
            RaiseEvent(new RoutedEventArgs(HamburgerMenu.ClosedEvent));
        }

        #endregion

        private void HamburgerMenuToggleButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is HamburgerMenuToggleButton button)
                button.IsParallel = IsOpen;
            IsOpen = !IsOpen;
        }
    }
}
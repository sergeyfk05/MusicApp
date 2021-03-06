﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp.Resources.Controls
{
    /// <summary>
    /// Логика взаимодействия для HamburgerMenuButton.xaml
    /// </summary>
    public partial class HamburgerMenuToggleButton : UserControl
    {
        public HamburgerMenuToggleButton()
        {
            InitializeComponent();
        }

        #region properties
        
        /// <summary>
        /// Цвет заливки прямоугольников кнопки.
        /// </summary>
        public SolidColorBrush Color
        {
            get { return (SolidColorBrush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(SolidColorBrush), typeof(HamburgerMenuToggleButton), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
       
        /// <summary>
        /// Получает или задает положение прямоугольников кнопки(паралельное или крестом).
        /// </summary>
        public bool IsParallel
        {
            get { return (bool)GetValue(IsParallelProperty); }
            set
            {
                SetValue(IsParallelProperty, value);
            }
        }
        public static readonly DependencyProperty IsParallelProperty =
            DependencyProperty.Register("IsParallel", typeof(bool), typeof(HamburgerMenuToggleButton), new UIPropertyMetadata(true, OnIsParallelChanged));

        #endregion

        #region callbacks

        private static void OnIsParallelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is HamburgerMenuToggleButton button)
            {
                if (button.IsParallel)
                    button.OnParalleled();
                else
                    button.OnCrossed();
            }
        }

        #endregion

        #region routed events

        /// <summary>
        /// Событие, вызываемое при начале приведения прямоугольников кнопки в крестообразное положение.
        /// </summary>
        public static readonly RoutedEvent CrossedEvent = EventManager.RegisterRoutedEvent(
            "Crossed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HamburgerMenuToggleButton));
        public event RoutedEventHandler Crossed
        {
            add { AddHandler(CrossedEvent, value); }
            remove { RemoveHandler(CrossedEvent, value); }
        }
        public void OnCrossed()
        {
            RaiseEvent(new RoutedEventArgs(HamburgerMenuToggleButton.CrossedEvent));
        }

        /// <summary>
        /// Событие, вызываемое при начале приведения прямоугольников кнопки в параллельное положение.
        /// </summary>
        public static readonly RoutedEvent ParalleledEvent = EventManager.RegisterRoutedEvent(
            "Paralleled", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(HamburgerMenuToggleButton));
        public event RoutedEventHandler Paralleled
        {
            add { AddHandler(ParalleledEvent, value); }
            remove { RemoveHandler(ParalleledEvent, value); }
        }
        public void OnParalleled()
        {
            RaiseEvent(new RoutedEventArgs(HamburgerMenuToggleButton.ParalleledEvent));
        }

        #endregion

    }
}

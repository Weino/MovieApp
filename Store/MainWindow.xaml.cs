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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            
            if (tg_btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_news.Visibility = Visibility.Collapsed;
                tt_movies.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_news.Visibility = Visibility.Visible;
                tt_movies.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_btn_unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Tg_btn_checked(object sender, RoutedEventArgs e)
        {
            
        }


        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tg_btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home.Visibility = Visibility.Visible;
            Movies.Visibility = Visibility.Hidden;
            News.Visibility = Visibility.Hidden;
        }

        private void Movie_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home.Visibility = Visibility.Hidden;
            Movies.Visibility = Visibility.Visible;
            News.Visibility = Visibility.Hidden;
        }

        private void News_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Home.Visibility = Visibility.Hidden;
            Movies.Visibility = Visibility.Hidden;
            News.Visibility = Visibility.Visible;
        }
    }
}

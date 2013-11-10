﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Net.Http;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace VITacademics
{
    public partial class Captcha : UserControl
    {
        DataHandler dat = new DataHandler();
        public Captcha()
        {
            InitializeComponent();
            Uri uri = new Uri("http://vitacademicsrel.appspot.com/captcha/" + dat.getReg());
            prg_loading.Visibility = System.Windows.Visibility.Visible;
            //IGNORE CACHED IMAGES
            BitmapImage b = new BitmapImage(uri);
            b.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            img_Captcha.Source = b;
            img_Captcha.Stretch = Stretch.UniformToFill;
            textBox1.Focus();
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            prg_loading.Visibility = System.Windows.Visibility.Visible;
            img_Captcha.Source = null;
            Uri uri = new Uri("http://vitacademicsrel.appspot.com/captcha/" + dat.getReg());
            BitmapImage b= new BitmapImage(uri);
            b.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            img_Captcha.Source = b;
            img_Captcha.Stretch = Stretch.UniformToFill;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            dat.saveData("CAPTCHA", textBox1.Text.ToUpper());
        }

        private void img_Captcha_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Connection Error");
            prg_loading.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void img_Captcha_Loaded(object sender, RoutedEventArgs e)
        {
            prg_loading.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}

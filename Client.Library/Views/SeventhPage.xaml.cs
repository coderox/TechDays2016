using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Client.Views
{
    public sealed partial class SeventhPage : INotifyPropertyChanged
    {
        public SeventhPage()
        {
            this.InitializeComponent();
            this.DataContext = this;

            SizeChanged += OnSizeChanged;
        }

        private double itemWidth = 200;
        public double ItemWidth
        {
            get { return itemWidth; }
            set {
                itemWidth = value;
                if(PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemWidth"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = e.NewSize.Width;
            var height = e.NewSize.Height - appBar.ActualHeight;

            var margin = width <= 640 ? 12 : 24;
            double itemWidth = 0;
            double itemHeight = 0;
            if (width < 641) { // small
                itemWidth = width - (2 * margin);
                itemHeight = Math.Floor(height / 3);
            } else if (width < 1008) { // medium
                itemWidth = (width - (2 * margin)) / 2;
                itemHeight = Math.Floor(height / 2);
            } else { // large
                itemWidth = (width - (2 * margin)) / 3;
                itemHeight = height;
            }

            ItemWidth = itemWidth;
            //gridItems.ItemHeight = itemHeight;
            //gridItems.ItemWidth = itemWidth;
        }
    }
}

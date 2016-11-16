using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Media;

namespace Client.Models
{
    public class SimpleItem
    {
        public enum ItemWidth
        {
            Standard,
            Double
        }

        public ItemWidth Width { get; set; }

        public Brush Brush { get; set; }
    }
}

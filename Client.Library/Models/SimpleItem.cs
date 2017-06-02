using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public string FirstLine {
            get {
                Debug.WriteLine("FirstLine bound");
                return "First";
            }
        }

        public string SecondLine
        {
            get
            {
                Debug.WriteLine(" SecondLine bound");
                return "Second";
            }
        }

        public string ThirdLine
        {
            get
            {
                Debug.WriteLine("  ThirdLine bound");
                return "Third";
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Client.Views
{
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
        }

        private void DoWork()
        {
#if DEVELOP
            // Do work in development configuration
            EvenMoreWorkDoneHere();
#elif TEST
            // Do work in test configuration                
#else
            // Do work in production configuration
#endif
        }
    }
}

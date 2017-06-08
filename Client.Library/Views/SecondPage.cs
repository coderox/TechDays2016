using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace Client.Views
{
    public sealed partial class SecondPage : Page
    {
        partial void EvenMoreWorkDoneHere(ref int par);

        public SecondPage()
        {
            this.InitializeComponent();

            DoWork();
        }

        void DoWork()
        {
#if DEVELOP
            // Do work in development configuration
            MoreWorkDoneHere();
#elif TEST
            // Do work in test configuration                
#else
            // Do work in production configuration
#endif
            int theAnswer = 42;
            EvenMoreWorkDoneHere(ref theAnswer);
            Debug.WriteLine(theAnswer);
        }
    }
}

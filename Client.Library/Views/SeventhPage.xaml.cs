using System;
using Windows.UI.Xaml;
using Client.ViewModels;

namespace Client.Views
{
    public sealed partial class SeventhPage
    {
        MainViewModel ViewModel { get { return this.DataContext as MainViewModel; } }

        public SeventhPage()
        {
            this.InitializeComponent();

            this.DataContext = new MainViewModel();

            Loaded += async delegate {

                if (ActualWidth < 641) {
                    VisualStateManager.GoToState(this, "small", false);
                } else if (ActualWidth < 1008) {
                    VisualStateManager.GoToState(this, "medium", false);
                } else {
                    VisualStateManager.GoToState(this, "large", false);
                }

                await ViewModel.LoadAsync();
            };
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {       
            ViewModel.ItemWidth = Math.Floor(e.NewSize.Width / ViewModel.MaximumRowsOrColumns);
        }
    }
}

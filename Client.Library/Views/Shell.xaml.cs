namespace Client.Views
{
    using System;
    using ViewModels;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class Shell
    {
        public Shell()
        {
            this.InitializeComponent();

            this.DataContext = new MenuViewModel(ApplicationFrame);

            ApplicationFrame.Navigated += ApplicationFrame_Navigated;

            // Hook up the default Back handler
            SystemNavigationManager.GetForCurrentView().BackRequested += BackHandler;
        }

        private void BackHandler(object sender, BackRequestedEventArgs e)
        {
            if (ApplicationFrame.CanGoBack) {
                ApplicationFrame.GoBack();
                e.Handled = true;
            }
        }

        private void ApplicationFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            // show the shell back only if there is anywhere to go in the default frame
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = ApplicationFrame.CanGoBack 
                    ? AppViewBackButtonVisibility.Visible
                    : AppViewBackButtonVisibility.Collapsed;
        }
    }
}

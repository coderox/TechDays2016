using System;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Template10.Services.ViewService;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Client.Views
{
    public sealed partial class Template10Page
    {
        public Template10Page(INavigationService navigationService)
        {
            this.InitializeComponent();
            this.Menu.NavigationService = navigationService;
        }
    }
}

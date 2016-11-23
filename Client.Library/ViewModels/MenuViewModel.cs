using Client.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Client.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        private readonly Frame frame;

        public class MenuItem
        {
            public string Label { get; set; }
            public string Icon { get; set; }
            public Type PageType { get; set; }
        }

        private bool isMenuOpen = false;
        public bool IsMenuOpen
        {
            get { return isMenuOpen; }
            set
            {
                if (isMenuOpen != value) {
                    isMenuOpen = value;
                    if (PropertyChanged != null) {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsMenuOpen"));
                    }
                }
            }
        }

        public ICommand ToggleMenuCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public IList<MenuItem> MenuItems { get; private set; }

        private MenuItem selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set
            {
                if(selectedMenuItem != value) {
                    selectedMenuItem = value;
                    if (selectedMenuItem.PageType != null && selectedMenuItem.PageType != frame.SourcePageType) {
                        frame.Navigate(selectedMenuItem.PageType);
                    }
                    if(PropertyChanged != null) {
                        PropertyChanged(this, new PropertyChangedEventArgs("SelectedMenuItem"));
                    }
                }
            }
        }

        public MenuViewModel(Frame frame)
        {
            this.frame = frame;
            frame.Navigated += OnFrameNavigated;

            this.ToggleMenuCommand = new DelegateCommand(() => this.IsMenuOpen = !this.IsMenuOpen);

            MenuItems = new List<MenuItem> {
                new MenuItem { Label = "Today", Icon = "\uE10F" , PageType = typeof(Views.TodayPage) },
                new MenuItem { Label = "Interests", Icon = "\uE24A" , PageType = typeof(Views.InterestsPage) },
                new MenuItem { Label = "Sources", Icon = "\uE158", PageType = typeof(Views.SourcesPage) }, 
                new MenuItem { Label = "Local", Icon = "\uE8F0" },
                new MenuItem { Label = "Videos", Icon = "\uE102" },
                new MenuItem { Label = "Send Feedback", Icon = "\uE170" },
            };

            selectedMenuItem = MenuItems[0];
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            var menuItem = MenuItems.FirstOrDefault(mi => mi.PageType == e.SourcePageType);
            if(menuItem != null && menuItem != selectedMenuItem) {
                SelectedMenuItem = menuItem;
            }
        }
    }
}

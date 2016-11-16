using Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Client.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SimpleItem> Items { get; private set; }

        private double itemWidth = 200;
        public double ItemWidth
        {
            get { return itemWidth; }
            set
            {
                itemWidth = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("ItemWidth"));
                }
            }
        }

        private int maximumRowsOrColumns = 1;
        public int MaximumRowsOrColumns
        {
            get { return maximumRowsOrColumns; }
            set
            {
                maximumRowsOrColumns = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("MaximumRowsOrColumns"));
                }
            }
        }

        private int columnSpan = 1;
        public int ColumnSpan
        {
            get { return columnSpan; }
            set
            {
                columnSpan = value;
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColumnSpan"));
                }
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<SimpleItem>();
        }

        public Task LoadAsync()
        {
            Items.Clear();

            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Red), Width = SimpleItem.ItemWidth.Double });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Green) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Gray) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Blue) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Yellow) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Pink), Width = SimpleItem.ItemWidth.Double });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Purple) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.CornflowerBlue) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.Orange) });
            Items.Add(new SimpleItem { Brush = new SolidColorBrush(Colors.DarkOliveGreen) });

            return Task.CompletedTask;
        }
    }
}

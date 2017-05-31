using Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class TodayViewModel : ViewModelBase
    {
        public ObservableCollection<NewsItem> MyNews { get; private set; }

        private double itemWidth = 200;
        public double MyNewsItemWidth
        {
            get { return itemWidth; }
            set
            {
                itemWidth = value;
                RaisePropertyChanged("MyNewsItemWidth");
            }
        }

        private int maximumRowsOrColumns = 1;
        public int MyNewsMaximumRowsOrColumns
        {
            get { return maximumRowsOrColumns; }
            set
            {
                maximumRowsOrColumns = value;
                RaisePropertyChanged("MyNewsMaximumRowsOrColumns");
            }
        }


        public TodayViewModel()
        {
            MyNews = new ObservableCollection<NewsItem>();
        }

        public Task LoadAsync()
        {
            MyNews.Add(new NewsItem { Id = 1, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 2, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 3, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 4, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 5, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 6, Title = "Title", Rows = 2 });

            MyNews.Add(new NewsItem { Id = 7, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 8, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 9, Title = "Title" });
            MyNews.Add(new NewsItem { Id = 10, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 11, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 12, Title = "Title", Rows = 2 });

            MyNews.Add(new NewsItem { Id = 13, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 14, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 15, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 16, Title = "Title", Rows = 3 });
            MyNews.Add(new NewsItem { Id = 17, Title = "Title" });
            MyNews.Add(new NewsItem { Id = 18, Title = "Title", Rows = 2 });
            MyNews.Add(new NewsItem { Id = 19, Title = "Title" });

            return Task.CompletedTask;
        }
    }
}

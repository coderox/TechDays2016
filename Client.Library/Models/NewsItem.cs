using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public interface IWrappedItem
    {
        int Columns { get; }
        int Rows { get; }
    }
    public class NewsItem: IWrappedItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
    }
}

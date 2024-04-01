using System.Collections.Generic;

namespace App.Application.Featured.News.GetAll.Data
{
    public class NewsWithCount
    {
        public int NewsCount { get; set; }
        public List<NewsDTO> News { get; set; }

    }
}

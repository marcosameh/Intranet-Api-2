using App.Application.Featured.News.GetAll.Data;
using App.Application.Infrastructure;
using MediatR;
using System.Collections.Generic;

namespace App.Application.Featured.News.GetAll.Query
{
    public class GetNewsQuery : IRequest<Result<NewsWithCount>>
    {

        public int pageNumber { get; set; }

        public int pageSize { get; set; }
        public int? NewsTypeId { get; set; }
        public string SearchName { get; set; }
    }

}

using App.Application.Featured.News.GetAll.Data;
using App.Application.Infrastructure;
using App.Domain.DBGeneratedModel;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Featured.News.GetAll.Query
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery,Result<NewsWithCount>>
    {
        private readonly IntranetContext _context;
        private readonly IMapper _mapper;

        public GetNewsQueryHandler(IMapper mapper, IntranetContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<NewsWithCount>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            var NewsWithCount=new NewsWithCount();
            try
            {
                var news = await _context.News
                    .Include(n => n.NewsType)
                    .Include(n => n.NewsAttachments)
                    .Where(n =>
                        (string.IsNullOrEmpty(request.SearchName) ||
                        n.Body.Contains(request.SearchName) ||
                        n.Title.Contains(request.SearchName) ||
                        n.NewsType.Name.Contains(request.SearchName)) &&
                        (!request.NewsTypeId.HasValue || request.NewsTypeId == 0 || n.NewsTypeId == request.NewsTypeId))
                    .OrderByDescending(n => n.Createdon)
                    .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize).ToListAsync();


                var result = _mapper.Map<List<NewsDTO>>(news);
                NewsWithCount.News = result;
                NewsWithCount.NewsCount = news.Count;
                return Result.Ok(NewsWithCount);

            }
            catch (ValidationException ex)
            {
                return Result.Fail<NewsWithCount>(string.Join(", ", ex.Errors));
            }
            catch (Exception ex)
            {
                return Result.Fail<NewsWithCount>(ex.Message + ex.InnerException?.Message);
            }
        }
    }
}

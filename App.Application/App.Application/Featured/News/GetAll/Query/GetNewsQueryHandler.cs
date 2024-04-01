using App.Application.Featured.News.GetAll.Data;
using App.Domain.DBGeneratedModel;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Featured.News.GetAll.Query
{
    public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, IEnumerable<NewsDTO>>
    {
        private readonly IntranetContext _context;
        private readonly IMapper _mapper;

        public GetNewsQueryHandler(IMapper mapper, IntranetContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<NewsDTO>> Handle(GetNewsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _context.News
                    .Include(n => n.NewsType)
                    .Include(n => n.NewsAttachments)
                    //.Where(n =>
                    //    (string.IsNullOrEmpty(request.SearchName) ||
                    //    n.Body.Contains(request.SearchName) ||
                    //    n.Title.Contains(request.SearchName) ||
                    //    n.NewsType.Name.Contains(request.SearchName)) &&
                    //    (!request.NewsTypeId.HasValue || request.NewsTypeId == 0 || n.NewsTypeId == request.NewsTypeId))
                    .OrderByDescending(n => n.Createdon)
                    .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize);

                var result = await query.ToListAsync(cancellationToken);
                return _mapper.Map<IEnumerable<NewsDTO>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to Get All News", ex);
            }
        }
    }
}

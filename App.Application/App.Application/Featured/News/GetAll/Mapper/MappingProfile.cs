using App.Application.Featured.News.GetAll.Data;
using AutoMapper;
using System.Linq;

namespace App.Application.Featured.News.GetAll.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<App.Domain.DBGeneratedModel.News, NewsDTO>()
           .ForMember(dest => dest.CoverImg, opt => opt.MapFrom(src => src.NewsAttachments.FirstOrDefault(a => a.AttachmentName != null && a.CoverImg != null).CoverImg));




        }
    }
}

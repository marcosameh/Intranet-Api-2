using App.Domain.DBGeneratedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Featured.News.GetAll.Data
{
    public class NewsDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public int TypeId
        {
            get;
            set;
        }
        public string NewsType
        {
            get;
            set;
        }

        public string CoverImg { get; set; }
        public DateTime CreatedOn
        {
            get;
            set;
        } = DateTime.Now;
    }
}

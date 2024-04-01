using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DBGeneratedModel
{
    public class KnowledgebaseFileDownload
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FileId { get; set; }
        public DateTime DateView { get; set; }

    }
}
